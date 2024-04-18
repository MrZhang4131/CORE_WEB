using Book_Web.Models;

namespace Book_Web.Service
{
    public interface BookService
    {
        public void Log(string str);
        public Task<List<Book>> SelectAllBook();
        public Task<List<Book>> SelectAllBook(int id);
        public Task<List<Book>> SelectAllBook(string str);
        public Task<Book> Details(int? id);

        public void Create(string name, string Description, string Author, string Targe, string Bye_Url);

    }
}
