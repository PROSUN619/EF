using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
  internal class Program
  {
    static void Main(string[] args)
    {

      try
      {
        MyDBContext myDBContext = new MyDBContext();
        Department department = new Department();
        department.DeptId = 1;
        department.DeptName = "Developement";
        myDBContext.Departments.Add(department);
        myDBContext.SaveChanges();
        Console.WriteLine("Database Created");
      }
      catch (Exception e)
      {

        Console.WriteLine(e.Message);
      }
      
    }

  }
}
