using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
  class Department
  {
    public int DeptId { get; set; }
    public string DeptName { get; set; }

    //navigation property
    public virtual ICollection<Employee> Employees { get; set; }
  }
}
