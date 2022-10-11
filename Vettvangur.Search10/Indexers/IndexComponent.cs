﻿using Examine;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Infrastructure.Examine;

namespace Vettvangur.Search
{
    public class IndexComponent : IComponent
    {
        private readonly IExamineManager _examineManager;

        public IndexComponent(IExamineManager examineManager)
        {
            _examineManager = examineManager;
        }

        public void Initialize()
        {
            foreach (var index in _examineManager.Indexes)
            {
                if (!(index is UmbracoExamineIndex umbracoIndex))
                {
                    continue;
                } 
                
                ((BaseIndexProvider)index).TransformingIndexValues += IndexerComponent_TransformingIndexValues;

            }
        }

        private void IndexerComponent_TransformingIndexValues(object sender, IndexingItemEventArgs e)
        {
            if (e.ValueSet.Category == IndexTypes.Content)
            {
                string searchablePath = "";
                foreach (var fieldValues in e.ValueSet.Values)
                {
                    if (fieldValues.Key == "path")
                    {
                        foreach (var value in fieldValues.Value)
                        {
                            var path = value.ToString().Replace(",", " ");

                            searchablePath =  string.Join(" ", path.Split(',').Select(x => string.Format("{1}{0}{1}", x.Replace(" ", "|").ToLower(), '|')));
                        }
                    }
                }

                var updatedValues = e.ValueSet.Values.ToDictionary(x => x.Key, x => x.Value.ToList());
                updatedValues.Add("searchPath", new List<object> { searchablePath });
                e.SetValues(updatedValues.ToDictionary(x => x.Key, x => (IEnumerable<object>)x.Value));
            }
        }

        public void Terminate()
        {
            foreach (var index in _examineManager.Indexes)
            {
                if (!(index is UmbracoExamineIndex umbracoIndex))
                {
                    continue;
                }

                ((BaseIndexProvider)index).TransformingIndexValues -= IndexerComponent_TransformingIndexValues;

            }
        }
    }
}