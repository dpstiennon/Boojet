using System;
using Boojet.Enums;

namespace Boojet.Models
{
    public class MoneyItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public Frequencies Frequency { get; set; }
        public MoneyItemType Type { get; set; }
        public Guid BudgetId;
    }
}