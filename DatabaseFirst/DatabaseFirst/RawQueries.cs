using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
  class RawQueries
  {
    static void Main(string[] args)
    {
      //sql query for entity types

      EFDBEntities db = new EFDBEntities();

      SqlParameter sqlParameter = new SqlParameter();
      sqlParameter.ParameterName = "@cityid";
      sqlParameter.Value = 2;
      sqlParameter.SqlDbType = System.Data.SqlDbType.Int;

      IEnumerable<Area>  areas = 
          db.Areas.SqlQuery("select * from Areas where CityId = @cityid", sqlParameter);

      foreach (Area area in areas)
      {
        Console.WriteLine("{0},\t{1},\t,{2}",area.AreaId, area.AreaName, area.City.CityName);
      }

      //sql query for non entity types

      Console.WriteLine("sql query for non entity types");
     IEnumerable<MyArea> myAreas = 
        db.Database.SqlQuery<MyArea>("select * from Areas where CityId =2");

      foreach (MyArea area in myAreas)
      {
        Console.WriteLine("{0},\t{1}", area.AreaName, area.PinCode);
      }


      //sql command for DML

      Console.WriteLine("sql command for DML");
      int result = 
        db.Database.ExecuteSqlCommand("update Areas set PinCode = '111111' where AreaId = 2");

      if (result > 0)
        Console.WriteLine("Update Successful");
      else
        Console.WriteLine("Update Unsuccessful");

    }
  }
}
