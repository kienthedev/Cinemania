using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SelfProjectDataAccess.Interfaces;
using SelfProjectDataAccess.Models;

namespace SelfProjectMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository movieRepository;
        private readonly SelfProjectContext _context;

        public MoviesController(IMovieRepository movieRepository, SelfProjectContext context)
        {
            this.movieRepository = movieRepository;
            this._context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var movies = movieRepository.GetAll();
            return View(movies);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var movie = movieRepository.FirstOrDefault(m => m.MovieId == id);
            if (id == null || movieRepository == null)
            {
                return NotFound();
            }
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        //public async Task<IActionResult> Details(string movieName)
        //{
        //    var movie = movieRepository.FirstOrDefault(m => m.Title == id);
        //    if (id == null || movieRepository == null)
        //    {
        //        return NotFound();
        //    }
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(movie);
        //}

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Title,Rated,ReleasedDate,Plot,Country,Poster,BoxOffice,Website,Production,Trailer")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movieRepository.Add(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = movieRepository.FirstOrDefault(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Title,Rated,ReleasedDate,Plot,Country,Poster,BoxOffice,Website,Production,Trailer")] Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    movieRepository.Update(movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = movieRepository.FirstOrDefault(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'SelfProjectContext.Movies'  is null.");
            }
            var movie = movieRepository.FirstOrDefault(m => m.MovieId == id);
            if (movie != null)
            {
                movieRepository.Delete(movie);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return (_context.Movies?.Any(e => e.MovieId == id)).GetValueOrDefault();
        }
    }
}
