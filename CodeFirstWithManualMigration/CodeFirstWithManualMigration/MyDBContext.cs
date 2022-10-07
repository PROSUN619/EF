using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstWithManualMigration
{
  class MyDBContext : DbContext
  {
    public MyDBContext() : base("name=MyDBConnectionString")
    {
      //below code drop database create new one if schema (i have added email id to student entity) change
      // Database.SetInitializer<MyDBContext>(new DropCreateDatabaseIfModelChanges<MyDBContext>());
      //Database.SetInitializer<MyDBContext>(new MigrateDatabaseToLatestVersion<MyDBContext, Configuration>());
    }

    public virtual DbSet<Programme> Programmes { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<StudentAddress> StudentAddresses { get; set; }
    public virtual DbSet<Subject> Subjects { get; set; }
    public virtual DbSet<Teacher> Teachers { get; set; }
  }
}
