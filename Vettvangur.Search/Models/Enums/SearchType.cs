using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vettvangur.Search.Models.Enums
{
    public enum SearchType
    {
       Exact,
       Wildcard,
       Fuzzy,
       FuzzyAndWilcard
    }
}
