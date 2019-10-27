namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class karim_entity_update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Quiz_QuizId", "dbo.Quizs");
            DropIndex("dbo.Questions", new[] { "Quiz_QuizId" });
            RenameColumn(table: "dbo.Questions", name: "Quiz_QuizId", newName: "QuizId");
            AlterColumn("dbo.Questions", "QuizId", c => c.Int(nullable: false));
            CreateIndex("dbo.Questions", "QuizId");
            AddForeignKey("dbo.Questions", "QuizId", "dbo.Quizs", "QuizId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "QuizId", "dbo.Quizs");
            DropIndex("dbo.Questions", new[] { "QuizId" });
            AlterColumn("dbo.Questions", "QuizId", c => c.Int());
            RenameColumn(table: "dbo.Questions", name: "QuizId", newName: "Quiz_QuizId");
            CreateIndex("dbo.Questions", "Quiz_QuizId");
            AddForeignKey("dbo.Questions", "Quiz_QuizId", "dbo.Quizs", "QuizId");
        }
    }
}
