using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using System.Collections.Generic;
using System.Linq; // allows for some List functionality - like ToList()
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Registrar.Controllers
{
  public class StudentController : Controller
  {
    private readonly RegistrarContext _db;
    public StudentController(RegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Students.ToList());
    }

    public ActionResult Details(int id)
    {
      Student thisStudent = _db.Students
                                      .Include(student => student.JoinEntities)
                                      .ThenInclude(studentCourse => studentCourse.Course)
                                      .FirstOrDefault(student => student.StudentId == id);
      ViewBag.PassFail = new SelectList(_db.StudentCourses, "StudentCourseId", "PassFail");
      return View(thisStudent);
    }

    [HttpPost, ActionName("Details")]
    public ActionResult SetPassFail(int id)
    {
      StudentCourse thisStudentCourse = _db.StudentCourses.FirstOrDefault(thisStudentCourse => thisStudentCourse.StudentCourseId == id);
      Student thisStudent = _db.Students.FirstOrDefault(thisStudent => thisStudent.StudentId == thisStudentCourse.StudentId);
      if(thisStudentCourse.PassFail == false)
      {
      thisStudentCourse.PassFail = true;
      } else {
      thisStudentCourse.PassFail = false;
      }
      // _db.StudentCourses.Update(thisStudentCourse);
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = thisStudent.StudentId});
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Student student)
    {
      _db.Students.Add(student);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddCourse(int id)
    {
      Student thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
      return View(thisStudent);
    }
     
    [HttpPost]
    public ActionResult AddCourse(Student student, int courseId)
    {
       #nullable enable
       StudentCourse? joinEntity = _db.StudentCourses.FirstOrDefault(studentCourse => (studentCourse.CourseId == courseId && studentCourse.StudentId == student.StudentId));
       #nullable disable
       if(joinEntity == null && courseId !=0)
       {
        _db.StudentCourses.Add(new StudentCourse() {CourseId = courseId, StudentId = student.StudentId});
        _db.SaveChanges();
       }
       return RedirectToAction("Details", new { id = student.StudentId});
    }

    public ActionResult Edit(int id)
    {
      Student thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult Edit(Student student)
    {
      _db.Students.Update(student);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // public ActionResult Delete(int id)
    // {

    // }

    // [HttpPost, ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {

    // }

    // [HttpPost]
    // public ActionResult DeleteJoin(int joinId)
    // {

    // }
  }
}
