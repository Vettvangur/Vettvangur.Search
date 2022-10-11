﻿using Vettvangur.SearchOld.Models.Enums;

namespace Vettvangur.SearchOld.Models
{
    public class SearchField
    {
        public string Name { get; set; }
        public SearchType SearchType { get; set; } = SearchType.FuzzyAndWilcard;
        public string FuzzyConfiguration { get; set; } = "0.5";
        public string Booster { get; set; }
        public string Culture { get; set; }

    }
}
