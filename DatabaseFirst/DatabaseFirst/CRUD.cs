using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
  class CRUD
  {
    

    static void Main(string[] args)
    {
      EFDBEntities db = new EFDBEntities();
      Area areaObj = new Area();
      int opt;
      do
      {
        Console.WriteLine("1. New Record\n2. Display Record\n3.Update Record\n4.Delete Record\n5.Exit");
        Console.Write("Enter Option:");
        opt = Convert.ToInt32(Console.ReadLine());

        switch (opt)
        {
          case 1: //insert New Record
            Console.WriteLine("Enter Area Name\tCity Id\tPin Code");
            areaObj.AreaName =  Console.ReadLine();
            areaObj.CityId = Convert.ToInt32(Console.ReadLine());
            areaObj.PinCode = Console.ReadLine();
            db.Areas.Add(areaObj);
            db.SaveChanges();
            break;
          case 2: //Display  Record

            //foreach (Area area in db.Areas)
            foreach (Area area in db.SelectArea())
            {
              Console.WriteLine("{0},\t{1},\t{2},\t{3}\t",area.AreaId,area.AreaName,area.PinCode,area.City.CityName);
            }
            break;
          case 3: //Update New Record
            Console.WriteLine("Please Enter Id");
            areaObj = db.Areas.Find(Convert.ToInt32(Console.ReadLine()));
            if (areaObj == null)
              Console.WriteLine("Invalid Id");
            else
            {
              Console.WriteLine("Enter Area Name\tCity Id\tPin Code");
              areaObj.AreaName = Console.ReadLine();
              areaObj.CityId = Convert.ToInt32(Console.ReadLine());
              areaObj.PinCode = Console.ReadLine();
              db.SaveChanges();
            }
            break;
          case 4: //Delete Record
            Console.WriteLine("Please Enter Id");
            areaObj = db.Areas.Find(Convert.ToInt32(Console.ReadLine()));
            if (areaObj == null)
              Console.WriteLine("Invalid Id");
            else
            {
              db.Areas.Remove(areaObj);
              db.SaveChanges();
            }
            break;
          default:
            break;
        }
      }
      while (opt != 5);
    }
  }
}
