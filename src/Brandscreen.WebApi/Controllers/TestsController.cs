using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Brandscreen.WebApi.Controllers
{
    [RoutePrefix("api/tests")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class TestsController : ApiController
    {
        [HttpGet]
        [Authorize]
        [Route("authorize")]
        public async Task<IHttpActionResult> Authorize()
        {
            return await Task.FromResult(Ok());
        }
    }
}