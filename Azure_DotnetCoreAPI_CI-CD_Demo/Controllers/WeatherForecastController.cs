using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure_DotnetCoreAPI_CI_CD_Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IConfiguration _configuration;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public List<string> Get()
        {
            return new List<string>()
            {
                $"環境:{_configuration["Env"]}", $"版本:1.1"
            };
        }

        [HttpGet("WriteToFile")]
        public async Task WriteToFile()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.File.Create("Upload/test.txt")))
            {
                await file.WriteAsync("your text here");
            }
        }
    }
}