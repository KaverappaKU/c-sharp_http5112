using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace N01589651Assignment1.Controllers
{
    public class GreetingController : ApiController
    {
        /// <summary>
        /// The method Get() will take input id as the argument which the user will input while sending the api request.
        /// For eg: http://localhost/api/Greeting/3 will give us the output "Greeting to 3 people"
        /// </summary>

        public string Get(int id)
        {
            return "Greetings to " + id + " people";
        }

        /// <summary>
        /// The method Post() is only accessed by the command prompt. In the command prompt use the curl command to see the message "Hello World!".
        /// curl -d "" http://localhost:49717/api/Greeting/3
        /// </summary>
        public string Post()
        {
            return "Hello World!";
        }
    }
}
