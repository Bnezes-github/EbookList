using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EbookList.Models;
using EbookList.Data;
using Microsoft.EntityFrameworkCore;

namespace EbookList.Controllers
{
    public class BooksController : Controller
    {

        private readonly ApplicationDbContext _db;
        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Books.ToList());
        }

        //GET book/Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Add(book);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        //Get action Edit Ebooks
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _db.Books.SingleOrDefaultAsync(m => m.Id == id);

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        //Post Action Update Ebooks
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                // _db.Update(book);
                var EbookFromDb = await _db.Books.FirstOrDefaultAsync(b => b.Id == book.Id);
                EbookFromDb.Name = book.Name;
                EbookFromDb.Author = book.Author;
                EbookFromDb.Price = book.Price;

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }






        //Get action Delete Ebooks
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _db.Books.SingleOrDefaultAsync(m => m.Id == id);

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        //Post Action Delete Ebooks
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveEbook(int? id)
        {
            var book = await _db.Books.SingleOrDefaultAsync(m => m.Id == id);
            
            _db.Books.Remove(book);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));


        }


        //Edit Details Ebooks
       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _db.Books.SingleOrDefaultAsync(m => m.Id == id);

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }



    }
}