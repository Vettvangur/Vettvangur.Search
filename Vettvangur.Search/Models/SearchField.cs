using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vettvangur.Search.Models.Enums;

namespace Vettvangur.Search.Models
{
    public class SearchField
    {
        public string Name { get; set; }
        public SearchType SearchType { get; set; } = SearchType.FuzzyAndWilcard;
        public string FuzzyConfiguration { get; set; } = "0.5";
        public string Booster { get; set; }

    }
}
