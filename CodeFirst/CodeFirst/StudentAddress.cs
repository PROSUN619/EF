using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
  class StudentAddress
  {
    [Key,ForeignKey("Student")] // mapped explicitly for 1 to 1 relationship
    public int StudentId { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    [NotMapped]
    public string Zipcode { get; set; }

    //navigation property
    public virtual Student Student { get; set; }
  }
}
