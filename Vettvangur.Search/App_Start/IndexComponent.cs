using Examine;
using Examine.LuceneEngine;
using Examine.Providers;
using System.Linq;
using Umbraco.Core.Composing;
using Umbraco.Examine;

namespace Vettvangur.Search.App_Start
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

                e.ValueSet.TryAdd("searchPath", searchablePath);

            }
        }

        public void Terminate()
        {

        }
    }
}