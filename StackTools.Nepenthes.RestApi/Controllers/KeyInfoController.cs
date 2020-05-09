using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackTools.Nepenthes.RestApi.Dtos;
using StackTools.Nepenthes.RestApi.Services;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.RestApi.Controllers
{
    [Route("api/keyinfos")]
    [ApiController]
    public class KeyInfoController : ControllerBase
    {
        private ResourceHelper _rscHelper;

        public KeyInfoController(ResourceHelper aRscHelper)
        {
            this._rscHelper = aRscHelper;
        }

        [HttpGet]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<KeyInfoDto>> GetAllKeyInfos()
        {
            bool func(KeyInfoDto keyinfo) => true;
            return Ok(this._rscHelper.GetResource<Wa2KeyInfo, KeyInfoDto>(func));
        }

        [HttpGet("hasvalue")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<KeyInfoDto>> GetKeyInfosHasValue()
        {
            bool func(KeyInfoDto keyinfo) => true;
            return Ok(this._rscHelper.GetResource<Wa2KeyInfo, KeyInfoDto>(queryOrigin: "?hasvalue=true", filter: func));
        }
    }
}