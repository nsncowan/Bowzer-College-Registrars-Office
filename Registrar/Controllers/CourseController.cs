using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using System.Collections.Generic;
using System.Linq; // allows for some List functionality - like ToList()
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Registrar.Controllers
{
  public class CourseController : Controller
  {
    private readonly RegistrarContext _db;
    public CourseController(RegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Course> model = _db.Courses.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Course course)
    {
      _db.Courses.Add(course);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Course thisCourse = _db.Courses
                              .Include(courses => courses.JoinEntities)
                              .ThenInclude(join => join.Student)
                              .FirstOrDefault(Course => Course.CourseId == id);
      return View(thisCourse);
    }

    public ActionResult AddStudent(int id)
    {
      Course thisCourse = _db.Courses.FirstOrDefault(courses => courses.CourseId == id);
      ViewBag.StudentId = new SelectList(_db.Students, "StudentId", "Name");
      return View(thisCourse);
    }

    [HttpPost]
    public ActionResult AddStudent(Course course, int studentId)
    {
      #nullable enable
      StudentCourse? joinEntity = _db.StudentCourses.FirstOrDefault(studentCourse => (studentCourse.StudentId == studentId && studentCourse.CourseId == course.CourseId));
      #nullable disable
      if(joinEntity == null && studentId != 0)
      {
        _db.StudentCourses.Add(new StudentCourse() {CourseId = course.CourseId, StudentId = studentId});
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new {id = course.CourseId});
    }
  }
}
