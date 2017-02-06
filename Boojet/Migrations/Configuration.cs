using System.Collections.Generic;
using Boojet.Enums;
using Boojet.Models;

namespace Boojet.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Boojet.DAL.BudgetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Boojet.DAL.BudgetContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var david = new User()
            {
                FirstName = "David",
                LastName = "Stiennon",
                MonthlyBudgets = new List<MonthlyBudget>()
                {
                    new MonthlyBudget
                    {
                        Month  = 12,
                        Year = 2016,
                        Transactions = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                Amount = 550,
                                Frequency = Frequencies.OneTime,
                                Type = TransactionType.Irregular,
                                Name = "Christmas Presents"
                            }
                        }
                    },
                    new MonthlyBudget
                    {
                        Month = 1,
                        Year = 2017,
                        Transactions = new List<Transaction>
                        {
                            new Transaction()
                            {
                                Type = TransactionType.Income,
                                Frequency = Frequencies.Weekly,
                                Amount = 1280,
                                Name = "Paycheck"
                            },
                            new Transaction()
                            {
                                Type = TransactionType.Recurring,
                                Name = "Gas Bill",
                                Amount = new decimal(55.68),
                                Frequency = Frequencies.Monthly
                            },
                            new Transaction()
                            {
                                Type = TransactionType.Recurring,
                                Name = "Electric Bill",
                                Amount = new decimal(44.44),
                                Frequency = Frequencies.Monthly
                            },
                            new Transaction()
                            {
                                Type = TransactionType.Irregular,
                                Name = "Huge new computer",
                                Amount = 1999,
                                Frequency = Frequencies.OneTime
                            }
                        },
                        Budgets = new List<Budget>()
                        {
                            new Budget()
                            {
                                Name = "groceries",
                                BudgetItems = new List<BudgetItem>()
                                {
                                    new BudgetItem()
                                    {
                                        Amount = new decimal(12.33), 
                                        Date = new DateTime(2017, 1, 4)
                                    },
                                    new BudgetItem()
                                    {
                                        Amount = new decimal(160.22),
                                        Date = new DateTime(2017, 1, 11)
                                    }
                                }
                            }
                        }

                    }
                }
            };
            context.Users.AddOrUpdate(david);
            context.SaveChanges();
        }
    }
}
