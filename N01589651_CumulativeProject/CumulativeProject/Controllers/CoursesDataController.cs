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
    public class CoursesDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDB School = new SchoolDB();
        //This Controller Will access the Courses table of our School database.
        /// <summary>
        /// Returns a list of Courses in the system
        /// </summary>
        /// <returns>
        /// A list of Courses objects.
        /// </returns>
        /// <example>GET api/Courses/ListCourses -> http5111



        [HttpGet]
        [Route("api/Courses/listCourses")]
        public IEnumerable<Courses> ListCourses()
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Classes";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Courses
            List<Courses> Courses = new List<Courses> { };


            while (ResultSet.Read())
            {
                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                string ClassCode = ResultSet["classcode"].ToString();
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = ResultSet["classname"].ToString();

                Courses NewCourses = new Courses
                {
                    ClassId = ClassId,
                    ClassCode = ClassCode,
                    TeacherId = TeacherId,
                    StartDate = StartDate,
                    FinishDate = FinishDate,
                    ClassName = ClassName
                };

                //Add the Course Name to the List
                Courses.Add(NewCourses);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of Course names
            return Courses;
        }

        /// <summary>
        /// Returns class details from the database by specifying the primary key classid
        /// </summary>
        /// <param name="id">the class ID in the database</param>
        /// <returns>A class object</returns>
        /// Example: /Courses/ShowCourses/1
        /// The response would look like this
        /// {
        ///     "ClassId": "1",
        ///     "ClassCode": "http5101"
        ///     "TeacherId": "1",
        ///     "ClassName": "Web Application Development",
        ///     "StartDate": "9/4/2018 12:00:00 AM",
        ///     "FinishDate": "12/14/2018 12:00:00 AM"
        /// }

        [HttpGet]
        [Route("api/Courses/showCourses")]
        public Courses FindCourses(int id)
        {
            Courses NewCourses = new Courses();

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Classes where classid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                string ClassCode = ResultSet["classcode"].ToString();
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string ClassName = ResultSet["classname"].ToString();

                NewCourses.ClassId = ClassId;
                NewCourses.ClassCode = ClassCode;
                NewCourses.TeacherId = TeacherId;
                NewCourses.StartDate = StartDate;
                NewCourses.FinishDate = FinishDate;
                NewCourses.ClassName = ClassName;
            }
            return NewCourses;
        }
    }
}
