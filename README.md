# Umbraco 11 Search Service

##### Install with Nuget
```
Install-Package Vettvangur.Search -Version 3.0.0
```

### Inject Service

```
@using Vettvangur.Search.Service;

public class SearchController : UmbracoApiController
{
    private readonly SearchService _ss;

    public SearchController(SearchService ss)
    {
        _ss = ss;
    }
}
```

### Example

```
var contentFields = new List<SearchField>()
{
    new SearchField()
    {
        Name = "nodeName",
        Booster = "^2.0",
        FuzzyConfiguration = "0.5"
    },
    new SearchField()
    {
        Name = "content",
        Booster = "^1.0",
        SearchType = SearchType.Fuzzy
    },
    new SearchField()
    {
        Name = "pageTitle",
        Booster = "^2.0"
    }
};

var productFields = new List<SearchField>()
{
    new SearchField()
    {
        Name = "nodeName",
        Booster = "^2.0"
    },
    new SearchField()
    {
        Name = "sku",
        Booster = "^3.0"
    },
    new SearchField()
    {
        Name = "title",
        Booster = "^2.0"
    },
    new SearchField()
    {
        Name = "description",
        Booster = "^1.0",
        SearchType = SearchType.Fuzzy
    }
};

var productResults = _ss.Query(new QueryRequest() { Query = query, Culture = null, Fields = productFields, SearchNodeById = "1104", NodeTypeAlias = new string[] { "ekmProduct" } }, out long totalProducts);

var contentResults = _ss.Query(new QueryRequest() { Query = query, Culture = culture, Fields = contentFields, NodeTypeAlias = new string[] { "frontpage", "subpage" } }, out long totalContent);
```

### Example of use inside of a view

```
@using Vettvangur.Search.Services;

var searchResults = SearchService.Instance.Query(QueryRequest req);
```
