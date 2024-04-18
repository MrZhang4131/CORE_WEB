using Book_Web.Data;
using Book_Web.Service;
using Book_Web.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_Web.Controllers
{
    //[Authorize]
    public class InfoController : Controller
    {

        private InfoMationService InfoMation { get; set; }
        private Book_WebContext context {  get; set; }
        public InfoController(InfoMationService InfoMationService,Book_WebContext webContext)
        {
            this.InfoMation = InfoMationService;
            this.context = webContext;
        }
        public class UserInfoRes
        {
            public string username { get; set; }
        }
        public async Task<IActionResult> Index([FromBody] UserInfoRes userInfoRes)
        {
             var result= await InfoMation.GetMationAsync(userInfoRes.username);
            return new MyResponse
            {
                StatusCode = 200,
                Message = "Ok",
                Data = result
            };
        }
        public async Task<IActionResult> BookList([FromBody] UserInfoRes userInfoRes)
        {
            var result = await InfoMation.BookList(userInfoRes.username);
            return new MyResponse
            {
                StatusCode = 200,
                Message = "Ok",
                Data = result
            };
        }
        public class AddInfoA
        {
            public string username { get; set; }
            public string accept { get; set; }
            public string info { get; set; }
            public string[] GetStrings()
            {
                string[] strings = new string[3];
                strings[0] = username;
                strings[1] = accept;
                strings[2] = info;
                return strings;
            }
        }
        public async Task<IActionResult> AddInfo([FromBody] AddInfoA addInfo)
        {
            InfoMation.AddInfo(addInfo.GetStrings());
            return new MyResponse {
                StatusCode = 200,
                Message = "OK"
            };
        }
        public async Task<JsonResult> addList(string name,int id)
        {
            
            var book = await context.Book.FirstOrDefaultAsync(b=>b.Id==id);
            await context.BookList.AddAsync(new Models.BookList{
                UserN=name,
                BookName=book.Name
            });
            await context.SaveChangesAsync();
            return (Json(""));
        }
        public async  Task<string> getbook(int id)
        {
            var result = await context.Book.FirstOrDefaultAsync(b=>b.Id==id);
            if (result == null)
            {
                return null;
            }
            return result.Name;
        }
        public async Task<string> deletebook(string name,string id)
        {
            var book = context.BookList.FirstOrDefault(b => b.BookName == name && b.UserN==id);
            context.BookList.Remove(book);
            await context.SaveChangesAsync(); 
            return "";
        }
        public async Task<JsonResult> getbookname(string name)
        {
            var book = await context.Book.FirstOrDefaultAsync(b => b.Name == name);
            return Json(book);
        }
        
    }
}
