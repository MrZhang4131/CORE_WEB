using Book_Web.Tools.Token;
using Microsoft.AspNetCore.Mvc;

namespace Book_Web.Tools
{
    public class MyResponse : IActionResult
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public Object? Data { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(new { Message, Data })
            {
                StatusCode = StatusCode
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
