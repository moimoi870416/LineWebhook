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
        /// webhook
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("Webhook")]
        public IActionResult Webhook(LineEventPayload payload)
        {
            _webhookService.Insert(payload);


            return Ok(); // 回傳 200 OK
        }

    }
}
