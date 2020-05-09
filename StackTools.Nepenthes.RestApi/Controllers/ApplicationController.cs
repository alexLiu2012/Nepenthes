using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackTools.Nepenthes.RestApi.Dtos;
using StackTools.Nepenthes.RestApi.Services;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.RestApi.Controllers
{
    [Route("api/applications")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private ResourceHelper _rscHelper;

        public ApplicationController(ResourceHelper aRscHelper)
        {
            this._rscHelper = aRscHelper;            
        }

        [HttpGet]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ApplicationDto>> GetAllApplications()
        {
            bool func(ApplicationDto application) => true;
            return Ok(_rscHelper.GetResource<Wa2Application, ApplicationDto>(func));
        }
    }
}
