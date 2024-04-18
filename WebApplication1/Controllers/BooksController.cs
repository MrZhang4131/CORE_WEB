using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Book_Web.Data;
using Book_Web.Models;
using Book_Web.Service;
using Microsoft.AspNetCore.Authorization;
using Book_Web.Tools;

namespace Book_Web.Controllers
{
    public class IdModel
    {
        public int id { get; set; }
        public string name { get; set;}
    }
    [Authorize]
    public class BooksController : Controller
    {
        private BookService bookService;
        private readonly Book_WebContext _context;

        public BooksController(BookService bookService, Book_WebContext context)
        {
            this.bookService = bookService;
            _context = context;
        }
        // GET: Books
        [AllowAnonymous]
        public async Task<IActionResult> Index([FromBody] IdModel idModel)
        {
            if (idModel == null)
            {
                return new MyResponse
                {
                    StatusCode = 200,
                    Message= "Undefine Book",
                    Data=null
                };
            }
            int i=idModel.id;
            if (i == 0)
            {
                return new MyResponse
                {
                    StatusCode = 200,
                    Message = "Succees",
                    Data = await bookService.SelectAllBook()
                };
            }
            else
            {
                return new MyResponse
                {
                    StatusCode = 200,
                    Message = "Succees",
                    Data = await bookService.SelectAllBook(i)
                };
            }
            
        }
        public class SelectnameRes
        {
            public string bookname { get; set; }
        }
        public async Task<IActionResult> Selectname([FromBody] SelectnameRes selectnameRes)
        {
            return new MyResponse { StatusCode = 200,
                Message = "Succees",
                Data = await bookService.SelectAllBook(selectnameRes.bookname)
            };
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return Json(await bookService.Details(id));
        }

        // GET: Books/Create
        public void Create(string name,string Description,string Author,string Targe,string Bye_Url)
        {
            bookService.Create(name,Description,Author,Targe,Bye_Url);
        }


        //POST: Books/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to.
        //For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,Name,Description,Author,Targe,Population,Buy_Url")] Book book)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(book);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(book);
        // }

        //// GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id,int count)
        {
            var book = await _context.Book.FindAsync(id);

            book.Name = "Test";
            _context.SaveChanges();
            //返回商品列表界面
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Author,Targe,Population,Buy_Url")] Book book)
        //{
        //    if (id != book.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(book);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BookExists(book.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(book);
        //}

        //GET: Books/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var book = await _context.Book
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(book);
        //}

        //POST: Books/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var book = await _context.Book.FindAsync(id);
        //    if (book != null)
        //    {
        //        _context.Book.Remove(book);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BookExists(int id)
        //{
        //    return _context.Book.Any(e => e.Id == id);
        //}
    }
}
