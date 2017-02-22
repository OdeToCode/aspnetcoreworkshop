using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtTheMovies.Services;
using Microsoft.AspNetCore.Mvc;

namespace AtTheMovies.Controllers
{
    public class HomeController 
    {
        private readonly IGreeter _greeter;

        public HomeController(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public string Index()
        {
            return _greeter.FetchGreeting();

        }
    }
}
