using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace MvcApplication35.Controllers
{
    public class PersonJson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public IEnumerable<CarJson> Cars { get; set; }
    }

    public class CarJson
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetPerson(int id)
        {
            var dataContext = new PersonCarsDataContext();
            var loadOptions = new DataLoadOptions();
            loadOptions.LoadWith<Person>(p => p.Cars);
            dataContext.LoadOptions = loadOptions;
            var person = dataContext.Persons.First(p => p.Id == id);
            var personJson = new
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age,
                Cars = person.Cars.Select(c => new
                {
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Id = c.Id
                })
            };

            return Json(personJson, JsonRequestBehavior.AllowGet);
        }
    }
}
