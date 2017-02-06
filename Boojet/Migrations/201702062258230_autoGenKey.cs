namespace Boojet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class autoGenKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BudgetItems", "BudgetId", "dbo.Budgets");
            DropForeignKey("dbo.Budgets", "MonthlyBudgetId", "dbo.MonthlyBudgets");
            DropForeignKey("dbo.Transactions", "MonthlyBudget_Id", "dbo.MonthlyBudgets");
            DropForeignKey("dbo.MonthlyBudgets", "UserId", "dbo.Users");
            DropPrimaryKey("dbo.BudgetItems");
            DropPrimaryKey("dbo.Budgets");
            DropPrimaryKey("dbo.MonthlyBudgets");
            DropPrimaryKey("dbo.Transactions");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.BudgetItems", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"));
            AlterColumn("dbo.Budgets", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"));
            AlterColumn("dbo.MonthlyBudgets", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"));
            AlterColumn("dbo.Transactions", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"));
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"));
            AddPrimaryKey("dbo.BudgetItems", "Id");
            AddPrimaryKey("dbo.Budgets", "Id");
            AddPrimaryKey("dbo.MonthlyBudgets", "Id");
            AddPrimaryKey("dbo.Transactions", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            AddForeignKey("dbo.BudgetItems", "BudgetId", "dbo.Budgets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Budgets", "MonthlyBudgetId", "dbo.MonthlyBudgets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "MonthlyBudget_Id", "dbo.MonthlyBudgets", "Id");
            AddForeignKey("dbo.MonthlyBudgets", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonthlyBudgets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "MonthlyBudget_Id", "dbo.MonthlyBudgets");
            DropForeignKey("dbo.Budgets", "MonthlyBudgetId", "dbo.MonthlyBudgets");
            DropForeignKey("dbo.BudgetItems", "BudgetId", "dbo.Budgets");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Transactions");
            DropPrimaryKey("dbo.MonthlyBudgets");
            DropPrimaryKey("dbo.Budgets");
            DropPrimaryKey("dbo.BudgetItems");
            AlterColumn("dbo.Users", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Transactions", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.MonthlyBudgets", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Budgets", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.BudgetItems", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Transactions", "Id");
            AddPrimaryKey("dbo.MonthlyBudgets", "Id");
            AddPrimaryKey("dbo.Budgets", "Id");
            AddPrimaryKey("dbo.BudgetItems", "Id");
            AddForeignKey("dbo.MonthlyBudgets", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Transactions", "MonthlyBudget_Id", "dbo.MonthlyBudgets", "Id");
            AddForeignKey("dbo.Budgets", "MonthlyBudgetId", "dbo.MonthlyBudgets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BudgetItems", "BudgetId", "dbo.Budgets", "Id", cascadeDelete: true);
        }
    }
}
