using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Boojet.Models;

namespace Boojet.DAL
{
    public class BudgetContext: DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetItem> BudgetItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MonthlyBudget> MonthlyBudgets { get; set; }


    }
}