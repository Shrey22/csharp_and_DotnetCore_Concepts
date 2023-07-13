using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using System.Diagnostics;
using PersonService;
using PersonServiceContract;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        //private readonly PeopleService _pplService;
        //private readonly IPersonService _pplService;
        private readonly IPersonService _pplService1;
        private readonly IPersonService _pplService2;
        private readonly IPersonService _pplService3;


        //DI
        public HomeController(IPersonService personService1, IPersonService personService2, IPersonService personService3)
        {
            _pplService1 = personService1;
            _pplService2 = personService2;
            _pplService3 = personService3;
        }

        public IActionResult Index()
        {

            //List<string> people = _pplService.GetListOfPeople();
            //List<Person> people = new List<Person>()
            //{
            //    new Person() {Name = "Shrey",DateOfBirth = DateTime.Parse("2006-05-01"),Sex = Gender.Male },
            //    new Person() {Name = "Shrishti",DateOfBirth = DateTime.Parse("2004-12-24"),Sex = Gender.Female },
            //    new Person() {Name = "Anonymus",DateOfBirth = DateTime.Parse("2000-07-17"),Sex = Gender.Other }
            //};
            //ViewBag.people = people;

            //return View("Index",people); //model binding in mvc

            //return View();

            List<string> people = _pplService1.GetListOfPeople();
            ViewBag.serviceId1 = _pplService1.serviceInstaceId;
            ViewBag.serviceId2 = _pplService2.serviceInstaceId;
            ViewBag.serviceId3 = _pplService3.serviceInstaceId;

            return View(people);
        }

        [Route("Person-Details/{name}")]
        public IActionResult Details(string? name)
        {
            if(name == null)
            {
                return Content("Person Name Cannot be Null!");
            }

            List<Person> people = new List<Person>()
            {
                new Person() {Name = "Shrey",DateOfBirth = DateTime.Parse("2006-05-01"),Sex = Gender.Male },
                new Person() {Name = "Shrishti",DateOfBirth = DateTime.Parse("2004-12-24"),Sex = Gender.Female },
                new Person() {Name = "Anonymus",DateOfBirth = DateTime.Parse("2000-07-17"),Sex = Gender.Other }
            };

            Person? matchingPerson = people.Where(x=>x.Name == name).FirstOrDefault();
            return View(matchingPerson);
        }
    }
}