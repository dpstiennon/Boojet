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
        private BoojetRepo repo = new BoojetRepo();


        // GET: api/MonthlyBudgets
        public IQueryable<MonthlyBoojet> GetMonthlyBudgets()
        {
            return db.MonthlyBoojets;
        }

        // GET: api/MonthlyBudgets/5
        [ResponseType(typeof(MonthlyBoojet))]
        public IHttpActionResult GetMonthlyBudget(Guid userId, int month, int year)
        {
            MonthlyBoojet monthlyBoojet = db.MonthlyBoojets.FirstOrDefault();
            if (monthlyBoojet == null)
            {
                return NotFound();
            }

            return Ok(monthlyBoojet);
        }

//        [ResponseType(typeof(List<Transaction>))]
//        public IHttpActionResult GetTransactions(Guid userId, int month, int year, TransactionType type)
//        {
//            return Ok(repo.LoadMonthlyBudget(userId, month, year).TransactionsByType(type));
//        }
//
//        [ResponseType(typeof(List<Transaction>))]
//        public IHttpActionResult GetTransactions()
//        {
//            return Ok(repo.LoadMonthlyBudget(new Guid("7ba81e78-c0ec-e611-b035-4c32758e1f0a"), 1, 2017).TransactionsByType(TransactionType.Recurring));
//        }


        // PUT: api/MonthlyBudgets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonthlyBudget(Guid id, MonthlyBoojet monthlyBoojet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monthlyBoojet.Id)
            {
                return BadRequest();
            }

            db.Entry(monthlyBoojet).State = EntityState.Modified;

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
        [ResponseType(typeof(MonthlyBoojet))]
        public IHttpActionResult PostMonthlyBudget(MonthlyBoojet monthlyBoojet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MonthlyBoojets.Add(monthlyBoojet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = monthlyBoojet.Id }, monthlyBoojet);
        }

        // DELETE: api/MonthlyBudgets/5
        [ResponseType(typeof(MonthlyBoojet))]
        public IHttpActionResult DeleteMonthlyBudget(Guid id)
        {
            MonthlyBoojet monthlyBoojet = db.MonthlyBoojets.Find(id);
            if (monthlyBoojet == null)
            {
                return NotFound();
            }

            db.MonthlyBoojets.Remove(monthlyBoojet);
            db.SaveChanges();

            return Ok(monthlyBoojet);
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
            return db.MonthlyBoojets.Count(e => e.Id == id) > 0;
        }
    }
}