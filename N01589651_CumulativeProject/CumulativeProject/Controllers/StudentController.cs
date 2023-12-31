﻿using CumulativeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CumulativeProject.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        //GET : /Student/ListStudents
        public ActionResult ListStudents()
        {
            StudentDataController controller = new StudentDataController();
            IEnumerable<Student> Students = controller.ListStudents();
            return View(Students);
        }

        //GET : /Student/ShowStudents/{id}
        public ActionResult ShowStudents(int id)
        {
            StudentDataController controller = new StudentDataController();
            Student NewStudent = controller.FindStudent(id);
            return View(NewStudent);
        }
    }
}