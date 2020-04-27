using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PeopleAdder.Data;
using PeopleAdder.Models;

namespace PeopleAdder.Controllers
{
    public class HomeController : Controller
    {
        private string _conStr = "Data Source=.\\sqlexpress;Initial Catalog=MySecondDb;Integrated Security=True";
        public IActionResult Index()
        {
            PeopleDb db = new PeopleDb(_conStr);
            return View(db.GetPeople());
        }
        public IActionResult AddPeopleForm()
        {
            return View();
        }
        public IActionResult AddPerson(List<Person> ppl)
        {
            PeopleDb db = new PeopleDb(_conStr);
            foreach(Person p in ppl)
            {
                db.AddPerson(p);
            }
            return Redirect("/");
        }
    }
}
