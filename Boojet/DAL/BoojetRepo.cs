using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Boojet.Models;

namespace Boojet.DAL
{
    public class BoojetRepo
    {
        public MonthlyBoojet LoadMonthlyBoojet(Guid userId, int year, int month)
        {
            using (var context = new BudgetContext())
            {
                return context.MonthlyBoojets.
                    Where(mb => mb.UserId == userId && mb.Month == month && mb.Year == year)
                    .Include(mb => mb.Transactions)
                    .Include(mb => mb.Budgets)
                    .DefaultIfEmpty(new MonthlyBoojet())
                    .First();
            } 
        }

//        public List<Budget> LoadBudgets(Guid MonthlyId)
//        {
//            using (var ctx = new BudgetContext())
//            {
//                return ctx.MonthlyBoojets.Where()
//
//            }
//        }
    }
}