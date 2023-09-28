using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace N01589651Assignment1.Controllers
{
    public class HostingCostController : ApiController
    {
        /// <summary>
        /// This code works for all the non-negative inputs.
        /// How I approached the problem?
        /// As most of the calculations were in the question itself, I just disected the problem. 
        /// At first I thought of using conditional statement if..else if but realized it wouldn't work dynamically
        /// as we do not know what the user will input.
        /// So we have a variable daysPerFortnight which is assigned to 14 which means 14 days per fortnight.
        /// The fortnights calculation is (id / daysPerFortnight) + 1. This will give the exact fortnight.
        /// Next based on the input user gives, we calculate the how many fortnights. 
        /// We have static varaibles like chargesForFortnight, daysPerFortnight, hst and percentage whose value will not change.
        /// Then we just substitute all these values in the formula.
        /// For eg: if you send this api request http://localhost/api/HostingCost/28,
        /// The output will be "3 fortnights at $5.50/FN = $16.5 CAD" "HST 13% = $2.145 CAD" "Total = $18.645 CAD"
        /// </summary>

        public string Get(int id)
        {
            int daysPerFortnight = 14;
            int fortnights = (id / daysPerFortnight) + 1;
            double chargesForFortnight = 5.50;
            int hst = 13;
            int percentage = 100;
            double totalCharges = chargesForFortnight * fortnights;
            double calculateHST = (totalCharges * hst) / percentage;
            double subtotal = totalCharges + calculateHST;
            return "\""+ fortnights + " fortnights at $5.50/FN = " + "$" + totalCharges.ToString("0.00") + " CAD\"\n" + "\"HST 13% = " + "$" + calculateHST + " CAD\"\n" + "\"Total = " + "$" + subtotal + " CAD\"";
        }
    }
}
