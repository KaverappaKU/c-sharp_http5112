using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CumulativeProject.Models;

namespace CumulativeProject.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        //GET : /Teacher/ListTeachers/{SearchKey?}
        public ActionResult ListTeachers(string SearchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
            return View(Teachers);
        }

        //GET : /Teacher/ShowTeachers/{id}
        public ActionResult ShowTeachers(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);
            return View(NewTeacher);
        }

        // Function which goes to Teacher View 
        // Views/Teacher/New.cshtml
        public ActionResult New()
        {
            return View();
        }

        // Function to add new teachers to database
        // Adds new teacher details from the form and returns to list teachers 
        [HttpPost]
        public ActionResult Add(string TeacherFname, string TeacherLname, string EmployeeNumber, DateTime HireDate, Decimal Salary) { 

            // Creating teacher objects and assigning parameters to that object
            Teacher NewTeacher = new Teacher();

            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.HireDate = HireDate;
            NewTeacher.Salary = Salary;

            //Creating an object for teacher data controller inorder to add the new data
            TeacherDataController controller = new TeacherDataController();

            // Adding the record 
            controller.AddTeacher(NewTeacher);

            // returns to the list teachers page back
            return RedirectToAction("ListTeachers");
        }

        //POST : /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("ListTeachers");
        }

        //GET : /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }

        // GET Teacher/UpdateTeacher/{id}
        public ActionResult UpdateTeacher(int id)
        {
            try
            {
                TeacherDataController controller = new TeacherDataController();
                Teacher SelectedTeacher = controller.FindTeacher(id);
                ViewBag.HireDate = Convert.ToDateTime(SelectedTeacher.HireDate).ToString("yyyy-MM-dd");
                return View(SelectedTeacher);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error", "Home");
            }

        }
    }
}