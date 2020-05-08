using Calc.Command.Models;
using Calc.Command.Repositories;
using Calc.Command.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calc.Api.Controllers
{
    /// <summary>
    /// The main Controller class.
    /// Contains method ControllerOperation.
    /// </summary>
    [ApiController]
    [Route("api")]
    public class CalcController : Controller
    {
        private ICalcRepository _calcRepository;

        public CalcController(ICalcRepository icalcRepository)
        {
            _calcRepository = icalcRepository ?? throw new ArgumentNullException(nameof(icalcRepository));
        }

        /// <summary>
        /// This controller resives data from FromBody.
        /// Uses method Operations from CalcService which works with math operators: +, -, *, /.
        /// </summary>
        /// <returns>
        /// Result and StatusCode.
        /// </returns>
        /// <response code="200">
        /// Returns the message "Done".
        /// </response>
        [HttpPost]
        [Route("calc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult ControllerOperation([FromBody] RequiredCalcModel requiredCalcModel)
        {
            var result = _calcRepository.Operations(requiredCalcModel);
            Log.Information("Result:" + result);
            return Ok(result.ToString());
        }
    }
}
