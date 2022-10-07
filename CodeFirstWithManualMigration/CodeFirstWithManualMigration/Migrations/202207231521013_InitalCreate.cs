namespace CodeFirstWithManualMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CourseName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Duration = c.Int(nullable: false),
                        Fees = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        RollNo = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        IsBonafied = c.Boolean(nullable: false),
                        ContactNo = c.String(),
                        EmailId = c.String(defaultValue:"test@test.com"),
                        ProgrammeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RollNo)
                .ForeignKey("dbo.Courses", t => t.ProgrammeId, cascadeDelete: true)
                .Index(t => t.ProgrammeId);
            
            CreateTable(
                "dbo.StudentAddresses",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Marks = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        Contact = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.SubjectProgrammes",
                c => new
                    {
                        Subject_SubjectId = c.Int(nullable: false),
                        Programme_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_SubjectId, t.Programme_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Programme_Id, cascadeDelete: true)
                .Index(t => t.Subject_SubjectId)
                .Index(t => t.Programme_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectProgrammes", "Programme_Id", "dbo.Courses");
            DropForeignKey("dbo.SubjectProgrammes", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.StudentAddresses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "ProgrammeId", "dbo.Courses");
            DropIndex("dbo.SubjectProgrammes", new[] { "Programme_Id" });
            DropIndex("dbo.SubjectProgrammes", new[] { "Subject_SubjectId" });
            DropIndex("dbo.StudentAddresses", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "ProgrammeId" });
            DropTable("dbo.SubjectProgrammes");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.StudentAddresses");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
