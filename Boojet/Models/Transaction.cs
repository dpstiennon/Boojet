using System;
using Boojet.Enums;

namespace Boojet.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public Frequencies Frequency { get; set; }
        public TransactionType Type { get; set; }

        public Guid BudgetId;
        public int Sequence { get; set; }
    }
}