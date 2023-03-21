using System.ComponentModel.DataAnnotations.Schema;

namespace Registrar.Models
{
  public class StudentCourse
  {
    public int StudentCourseId { get; set; }

    public int StudentId { get; set; }

    [ForeignKey("StudentId")]
    public Student Student { get; set; } //navigation property. property that includes a refrence between related entities (item and tag)

    public int CourseId { get; set; }

    [ForeignKey("CourseId")]
    public Course Course { get; set; }

  }
}