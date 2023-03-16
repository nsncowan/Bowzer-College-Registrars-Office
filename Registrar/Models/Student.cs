using System.Collections.Generic;
using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace Registrar.Models
{
  public class Student
  {
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string DateOE { get; set; }
    public List<StudentCourse> JoinEntities {get;}

  }
}