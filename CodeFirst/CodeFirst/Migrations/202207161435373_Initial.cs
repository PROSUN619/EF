namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Programmes", newName: "Courses");
            DropForeignKey("dbo.Students", "Programme_Id", "dbo.Programmes");
            DropForeignKey("dbo.SubjectProgrammes", "Programme_Id", "dbo.Programmes");
            DropIndex("dbo.Students", new[] { "Programme_Id" });
            RenameColumn(table: "dbo.Courses", name: "Title", newName: "CourseName");
            RenameColumn(table: "dbo.Students", name: "Programme_Id", newName: "ProgrammeId");
            DropPrimaryKey("dbo.Courses");
            DropPrimaryKey("dbo.Students");
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
            
            AddColumn("dbo.Students", "RollNo", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Courses", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Courses", "CourseName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Students", "ProgrammeId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Courses", "Id");
            AddPrimaryKey("dbo.Students", "RollNo");
            CreateIndex("dbo.Students", "ProgrammeId");
            AddForeignKey("dbo.Students", "ProgrammeId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubjectProgrammes", "Programme_Id", "dbo.Courses", "Id", cascadeDelete: true);
            DropColumn("dbo.Students", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "StudentId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.SubjectProgrammes", "Programme_Id", "dbo.Courses");
            DropForeignKey("dbo.Students", "ProgrammeId", "dbo.Courses");
            DropForeignKey("dbo.StudentAddresses", "StudentId", "dbo.Students");
            DropIndex("dbo.StudentAddresses", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "ProgrammeId" });
            DropPrimaryKey("dbo.Students");
            DropPrimaryKey("dbo.Courses");
            AlterColumn("dbo.Students", "ProgrammeId", c => c.Int());
            AlterColumn("dbo.Courses", "CourseName", c => c.String());
            AlterColumn("dbo.Courses", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Students", "RollNo");
            DropTable("dbo.StudentAddresses");
            AddPrimaryKey("dbo.Students", "StudentId");
            AddPrimaryKey("dbo.Courses", "Id");
            RenameColumn(table: "dbo.Students", name: "ProgrammeId", newName: "Programme_Id");
            RenameColumn(table: "dbo.Courses", name: "CourseName", newName: "Title");
            CreateIndex("dbo.Students", "Programme_Id");
            AddForeignKey("dbo.SubjectProgrammes", "Programme_Id", "dbo.Programmes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "Programme_Id", "dbo.Programmes", "Id");
            RenameTable(name: "dbo.Courses", newName: "Programmes");
        }
    }
}
