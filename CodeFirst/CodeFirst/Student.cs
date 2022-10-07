using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
  class Student
  {
    [Key]
    public int RollNo { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsBonafied { get; set; }
    public string ContactNo { get; set; }
    // [ForeignKey("Programme")]
    public int ProgrammeId { get; set; }

    //navigation property
    [ForeignKey("ProgrammeId")]
    public virtual Programme Programme { get; set; }
    public virtual StudentAddress StudentAddress { get; set; }
  }
}
