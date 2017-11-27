using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/values/")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet, Route("")]
        public IEnumerable<string> MyName()
        {
            return new string[] { "Marc", "Uddenfeldt" };
        }
        [HttpGet, Route("HelloWorld")]
        public string HelloWorld()
        {
            return "Hello World" ;
        }

        [HttpGet, Route("DaysOfTheWeek")]
        public string DaysOfTheWeek()
        {
            return "Today its " + DateTime.Now.DayOfWeek.ToString();
        }

        [HttpGet, Route("TodaysFloskel")]

        public string TodaysFloskel()
        {
            string message = "";
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday: message = "Jag hör vad du säger och tar det med mig";
                    break;
                case DayOfWeek.Tuesday: message = "Vi får se var det landar";
                    break;
                case DayOfWeek.Wednesday: message = "Det här ska vara ett levande dokument";
                    break;
                case DayOfWeek.Thursday: message = "I vår organisation har vi högt i tak";
                    break;
                case DayOfWeek.Friday: message = "Du kan inte ändra på andra, bara på dig själv";
                    break;
                case DayOfWeek.Saturday: message = "Vi måste ha en transparent diskussion i de här delarna";
                    break;
                
                case DayOfWeek.Sunday: message = "Vi måste strömlinjeforma processerna för att maximera effektiviteten";
                    break;

                default: message = "Vi vet inte vilken veckodag det är";
                    break;
            }
            return message;
        }


    }
}
