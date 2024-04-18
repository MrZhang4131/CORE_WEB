using Book_Web.Data;
using Book_Web.Tools;
using Book_Web.Tools.HashGen;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Book_Web.Service.Service_Foramt
{
    public class CreateuserA : CreateUser
    {
        private Book_WebContext context;
        private Hash_Interface hash;
        private ILogger<CreateuserA> logger;
        public CreateuserA(Book_WebContext context,Hash_Interface hash_Gen, ILogger<CreateuserA> logger)
        {
            this.context = context;
            this.hash = hash_Gen;
            this.logger = logger;
        }
        public async Task<IActionResult> CreaterUser(string username, string password,string email)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // 获取当前堆栈信息
                        StackTrace stackTrace = new StackTrace(4);

                        // 获取调用堆栈中的第一个帧（即当前函数被调用的位置）
                        StackFrame callerFrame = stackTrace.GetFrame(1);

                        // 获取调用位置的方法信息
                        var callingMethod = callerFrame.GetMethod();
                        logger.LogError("方法为"+callingMethod.Name);
                        switch (callingMethod.Name)
                        {
                            case "User":
                                User_Gen(username, password, email);
                                break;
                            case "AuthorCount":
                                Author_Gen(username, password, email);
                                break;
                            case "PublishingHouse":
                                Publish_Gen(username, password, email);
                                break;
                            default:

                                break;

                        }
                        username = hash.GenHash(username);
                        context.UserNames.Add(new Models.UserName
                        {
                            Name = username,
                        });
                        await context.SaveChangesAsync();
                        transaction.Commit();
                        return new MyResponse
                        {
                            StatusCode = 200,
                            Message = "Creater Count Finished"
                        };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return new MyResponse
                        {
                            StatusCode = 200,
                            Message = ex.Message
                        };
                    }
                }
                
            }catch (Exception ex)
            {
                return  new MyResponse
                {
                    StatusCode = 200,
                    Message = ex.Message,
                };
            }

        }
        private void User_Gen(string username,string password,string email)
        {
            username = hash.GenHash(username);
            password = hash.GenHash(password);
            email = hash.GenHash(email);
            context.User.Add(new Models.User
            {
                UserName = username,
                PassWord = password,
                Email = email,
                Last_Login = DateTime.Now,
            });
        }
        private void Author_Gen(string username, string password, string email)
        {
            username = hash.GenHash(username);
            password = hash.GenHash(password);
            email = hash.GenHash(email);
            context.AuthorCount.Add(new Models.AuthorCount
            {
                UserName = username,
                PassWord = password,
                Email = email,
                Last_Login = DateTime.Now,
            });
        }
        private void Publish_Gen(string username, string password, string email)
        {
            username = hash.GenHash(username);
            password = hash.GenHash(password);
            email = hash.GenHash(email);
            context.PublishingHouse.Add(new Models.PublishingHouse
            {
                UserName = username,
                PassWord = password,
                Email = email,
                Last_Login = DateTime.Now,
            });
        }
    }
}
