using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
  class Subject
  {
    public int SubjectId { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }

    //navigation property
    public virtual ICollection<Programme> Programmes { get; set; }
  }
}
