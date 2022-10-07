using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
  class LazyLoading
  {
    static void Main(string[] args)
    {
      EFDBEntities db = new EFDBEntities();

      foreach (City city in db.Cities)
      {
        Console.WriteLine("City Name {0}", city.CityName);
        Console.WriteLine("-----------------------------");
        foreach (Area area in city.Areas)
        {
          Console.WriteLine(area.AreaName);
        }
      }
      Console.ReadLine();
    }
  }
}
