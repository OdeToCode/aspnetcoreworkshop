using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtTheMovies.Models;
using AtTheMovies.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtTheMovies.Controllers
{
    [Route("[controller]/[action]"), Route("")]    
    public class HomeController : Controller
    {
        private readonly IMovieDataStore _movies;

        public HomeController(IMovieDataStore movies)
        {
            _movies = movies;
        }
        
        [HttpGet]
        public IActionResult Index()
        {                               
            var model = _movies.GetAll();
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                _movies.Add(newMovie);
                _movies.Commit();
                return RedirectToAction("Details", new {id = newMovie.Id});
            }
            return View(newMovie);
        }

        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var model = _movies.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}
