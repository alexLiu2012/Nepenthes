using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StackTools.Nepenthes.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            if (context.Error.Message.Contains("401"))
            {
                return Problem(
                    statusCode: 401,
                    detail: "no authorization");
            }

            if (context.Error.Message.Contains("404"))
            {
                return Problem(
                    statusCode: 404,
                    detail: "no resource found");
            }

            return Problem(
                statusCode: 500,
                detail: context.Error.Message);
        }
    }
}