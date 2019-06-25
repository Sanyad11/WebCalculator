using Microsoft.AspNetCore.Mvc;
using System;

namespace WebCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        WebCalculator.Manager.Manager manager = new WebCalculator.Manager.Manager();

        [Route("add/{value1}/{value2}")]
        [HttpGet]
        public IActionResult Add(int value1, int value2)
        {
            try
            {
                return BadRequest(manager.Add(value1, value2));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [Route("sub/{value1}")]
        [HttpPost]
        public IActionResult Sub([FromRoute] int value1, [FromQuery] int value2)
        {
            try
            {
                return Ok(manager.Sub(value1, value2));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [Route("mul")]
        [HttpPut]
        public IActionResult Mul([FromBody] WorkWithDB.OperationModel stringJson)
        {
            try
            {
                return Accepted(manager.Mul(stringJson));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("div")]
        [HttpDelete]
        public IActionResult Div([FromBody] WorkWithDB.OperationModel stringXml)
        {
            try
            {
                return NotFound(manager.Div(stringXml));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
