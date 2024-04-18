using Book_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_Web.Service
{
    public interface InfoMationService
    {
        public Task<List<Message>> GetMationAsync(string source);
        public Task<List<BookList>> BookList(string source);
        public void AddInfo(string[] strings);
    }

}
