using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Boojet.DAL;
using Boojet.Enums;
using Boojet.Models;

namespace Boojet.Controllers.api
{
    public class MonthlyBudgetsController : ApiController
    {
        private BudgetContext db = new BudgetContext();
        private MonthlyBudgetRepo repo = new MonthlyBudgetRepo();


        // GET: api/MonthlyBudgets
        public IQueryable<MonthlyBudget> GetMonthlyBudgets()
        {
            return db.MonthlyBudgets;
        }

        // GET: api/MonthlyBudgets/5
        [ResponseType(typeof(MonthlyBudget))]
        public IHttpActionResult GetMonthlyBudget(Guid userId, int month, int year)
        {
            MonthlyBudget monthlyBudget = db.MonthlyBudgets.FirstOrDefault();
            if (monthlyBudget == null)
            {
                return NotFound();
            }

            return Ok(monthlyBudget);
        }

        [ResponseType(typeof(List<Transaction>))]
        public IHttpActionResult GetTransactions(Guid userId, int month, int year, TransactionType type)
        {
            return Ok(repo.LoadMonthlyBudget(userId, month, year).TransactionsByType(type));
        }

        [ResponseType(typeof(List<Transaction>))]
        public IHttpActionResult GetTransactions()
        {
            return Ok(repo.LoadMonthlyBudget(new Guid("7ba81e78-c0ec-e611-b035-4c32758e1f0a"), 1, 2017).TransactionsByType(TransactionType.Recurring));
        }


        // PUT: api/MonthlyBudgets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonthlyBudget(Guid id, MonthlyBudget monthlyBudget)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monthlyBudget.Id)
            {
                return BadRequest();
            }

            db.Entry(monthlyBudget).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonthlyBudgetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MonthlyBudgets
        [ResponseType(typeof(MonthlyBudget))]
        public IHttpActionResult PostMonthlyBudget(MonthlyBudget monthlyBudget)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MonthlyBudgets.Add(monthlyBudget);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = monthlyBudget.Id }, monthlyBudget);
        }

        // DELETE: api/MonthlyBudgets/5
        [ResponseType(typeof(MonthlyBudget))]
        public IHttpActionResult DeleteMonthlyBudget(Guid id)
        {
            MonthlyBudget monthlyBudget = db.MonthlyBudgets.Find(id);
            if (monthlyBudget == null)
            {
                return NotFound();
            }

            db.MonthlyBudgets.Remove(monthlyBudget);
            db.SaveChanges();

            return Ok(monthlyBudget);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MonthlyBudgetExists(Guid id)
        {
            return db.MonthlyBudgets.Count(e => e.Id == id) > 0;
        }
    }
}