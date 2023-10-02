using Line.Models.Parameters;
using Line.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Line.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineBotController : ControllerBase
    {

        private readonly IWebhookService _webhookService;

        public LineBotController(IWebhookService webhookService)
        {
            this._webhookService = webhookService;
        }

        /// <summary>
        /// 接line webhook
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("Webhook")]
        public IActionResult Webhook(LineEventPayload payload)
        {
            var result = _webhookService.Insert(payload);

            return Ok(result); // 回傳 200 OK
        }

        /// <summary>
        /// 測試
        /// </summary>
        /// <returns></returns>
        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok("看的是笨蛋");
        }

        ///// <summary>
        ///// 查log
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("Log")]
        //public IActionResult GetLog()
        //{
        //    var result = _webhookService.GetLog();
        //    return Ok(result);
        //}

        /// <summary>
        /// 查看 webhook結果
        /// </summary>
        /// <param name="filterParameter"></param>
        /// <returns></returns>
        [HttpPost("Payload")]
        public IActionResult GetPayload([FromBody]PayloadFilterParameter filterParameter)
        {
            var result = _webhookService.GetPayload(filterParameter);
            return Ok(result);
        }
    }
}
