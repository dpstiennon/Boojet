using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Boojet.DAL;
using Boojet.Enums;
using Boojet.Models;

namespace Boojet.Controllers.api
{
    public class TransactionsController : ApiController
    {
        private BoojetRepo repo = new BoojetRepo();

        [ResponseType(typeof(List<Transaction>))]
        public IHttpActionResult Get(Guid userId, int year, int month, TransactionType type)
        {
            return Ok(repo.LoadMonthlyBoojet(userId, year, month).TransactionsByType(type));
        }

        // GET: api/Transactions/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Transactions
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Transactions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Transactions/5
        public void Delete(int id)
        {
        }
    }
}
