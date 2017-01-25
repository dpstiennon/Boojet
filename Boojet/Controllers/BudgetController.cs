using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Boojet.Models;

namespace Boojet.Controllers
{
    public class BudgetController : Controller
    {
        // GET: Budget
        public ActionResult Index(int year, int month)
        {
            var vm = new BudgetVM() {Month = month, Year= year};
            return View(vm);
        }
    }
}