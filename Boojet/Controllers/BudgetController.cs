using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Boojet.DAL;
using Boojet.Models;

namespace Boojet.Controllers
{
    public class BudgetController : Controller
    {
        private readonly BoojetRepo _repo = new BoojetRepo();

        // GET: Budget

        public ActionResult Index(Guid userId, int? year, int? month)
        {
            var vm = new BudgetVM() {Month = month.Value, Year = year.Value};
            return View(vm);
        }

        public ActionResult Login(string email, string password)
        {
            var user = _repo.FindUser(email, password);
            if (user != null)
            {
                return RedirectToAction("Index", new {userId = user.Id, year = 2016, month = 12});
            }
            return RedirectToAction("Index", "Home");
        }
    }
}