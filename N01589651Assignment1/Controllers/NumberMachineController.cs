using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


// Here assuming we take the input as 10
// add = 10 + 5 = 15
// sub = 10 - 5 = 5
// mul = 10 * 5 = 50
// div = 10 / 5 = 2
// total = 15 + 5 + 50 + 2 = 72

namespace N01589651Assignment1.Controllers
{
    public class NumberMachineController : ApiController
    {
        /// <summary>
        /// The method Get() will take only one parameter id as the input.
        /// We test all the airthmetic operations like addition(+), subtraction(-), multiplication(*)
        /// division(/) and modulus(%) in one statement and assign it to the variable total.
        /// For eg: When we send the api request http://localhost/api/numbermachine/10,
        /// the output will be "The total of all mathematical operators is 20"
        /// After substituting id = 10 in the equation.
        /// 10 + 10 - (((10*10) / 10) % 10) will give the output 20.
        /// Likewise, http://localhost/api/numbermachine/-5 will give "The total of all mathematical operators is -10"
        /// and Likewise, http://localhost/api/numbermachine/30 will give "The total of all mathematical operators is 60"
        /// </summary>
        public string Get(int id)
        {
            int output = id + id - id * id / id % id;
            return "The output of all mathematical operators is " +output;
        }
    }
}
