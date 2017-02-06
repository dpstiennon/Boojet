using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boojet.Models
{
    public  class Budget 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BudgetItem> BudgetItems { get; set; }
        public decimal Target { get; set; }

        public int Sequence { get; set; }
        public Guid MonthlyBudgetId { get; set; }
        
    }
}