using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackTools.Nepenthes.RestApi.Dtos;
using StackTools.Nepenthes.RestApi.Services;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.RestApi.Controllers
{
    [Route("api/batches")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private ResourceHelper _rscHelper;

        public BatchController(ResourceHelper aRscHelper)
        {
            this._rscHelper = aRscHelper;
        }

        [HttpGet]
        [Produces("application/json", "application/xml")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<BatchDto>> GetAllBatches()
        {
            bool func(BatchDto batch) => true;
            return Ok(this._rscHelper.GetResource<Wa2Batch, BatchDto>(func));
        }
    }
}