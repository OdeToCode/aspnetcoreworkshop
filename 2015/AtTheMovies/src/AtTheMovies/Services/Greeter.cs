using Microsoft.Extensions.Configuration;

namespace AtTheMovies.Services
{
    public interface IGreeter
    {
        string FetchGreeting();
    }


    public class Greeter : IGreeter
    {
        private readonly IConfiguration _configuration;

        public Greeter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string FetchGreeting()
        {
            return _configuration["Greeter:Message"];
        }
    }
}