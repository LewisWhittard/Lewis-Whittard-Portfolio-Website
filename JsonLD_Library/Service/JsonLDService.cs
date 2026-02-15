using JsonLD_Library.Service.Base;
using Microsoft.AspNetCore.Http;

namespace JsonLD_Library.Service
{
    public class JsonLDService : JsonLDBase
    {
        public JsonLDService(IHttpContextAccessor http) : base(http)
        {
        }
    }
}
