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
        public DbSet<MoneyItem> MoneyItems { get; set; }
    }
}