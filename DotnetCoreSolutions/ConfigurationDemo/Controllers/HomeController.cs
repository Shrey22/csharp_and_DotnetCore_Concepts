using Microsoft.AspNetCore.Mvc;

namespace ConfigurationDemo.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("/")]
        public IActionResult Index()
        {
            //ViewBag.MyKey = _configuration["MyKey"];
            //ViewBag.SysCode = _configuration.GetValue("SysCode", "00000001");
            //return View();

            ApiOptions options = new ApiOptions();
            _configuration.GetSection("SysCode").Bind(options);

            ViewBag.ClientId = options.ClientId;
            ViewBag.ClientSecrect = options.ClientSecrect;
            return View();

        }
    }
}
