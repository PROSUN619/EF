using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        MyDBContext myDBContext = new MyDBContext();
        Programme p = new Programme();
        p.Id = 1;
        p.Title = "B.Tech";
        p.Duration = 4;
        p.Fees = 500000;
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
