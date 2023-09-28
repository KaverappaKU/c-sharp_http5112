using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace N01589651Assignment1.Controllers
{
    public class AddTenController : ApiController
    {
        /// <summary>
        /// The method Get() will take integer id as a parameter and it is the input parameter which the user will pass
        /// while sending the api request. This will add the user with the integer 10 and output the added number.
        /// For eg: http://localhost/api/addten/29 will output 39
        /// http://localhost/api/addten/-20 will output -10
        /// </summary>
        public int Get(int id)
        {
            return id + 10;
        }
    }
}
