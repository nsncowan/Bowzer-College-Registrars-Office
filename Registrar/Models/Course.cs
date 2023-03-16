using System.Collections.Generic;
using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace Registrar.Models
{
  public class Course
  {
    public int CourseId { get; set; }
    public string Name { get; set; }

    public string CourseNum { get; set; }
    public List<StudentCourse> JoinEntities {get;}

  }
}