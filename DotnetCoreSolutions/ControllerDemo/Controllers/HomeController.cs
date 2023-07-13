using Microsoft.AspNetCore.Mvc;
using ControllerDemo.Models;

namespace ControllerDemo.Controllers
{
    //Controller
    [Controller] // Attribute
    public class HomeController : Controller
    {
        //Action ==> method
        [Route("Home")]
        //[Route("/")]
        public ContentResult Index()
        {
            //return new ContentResult() 
            //{
            //    Content= "Hello from index",
            //    ContentType= "text/plain",
            //    StatusCode= 200,
            //};

            //return Content("Hello from index");
            return Content("<h1>Welcome Shrey</h1><h2>Hello from Index</h2>", "text/html");
        }

        [Route("Book")]
        public IActionResult GetBook()
        {
            //book id must be supplied
            if (!Request.Query.ContainsKey("bookid"))
            {
                Response.StatusCode = 400;
                return Content("BookId must be supplied!");
            }
            //book id cannot be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                Response.StatusCode = 400;
                return Content("BookId cannot be Empty!");
            }
            //book id should be in range 1 to 1000
            int bookid = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookid"]);

            if(bookid <= 0)
            {
                Response.StatusCode = 400;
                return Content("BookId should be greater than 0!");
            }
            if (bookid >= 1000)
            {
                Response.StatusCode = 400;
                return Content("BookId should be less than 1000!");
            }
            if (Convert.ToBoolean(Request.Query["isLoggedIn"]) == false)
            {
                Response.StatusCode = 401;
                return Content("User must be Authenticated!");

            }
            return File("/files/sample.pdf", "application/pdf");
            //return Content("All OK...");
            //return View();
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person() 
            { Id = Guid.NewGuid(), FirstName = "Shrey", LastName = "Kumar", Age = 19 };
            return Json(person);
        }

        [Route("file-dwnd")]
        public VirtualFileResult FileToDownload()
        {
            //return new VirtualFileResult("/files/sample.pdf", "application/pdf");
            //return File("/files/sample.pdf", "application/pdf");
            //return File("/images/image.jpg", "image/jpeg");
            return new VirtualFileResult("/images/image.jpg", "image/jpeg");
        }

        [Route("file-dwnd1")]
        public PhysicalFileResult FileToDownload1()
        {
            return new PhysicalFileResult(@"C:\Users\powlsh\Downloads\sample.pdf", "application/pdf");
        }

        [Route("file-dwnd2")]
        public FileContentResult FileToDownload2()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\powlsh\Downloads\mrindia.jpg");
            return File(bytes, "image/jpeg");
        }

        [Route("about")]
        public string About()
        {
            return "About Us!";
        }

        [Route("contact/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "Contact Us!";
        }

    }
}
