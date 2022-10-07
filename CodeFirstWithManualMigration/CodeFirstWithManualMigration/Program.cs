using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstWithManualMigration
{
  internal class Program
  {
    static void Main(string[] args)
    {
      try
      {
        MyDBContext myDBContext = new MyDBContext();
        Programme p = new Programme();
        p.Id = 3;
        p.Title = "M.Tech";
        p.Duration = 2;
        p.Fees = 250000;
        myDBContext.Programmes.Add(p);
        myDBContext.SaveChanges();
        Console.WriteLine("DB Created...");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

  }
}
