using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI;
using Boojet.Enums;

namespace Boojet.Models
{
    public class MonthlyBoojet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public Guid UserId { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Budget> Budgets { get; set; }
        [NotMapped]
        public List<Transaction> Incomes => TransactionsByType(TransactionType.Income);
        [NotMapped]
        public List<Transaction> Irregulars => TransactionsByType( TransactionType.Irregular);
        [NotMapped]
        public List<Transaction> RegularExpenses => TransactionsByType(TransactionType.Recurring);

        public MonthlyBoojet()
        {
            Transactions = new List<Transaction>();
            Budgets = new List<Budget>();
        }



        public MonthlyBoojet CreateFrom(MonthlyBoojet src, int month, int year)
        {
            return new MonthlyBoojet()
            {
                Month = month,
                Year = year
            };
        }

        public List<Transaction> TransactionsByType(TransactionType type)
        {
            return Transactions.Where(t => t.Type == type).ToList();
        }

    }
}
