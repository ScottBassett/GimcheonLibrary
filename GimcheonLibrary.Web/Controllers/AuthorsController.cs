using System.Collections.Generic;
using GimcheonLibrary.DataAccess.Models;
using GimcheonLibrary.DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GimcheonLibrary.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly AuthorRepository _authorRepository;

        public AuthorsController(IConfiguration configuration)
        {
            _authorRepository = new AuthorRepository(configuration);
        }

        // GET: AuthorsController
        public IActionResult Index()
        {
            return View(_authorRepository.FindAll());
        }

        // GET: AuthorsController/Details/5
        public IActionResult Details(int id)
        {
            var author = _authorRepository.FindById(id);
            if (author == null)
            {
                return NotFound();
            }

            var authorsBooks = _authorRepository.FindByAuthor(id);

            return View(authorsBooks);
        }

        // GET: AuthorsController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AuthorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _authorRepository.Add(author);
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: AuthorsController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Author author = _authorRepository.FindById(id.Value);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: AuthorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                _authorRepository.Update(author);
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: AuthorsController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _authorRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }

        // POST: AuthorsController/Delete/5
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
