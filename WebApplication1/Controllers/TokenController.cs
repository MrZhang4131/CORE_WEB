using Book_Web.Data;
using Book_Web.Tools.HashGen;
using Book_Web.Tools.Reception;
using Book_Web.Tools.Token;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_Web.Controllers
{
    public class TokenController : Controller
    {
        private TokenFe tokenFe;
        private readonly Book_WebContext context;
        private readonly Hash_Interface hash;
        public TokenController(TokenFe token,Book_WebContext webContext,Hash_Interface hash_Interface) {
            tokenFe = token;
            context = webContext;
            this.hash = hash_Interface;
        }
        [Route("/image")]
        public async Task<IActionResult> ShowImage()
        {
            return PhysicalFile(@"C:\Users\31283\Desktop\.net_web\vue_project\src\views\image\image.png", "image/png");
        }

        [HttpPost]
        [Route("/token")]
        public async Task<IActionResult> Index([FromBody] UserLog userLog)
        {
            //哈希加密
            string hashuser = hash.GenHash(userLog.username);
            string hashpass = hash.GenHash(userLog.password);
            int found= await IsFound(hashuser, hashpass);
            if (Convert.ToBoolean(found))
            {
                //成功返回令牌
                string[] strings = {"User","Authors","Publishing","Admin" };
                var tokenc = tokenFe.CreateToken(strings[found-1]);
                tokenc.name = userLog.username;
                Token_CallBack result = new Token_CallBack
                {
                    StatusCode = 200,
                    Message = "Token Success Get",
                    TokenInfo = tokenc,
                };
                return result;
            }
            else
            {
                //返回错误信息
                Token_CallBack result = new Token_CallBack
                {
                    StatusCode=400,
                    Message="Password or Username erro",
                    TokenInfo=new TnToken
                    {
                        TokenStr = "",
                        Expires = DateTime.Now,
                    },
                };
                return result;
            }
            
        }
        //验证账号密码的身份
        private async Task<int> IsFound(string str1,string str2)
        {
            var res = await context.User.FirstOrDefaultAsync(a => a.UserName == str1 && a.PassWord == str2);
            if(res != null)
            {
                res.Last_Login = DateTime.Now;
                context.SaveChanges();
                return 1;
            }
            var res1 = await context.AuthorCount.FirstOrDefaultAsync(a => a.UserName == str1 && a.PassWord == str2);
            if (res != null)
            {
                res.Last_Login = DateTime.Now;
                context.SaveChanges();
                return 2;
            }
            var res2 = await context.PublishingHouse.FirstOrDefaultAsync(a => a.UserName == str1 && a.PassWord == str2);
            if (res != null)
            {
                res.Last_Login = DateTime.Now;
                context.SaveChanges();
                return 3;
            }
            var res3 = await context.Admin.FirstOrDefaultAsync(a => a.UserName == str1 && a.Password == str2 && a.Enabled==true);
            if (res != null)
            {
                res.Last_Login = DateTime.Now;
                context.SaveChanges();
                return 4;
            }
            return 0;
        }
    }
}
