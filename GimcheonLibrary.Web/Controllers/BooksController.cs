﻿using System.Collections.Generic;
using GimcheonLibrary.DataAccess.Models;
using GimcheonLibrary.DataAccess.Repository;
using GimcheonLibrary.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GimcheonLibrary.Web.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly BookRepository _bookRepository;
        private readonly AuthorRepository _authorRepository;

        public BooksController(IConfiguration configuration)
        {
            _bookRepository = new BookRepository(configuration);
            _authorRepository = new AuthorRepository(configuration);
        }

        // GET: BookController
        [AllowAnonymous]
        public IActionResult Index()
        {
            var books = _bookRepository.FindAll();

            return View(books);
        }

        // GET: BookController/Details/5
        [AllowAnonymous]
        public IActionResult Details(int? id)
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
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
        public IActionResult Edit(int? id)
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
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.Update(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: BookController/Delete/5
        public IActionResult Delete(int? id)
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
        public IActionResult Delete(int id)
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
