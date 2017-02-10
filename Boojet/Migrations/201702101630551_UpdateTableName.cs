namespace Boojet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MonthlyBudgets", newName: "MonthlyBoojets");
            DropForeignKey("dbo.Budgets", "MonthlyBudgetId", "dbo.MonthlyBudgets");
            DropIndex("dbo.Budgets", new[] { "MonthlyBudgetId" });
            RenameColumn(table: "dbo.Transactions", name: "MonthlyBudget_Id", newName: "MonthlyBoojet_Id");
            RenameIndex(table: "dbo.Transactions", name: "IX_MonthlyBudget_Id", newName: "IX_MonthlyBoojet_Id");
            AddColumn("dbo.Budgets", "MonthlyBoojet_Id", c => c.Guid());
            CreateIndex("dbo.Budgets", "MonthlyBoojet_Id");
            AddForeignKey("dbo.Budgets", "MonthlyBoojet_Id", "dbo.MonthlyBoojets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Budgets", "MonthlyBoojet_Id", "dbo.MonthlyBoojets");
            DropIndex("dbo.Budgets", new[] { "MonthlyBoojet_Id" });
            DropColumn("dbo.Budgets", "MonthlyBoojet_Id");
            RenameIndex(table: "dbo.Transactions", name: "IX_MonthlyBoojet_Id", newName: "IX_MonthlyBudget_Id");
            RenameColumn(table: "dbo.Transactions", name: "MonthlyBoojet_Id", newName: "MonthlyBudget_Id");
            CreateIndex("dbo.Budgets", "MonthlyBudgetId");
            AddForeignKey("dbo.Budgets", "MonthlyBudgetId", "dbo.MonthlyBudgets", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.MonthlyBoojets", newName: "MonthlyBudgets");
        }
    }
}
