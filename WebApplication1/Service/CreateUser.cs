using Microsoft.AspNetCore.Mvc;

namespace Book_Web.Service
{
    public interface CreateUser
    {
        Task<IActionResult> CreaterUser(string username,string password,string email);
    }
}
