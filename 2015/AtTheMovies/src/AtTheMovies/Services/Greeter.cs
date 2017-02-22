using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AtTheMovies.Services
{
    public interface IGreeter
    {
        string FetchGreeting();
    }

    public class GreeterOptions
    {
        public string Message { get; set; }
    }

    public class Greeter : IGreeter
    {
        private readonly GreeterOptions _options;

        public Greeter(IOptions<GreeterOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;            
        }

        public string FetchGreeting()
        {
            
            return _options.Message;
        }
    }
}