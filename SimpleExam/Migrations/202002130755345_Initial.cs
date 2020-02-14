namespace SimpleExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonId = c.String(maxLength: 3, fixedLength: true, unicode: false),
                        StudentId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Mark = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lessons", t => t.LessonId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.LessonId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 3, fixedLength: true, unicode: false),
                        Name = c.String(nullable: false, maxLength: 30, unicode: false),
                        Class = c.Byte(nullable: false),
                        TeacherName = c.String(nullable: false, maxLength: 20, unicode: false),
                        TeacherLastName = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30, unicode: false),
                        LastName = c.String(maxLength: 30, unicode: false),
                        Class = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Exams", "LessonId", "dbo.Lessons");
            DropIndex("dbo.Exams", new[] { "StudentId" });
            DropIndex("dbo.Exams", new[] { "LessonId" });
            DropTable("dbo.Students");
            DropTable("dbo.Lessons");
            DropTable("dbo.Exams");
        }
    }
}
