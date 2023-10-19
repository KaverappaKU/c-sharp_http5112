using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Schema;

namespace Assignment2.Controllers
{
    public class J2Controller : ApiController
    {
        /// <summary>
        /// To get the shifted sum of a number. Shifting a number means adding a 0 to the number, and add that to the original number.
        /// For eg: 12 is the number, after shifting it will be 120, so 120 + 12 will give you 132.
        /// </summary>
        /// <param name="N">Denotes the number to be shifted, this should be a positive integer between 1 and 10000</param>
        /// <param name="k">Denotes the number of times N needs to be shifted, this should be a positive integer between 0 and 5</param>
        /// <returns>
        /// GET api/j2/shiftysum/12/1 -> Shifty Sum: 132
        /// GET api/j2/shiftysum/12/3 -> Shifty Sum: 13332
        /// GET api/j2/shiftysum/12/6 -> Input proper values
        /// GET /api/j2/shiftysum/12000/2 -> Input proper values
        /// </returns>

        [HttpGet]
        [Route("api/J2/ShiftySum/{N}/{k}")]
        public string ShiftySum(int N, int k)
        {
            double shiftySum = 0;
            shiftySum += N;
            if (N>=1 && N<=10000 && k>=0 && k <= 5)
            {
                for (double i = 1; i<=k; i++)
                {
                    shiftySum += N * Math.Pow(10, i);
                }
                return "Shifty Sum: " + shiftySum;
            }
            return "Input proper values";
        }
    }
}
