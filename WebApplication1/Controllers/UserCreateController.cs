using Book_Web.Data;
using Book_Web.Service;
using Book_Web.Tools;
using Book_Web.Tools.HashGen;
using Microsoft.AspNetCore.Mvc;

namespace Book_Web.Controllers
{
    public class UserCreateController : Controller
    {
        private readonly Hash_Interface hash;
        private readonly Book_WebContext context;
        private CreateUser creater;
        public UserCreateController(Hash_Interface hash,Book_WebContext webContext,CreateUser createrUser)
        {
            this.hash = hash;
            this.context = webContext;
            this.creater = createrUser;
        }
        

        public IActionResult Index(string username,string password)//创建管理员,项目上线后关闭此接口
        {
            if(username == "Zhang" &&  password == "123456")
            {
                string hashname = hash.GenHash(username);
                string hashpassword = hash.GenHash(password);
                context.Admin.Add(new Models.Admin
                {
                    UserName = hashname,
                    Password = hashpassword,
                    Enabled = true,
                });
                context.SaveChanges();
                return new MyResponse
                {
                    StatusCode = 200,
                    Message = "Succees Create",
                };
            }
            else
            {
                return new MyResponse
                {
                    StatusCode = 200,
                    Message = "权限不足"
                };
            }
            
        }
        public async Task<IActionResult> User(string username,string password,string email)
        {
            return await creater.CreaterUser(username, password,email);
        }

        public async Task<IActionResult> AuthorCount(string username, string password, string email)
        {
            return await creater.CreaterUser(username, password, email);
        }

        public async Task<IActionResult> PublishingHouse(string username, string password, string email)
        {
            return await creater.CreaterUser(username, password, email);
        }
    }
}
