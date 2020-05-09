using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackTools.Wa2Wrapper.wa2Resource;
using StackTools.Nepenthes.RestApi.Dtos;
using StackTools.Nepenthes.RestApi.Services;

namespace StackTools.Nepenthes.RestApi.Controllers
{
    [Route("api/alarms")]
    [ApiController]
    public class AlarmController : ControllerBase
    {        
        private ResourceHelper _rscHelper;

        public AlarmController(ResourceHelper aRscHelper)
        {            
            this._rscHelper = aRscHelper;            
        }

        [HttpGet]
        [Produces("application/json"/*, "application/xml"*/)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<AlarmDto>> GetAllAlarms()
        {
            bool func(AlarmDto alarm) => true;
            return Ok(this._rscHelper.GetResource<Wa2Alarm, AlarmDto>(func));
        }

        [HttpGet("active")]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<AlarmDto>> GetAlarmsActive()
        {
            bool func(AlarmDto alarm) => true;
            return Ok(this._rscHelper.GetResource<Wa2Alarm, AlarmDto>(queryOrigin: "?isactive=true", filter: func));
        }
        
    }
}