using Search.Core.Models;
using Search.Core.Models.Enums;
using Search.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using Umbraco.Web.WebApi;

namespace Search.Core.Controllers
{
    public class SearchController : UmbracoApiController
    {
        private readonly SearchService _ss;
        public SearchController(SearchService ss)
        {
            _ss = ss;
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        public HttpResponseMessage Query(string query, string culture)
        {

            var contentFields = new List<SearchField>()
            {
                new SearchField()
                {
                    Name = "nodeName",
                    Booster = "^2.0",
                },
                new SearchField()
                {
                    Name = "content",
                    Booster = "^1.0"
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
                    Booster = "^1.0"
                }
            };

            var productResults = _ss.Query(new QueryRequest() { Query = query, Culture = null, Fields = productFields, SearchNodeById = "1104", NodeTypeAlias = new string[] { "ekmProduct" } }, out long totalProducts).Select(x => new
            {
                Id = x.Content.Id,
                NodeName = x.Content.Name,
                Score = x.Score
            });

            var contentResults = _ss.Query(new QueryRequest() { Query = query, Culture = culture, Fields = contentFields, SearchNodeById = "1125", NodeTypeAlias = new string[] { "frontpage", "subpage" } }, out long totalContent).Select(x => new {
                Id = x.Content.Id,
                NodeName = x.Content.Name,
                Score = x.Score
            });

            JavaScriptSerializer serialiser = new JavaScriptSerializer();
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(serialiser.Serialize(new {
                productResults,
                totalProducts,
                contentResults,
                totalContent
            }));

            return new HttpResponseMessage();
        }

    }
}
