using Book_Web.Data;
using Book_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Web.Service.Service_Foramt
{
    public class BookServiceA : BookService
    {
        private readonly Book_WebContext Dao;
        private Log log_data;
        private readonly ILogger<BookServiceA> logger;
        private string[][] targe=new string[5][];
        public BookServiceA(Book_WebContext Dao, Log log, ILogger<BookServiceA> logger)
        {
            this.Dao = Dao;
            this.log_data = log;
            this.logger = logger;
            targe[1] =["外国文学"];
            targe[2] = ["历史文献"];
            targe[3] = ["自然科学"];
            targe[4] = ["玄幻","修仙","穿越"];
        }
        public async Task<List<Book>> SelectAllBook()
        {
            return await Dao.Book.ToListAsync();
        }
        public async Task<Book> Details(int? id)
        {
            var book = Dao.Book.FirstOrDefaultAsync(m => m.Id == id);
            return await book;
        }

        public async void Create(string name, string Description, string Author, string Targe, string Bye_Url)
        {
            try
            {
                await Dao.Book.AddAsync(new Book
                {
                    Name = name,
                    Description = Description,
                    Author = Author,
                    Targe = Targe,
                    Buy_Url = Bye_Url,
                    Population =0,
                });
                Dao.SaveChanges();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
            
            
        }

        public void Log(string str)
        {
            var time=DateTime.Now.ToString();
            logger.LogWarning("BookServiceA"+time);
            log_data.Warnning_Log(str);
        }

        public async Task<List<Book>> SelectAllBook(int id)
        {
            return await Dao.Book.Where(b=> b.Targe == targe[id][0]).ToListAsync();
        }

        public async Task<List<Book>> SelectAllBook(string str)
        {
            return await Dao.Book.Where(b => b.Name.Contains(str)).ToListAsync();
        }
    }
}
