using Search.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Core.Models
{
    public class QueryRequest
    {
        public string Indexer { get; set; } = "ExternalIndex";
        public string Query { get; set; }
        public string Culture { get; set; } = null;
        public List<SearchField> Fields { get; set; } = null;
        public string[] NodeTypeAlias { get; set; } = null;
        public SearchType SearchType { get; set; } = SearchType.FuzzyAndWilcard;
        public string FuzzyConfiguration { get; set; } = "0.5";
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
        public string SearchNodeById { get; set; } = "";
    }
}
