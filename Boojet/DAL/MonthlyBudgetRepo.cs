using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Boojet.Models;

namespace Boojet.DAL
{
    public class MonthlyBudgetRepo
    {
        public MonthlyBudget LoadMonthlyBudget(Guid userId, int year, int month)
        {
            using (var context = new BudgetContext())
            {
                return context.MonthlyBudgets.
                    Where(mb => mb.UserId == userId && mb.Month == month && mb.Year == year)
                    .Include(mb => mb.Transactions)
                    .DefaultIfEmpty(new MonthlyBudget())
                    .First();
            } 
        }
    }
}