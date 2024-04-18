
using Book_Web.Data;
using Book_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_Web.Service.Service_Foramt
{
    public class InfoMationA : InfoMationService
    {
        private Book_WebContext context;
        public InfoMationA(Book_WebContext book_Web) {
            this.context = book_Web;
        }

        public void AddInfo(string[] strings)
        {
            context.Message.Add(new Message
            {
                Source = strings[0],
                Accept = strings[1],
                Info = strings[2],
                LogTime = DateTime.Now,
            });
        }

        public async Task<List<BookList>> BookList(string source)
        {
            return await context.BookList.Where(m => m.UserN == source).ToListAsync();
        }

        public async Task<List<Message>> GetMationAsync(string source)
        {
            return await context.Message.Where(m => m.Source == source || m.Accept == source).ToListAsync();
        }
        
    }
}
