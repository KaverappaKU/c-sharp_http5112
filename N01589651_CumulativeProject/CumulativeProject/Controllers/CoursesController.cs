using CumulativeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CumulativeProject.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }
        //GET : /Courses/ListCourses
        /// <summary>
        /// This functions is used to list the Courses
        /// </summary>
        /// <returns>
        /// Returns list of teachers for the View
        /// </returns>
        public ActionResult ListCourses()
        {
            CoursesDataController controller = new CoursesDataController();
            IEnumerable<Courses> Courses = controller.ListCourses();
            return View(Courses);
        }

        //GET : /Courses/ShowCourses/{id}

        public ActionResult ShowCourses(int id)
        {
            CoursesDataController controller = new CoursesDataController();
            Courses NewCourses = controller.FindCourses(id);
            return View(NewCourses);
        }
    }
}