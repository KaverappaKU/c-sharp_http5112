using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J1Controller : ApiController
    {
        /// <summary>
        /// Find out how many cup cakes are left over after distributing it among 28 students.
        /// </summary>
        /// <param name="R">Number of regular boxes</param>
        /// <param name="S">Number of small boxes</param>
        /// <returns>
        /// GET api/j1/cupcakeparty/2/4 -> There are 0 Cup Cakes left
        /// GET api/j1/cupcakeparty/2/5 -> There are 3 Cup Cakes left
        /// </returns>

        [HttpGet]
        [Route("api/J1/CupcakeParty/{R}/{S}")]
        public string CupcakeParty(int R, int S)
        {
            int regularBox = 8;
            int smallBox = 3;
            int students = 28;
            int leftOverCupCakes = 0;
            if (R >= 0 && S >= 0)
            {
                int totalCupCakes = (R * regularBox) + (S * smallBox);
                leftOverCupCakes = totalCupCakes - students;
            }
            return "There are " + leftOverCupCakes + " Cup Cakes left";
        }
    }
}
