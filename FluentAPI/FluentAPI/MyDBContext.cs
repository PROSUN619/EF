using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluentAPI
{
  class MyDBContext : DbContext
  {
    public MyDBContext() : base("name=MyDBConnectionString")
    {

    }

    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
    public virtual DbSet<Project> Projects { get; set; }
    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      //tablename mapping
      modelBuilder.Entity<Department>().ToTable("Dept");

      //primary key specification
      modelBuilder.Entity<Department>().HasKey(d => d.DeptId);

      //property configuration
      modelBuilder.Entity<Employee>().Property(e => e.EmployeeId)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

      modelBuilder.Entity<Employee>().Property(e => e.EmpName)
        .HasColumnName("Ename")
        .IsRequired()
        .HasMaxLength(50)
        .HasColumnType("varchar");

      modelBuilder.Entity<Employee>().Property(e => e.PrimaryContact)
        .IsRequired()
        .HasMaxLength(10);

      //1 2 1 relationship between employee and employee Address

      modelBuilder.Entity<EmployeeAddress>().HasKey(ea => ea.EmployeeId);

      modelBuilder.Entity<Employee>()
        .HasOptional(e => e.EmployeeAddress)
        .WithRequired(ea => ea.Employee);


      //1 to many relationship between Department and Employee
      modelBuilder.Entity<Department>().HasMany(d => d.Employees)
        .WithRequired(e => e.Department)
        .HasForeignKey(e => e.DeptId)
        .WillCascadeOnDelete(false);

      //1 to many relationship between Team and Employee where team is optional for employee
      modelBuilder.Entity<Team>().HasMany(t => t.Employees)
        .WithOptional(e => e.Team)
        .HasForeignKey(e => e.TeamId);

      //many to many relationship between employee and projects

      modelBuilder.Entity<Employee>().HasMany(e => e.Projects)
        .WithMany(p => p.Employees)
        .Map(ep => 
        {
          ep.MapLeftKey("EmployeeId");
          ep.MapRightKey("ProjectId");
          ep.ToTable("ProjectsOfEmployees");
        });

    }

  }
}
