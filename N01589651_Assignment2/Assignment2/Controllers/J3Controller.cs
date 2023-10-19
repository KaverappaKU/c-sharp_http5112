using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J3Controller : ApiController
    {
        /// <summary>
        /// Gives the Sumac sequence of the two numbers entered.The difference between two entered numbers will be 
        /// the input for the next calculation, so t2 will become the minuend and t3 will become the subtahend.
        /// This will be carried until t2 becomes negative.The total number of calculation possible we get a 
        /// negative number gives the Sumac sequence.
        /// For eg: 120 and 71, the Sumac sequence will be 120, 71, 49, 22, 27. So the length of Sumac sequence is 5.
        /// </summary>
        /// <param name="t1">Denotes the first value</param>
        /// <param name="t2">Denotes the second value</param>
        /// <returns>
        /// GET /api/j3/sumacsequence/120/71 -> Length of Sumac sequence: 5
        /// GET /api/j3/sumacsequence/30/40 -> Length of Sumac sequence: 2
        /// GET /api/j3/sumacsequence/100/-1 -> Input proper values
        /// GET /api/j3/sumacsequence/52000/2000 -> Input proper values
        /// </returns>

        [HttpGet]
        [Route("api/J3/SumacSequence/{t1}/{t2}")]
        public string SumacSequence(int t1, int t2)
        {
            int temp;
            int sequence = 1;
            if (t1 < 10000 && t2 > 0)
            {
                while (t2 >= 0)
                {
                    temp = t1;
                    t1 = t2;
                    t2 = temp - t2;
                    sequence++;
                }
                return "Length of Sumac sequence: " + sequence;
            }
            return "Input proper values";
        }
    }
}
