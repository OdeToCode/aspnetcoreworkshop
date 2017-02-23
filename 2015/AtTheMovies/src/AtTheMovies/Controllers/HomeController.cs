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


      
    }
}
