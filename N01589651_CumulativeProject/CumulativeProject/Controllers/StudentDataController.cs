using CumulativeProject.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CumulativeProject.Controllers
{
    // The database context class which allows us to access our MySQL Database.
    public class StudentDataController : ApiController
    {
        private SchoolDB School = new SchoolDB();
        //This Controller Will access the Student table of our School database.
        /// <summary>
        /// Returns a list of Students in the system
        /// </summary>
        /// <example>GET api/Students/ListStudents</example>
        /// <returns>
        /// A list of Student objects.
        /// </returns>
        /// Example: api/Student/ListStudents -> John Doe

        [HttpGet]
        [Route("api/Student/listStudents")]
        public IEnumerable<Student> ListStudents()
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Students";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Students
            List<Student> Students = new List<Student> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                string StudentFname = ResultSet["studentfname"].ToString();
                string StudentLname = ResultSet["studentlname"].ToString();
                string StudentNumber = ResultSet["studentnumber"].ToString();
                DateTime EnrolDate = (DateTime)ResultSet["enroldate"];


                Student NewStudent = new Student
                {
                    StudentId = StudentId,
                    StudentFname = StudentFname,
                    StudentLname = StudentLname,
                    StudentNumber = StudentNumber,
                    EnrolDate = EnrolDate
                };

                //Add the Student Name to the List
                Students.Add(NewStudent);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of Student names
            return Students;
        }

        /// <summary>
        /// Returns student details from the database by specifying the primary key studentid
        /// </summary>
        /// <param name="id">the student ID in the database</param>
        /// <returns>A student object</returns>
        /// The response would look this
        /// {   
        ///     "StudentId": "1",
        ///     "StudentFname": "John",
        ///     "StudentLname": "Doe",
        ///     "StudentNumber": "N1781",
        ///     "EnrolDate": "6/18/2018 12:00:00 AM"
        /// }

        [HttpGet]
        [Route("api/Student/showStudents")]
        public Student FindStudent(int id)
        {
            Student NewStudent = new Student();

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Students where studentid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                string StudentFname = ResultSet["studentfname"].ToString();
                string StudentLname = ResultSet["studentlname"].ToString();
                string StudentNumber = ResultSet["studentnumber"].ToString();
                DateTime EnrolDate = (DateTime)ResultSet["enroldate"];

                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrolDate = EnrolDate;
            }
            return NewStudent;
        }

    }
}

