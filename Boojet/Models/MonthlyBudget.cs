using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Boojet.Enums;

namespace Boojet.Models
{
    public class MonthlyBudget
    {
        public Guid Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public Guid UserId { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Budget> Budgets { get; set; }

//        public List<Transaction> Incomes
//        {
//            get { return Transactions.Where(t => t.Type == TransactionType.Income).ToList(); }
//        }

        public MonthlyBudget CreateFrom(MonthlyBudget src, int month, int year)
        {
            return new MonthlyBudget()
            {
                Month = month,
                Year = year
            };
        }

    }
}
