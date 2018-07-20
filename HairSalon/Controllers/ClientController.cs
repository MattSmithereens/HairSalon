using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet("new-client")]
        public ActionResult Create()
        {
            return View(Stylist.GetAll());
        }

        [HttpPost("new-client")]
        public ActionResult CreatePost()
        {
            string name = Request.Form["name"];
            string stylistId = Request.Form["stylistId"];
            int courseId = int.Parse(Request.Form["course"]);

            //DateTime date = Convert.ToDateTime(enrollDate);

            //Stylist newStylist = Stylist.Find(stylistId);
            //Client newClient = new Client(name, date);
            //newClient.Save();
            //newClient.AddStylist(newStylist);

            return RedirectToAction("ViewAll");
        }

        //[HttpGet("view-students")]
        //public ActionResult ViewAll()
        //{
        //    List<Student> allStudents = Student.GetAll();
        //    return View(allStudents);
        //}

        //[HttpGet("student/{id}/details")]
        //public ActionResult Details(int id)
        //{
        //    Student newStudent = Student.Find(id);
        //    return View(newStudent);
        //}

        //[HttpGet("student/{id}/update")]
        //public ActionResult Edit(int id)
        //{
        //    Student newStudent = Student.Find(id);
        //    return View(newStudent);
        //}

        //[HttpPost("student/{id}/update")]
        //public ActionResult EditDetails(int id)
        //{
        //    string newName = Request.Form["newName"];
        //    int courseId = int.Parse(Request.Form["newCourse"]);
        //    Course newCourse = Course.Find(courseId);
        //    Student newStudent = Student.Find(id);
        //    newStudent.Edit(newName);
        //    newStudent.AddCourse(newCourse);
        //    return RedirectToAction("ViewAll");
        //}

        //[HttpPost("course/{id}/delete")]
        //public ActionResult Delete(int id)
        //{
        //    Course newCourse = Course.Find(id);
        //    newCourse.Delete();
        //    return RedirectToAction("ViewAll");
        //}
    }
}