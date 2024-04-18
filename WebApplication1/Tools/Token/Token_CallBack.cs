using Microsoft.AspNetCore.Mvc;

namespace Book_Web.Tools.Token
{
    public class Token_CallBack:IActionResult
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public TnToken? TokenInfo { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(new { Message, TokenInfo })
            {
                StatusCode = StatusCode
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
