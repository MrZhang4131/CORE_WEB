using Book_Web.Data;

namespace Book_Web.Service.Service_Foramt
{
    public class LogA : Log
    {
        private Book_WebContext Dao;
        private readonly ILogger<BookServiceA> logger;
        public LogA(Book_WebContext Dao, ILogger<BookServiceA> logger)
        {
            this.Dao = Dao;
            this.logger = logger;
        }
        public void Warnning_Log(string message)
        {
            logger.LogWarning("LogA");
            Dao.Warning_Log.Add(new Models.Warnning_Log
            {
                Log = message,
                Time = DateTime.Now,
            }); ;
            Dao.SaveChanges();
        }
    }
}
