using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GimcheonLibrary.DataAccess.Models;
using GimcheonLibrary.DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GimcheonLibrary.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookRepository _bookRepository;

        public BooksController(IConfiguration configuration)
        {
            _bookRepository = new BookRepository(configuration);
        }

        // GET: BookController
        public IActionResult Index()
        {
            return View(_bookRepository.FindAll());
        }

        // GET: BookController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Book book = _bookRepository.FindById(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.Add(book);
               // _bookRepository.FindById(id.Value);
                // return RedirectToAction($"Details/{book.Id}");
                return RedirectToAction("Index");
            }
            
            return View(book);
            
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Book book = _bookRepository.FindById(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.Update(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _bookRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
