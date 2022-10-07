using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst2
{
  [Table("Courses")] //Programme will map to Courses Table
  class Programme
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)] //Make Identity false
    public int Id { get; set; }
    [Required]
    [Column("CourseName",TypeName ="varchar")]
    [MaxLength(50)]
    public string Title { get; set; }
    public int Duration { get; set; }
    public float Fees { get; set; }

    //navigation property
    public virtual ICollection<Student> Students { get; set; }
    public virtual ICollection<Subject> Subjects { get; set; }

  }
}
