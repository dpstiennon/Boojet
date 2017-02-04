namespace Boojet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MoneyItems", newName: "Transactions");
            CreateTable(
                "dbo.BudgetItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BudgetId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Budgets", t => t.BudgetId, cascadeDelete: true)
                .Index(t => t.BudgetId);
            
            CreateTable(
                "dbo.Budgets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Target = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sequence = c.Int(nullable: false),
                        MonthlyBudgetId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MonthlyBudgets", t => t.MonthlyBudgetId, cascadeDelete: true)
                .Index(t => t.MonthlyBudgetId);
            
            CreateTable(
                "dbo.MonthlyBudgets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Transactions", "Sequence", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "MonthlyBudget_Id", c => c.Guid());
            CreateIndex("dbo.Transactions", "MonthlyBudget_Id");
            AddForeignKey("dbo.Transactions", "MonthlyBudget_Id", "dbo.MonthlyBudgets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonthlyBudgets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "MonthlyBudget_Id", "dbo.MonthlyBudgets");
            DropForeignKey("dbo.Budgets", "MonthlyBudgetId", "dbo.MonthlyBudgets");
            DropForeignKey("dbo.BudgetItems", "BudgetId", "dbo.Budgets");
            DropIndex("dbo.Transactions", new[] { "MonthlyBudget_Id" });
            DropIndex("dbo.MonthlyBudgets", new[] { "UserId" });
            DropIndex("dbo.Budgets", new[] { "MonthlyBudgetId" });
            DropIndex("dbo.BudgetItems", new[] { "BudgetId" });
            DropColumn("dbo.Transactions", "MonthlyBudget_Id");
            DropColumn("dbo.Transactions", "Sequence");
            DropTable("dbo.Users");
            DropTable("dbo.MonthlyBudgets");
            DropTable("dbo.Budgets");
            DropTable("dbo.BudgetItems");
            RenameTable(name: "dbo.Transactions", newName: "MoneyItems");
        }
    }
}
