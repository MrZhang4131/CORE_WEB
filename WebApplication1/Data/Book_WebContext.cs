using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Book_Web.Models;

namespace Book_Web.Data
{
    public class Book_WebContext : DbContext
    {
        public Book_WebContext (DbContextOptions<Book_WebContext> options)
            : base(options)
        {
        }

        public DbSet<Book_Web.Models.Book> Book { get; set; } = default!;
        public DbSet<Book_Web.Models.Author> Author { get; set; } = default!;
        public DbSet<Book_Web.Models.Warnning_Log> Warning_Log { get; set; } = default!;
        public DbSet<Book_Web.Models.Admin> Admin { get; set; }= default!;
        public DbSet<Book_Web.Models.PublishingHouse> PublishingHouse { get; set; }=default!;
        public DbSet<Book_Web.Models.User> User { get; set; } = default!;
        public DbSet<Book_Web.Models.AuthorCount> AuthorCount { get; set; } = default!;
        public DbSet<Book_Web.Models.UserName> UserNames { get; set; } = default!;
        public DbSet<Book_Web.Models.Message> Message { get; set; } = default!;
        public DbSet<Book_Web.Models.BookList> BookList { get; set; } = default!;
    }
}
