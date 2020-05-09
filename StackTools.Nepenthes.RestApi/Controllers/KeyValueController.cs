using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackTools.Nepenthes.RestApi.Dtos;
using StackTools.Nepenthes.RestApi.Services;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.RestApi.Controllers
{
    [Route("api/keyvalues")]
    [ApiController]
    public class KeyValueController : ControllerBase
    {
        private ResourceHelper _rscHelper;

        public KeyValueController(ResourceHelper aRscHelper)
        {
            this._rscHelper = aRscHelper;
        }

        [HttpGet]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<KeyValueDto>> GetAllKeyValues()
        {
            bool func(KeyValueDto keyvalue) => true;
            return Ok(this._rscHelper.GetResource<Wa2KeyValue, KeyValueDto>(func));
        }
    }
}