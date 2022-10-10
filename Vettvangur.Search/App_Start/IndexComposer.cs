﻿using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web.Search;

namespace Vettvangur.Search.App_Start
{
    [ComposeAfter(typeof(ExamineComposer))]
    public class IndexComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().InsertAfter<ExamineComponent, IndexComponent>();
        }
    }
}
