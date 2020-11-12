using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superheroes.Models;
using Superheroes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore;

namespace Superheroes.Controllers
{
    public class SuperheroController : Controller
    {
        private ApplicationDbContext _context;
        
        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: HeroController
        public ActionResult Index()
        {
            var superheroes = _context.Superheroes.ToList();
            return View(superheroes);
        }

        // GET: HeroController/Details/5
        public ActionResult Details(int id)
        {
            var superheroes = _context.Superheroes.Where(s => s.Id == id).ToList();
            return View(superheroes);
        }

        // GET: HeroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: HeroController/Edit/5
        public ActionResult Edit(int id)
        {
            var superheroes = _context.Superheroes.Where(s => s.Id == id);
            return View(superheroes);
        }

        // POST: HeroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                _context.Update(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Edit));
            }
            catch
            {
                return View(nameof(Edit));
            }
        }

        // GET: HeroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View("/Views/Superhero/Delete.cshtml");
        }

        // POST: HeroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                _context.Remove(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Delete));
            }
            catch
            {
                return View(nameof(Delete));
            }
        }
    }
}
