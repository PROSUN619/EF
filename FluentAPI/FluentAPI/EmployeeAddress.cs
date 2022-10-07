using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
  class EmployeeAddress
  {
    public int EmployeeId { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string Zipcode { get; set; }

    //navigation property
    public virtual Employee Employee { get; set; }
  }
}
