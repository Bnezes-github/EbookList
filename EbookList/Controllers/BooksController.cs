using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EbookList.Models;
using EbookList.Data;

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



    }
}