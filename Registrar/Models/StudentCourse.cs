namespace Registrar.Models
{
  public class StudentCourse
  {
    public int StudentCourseId { get; set; }
    public int StudentId { get; set; }

    public Student Student { get; set; } //navigation property. property that includes a refrence between related entities (item and tag)

    public int CourseId { get; set; }

    public Course Course { get; set; }
  }
}