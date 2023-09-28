using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace N01589651Assignment1.Controllers
{
    public class SquareController : ApiController
    {
        /// <summary>
        /// The method Get() will take integer id as a parameter and it is the input parameter which the user will pass
        /// while sending the api request. This will multiply the variable id with the id and gives the square of the number 
        /// which the user inputs.
        /// For eg: http://localhost/api/square/22 will output 484
        /// http://localhost/api/square/10 will output 100
        /// </summary>
        public int Get(int id)
        {
            return id * id;
        }
    }
}
