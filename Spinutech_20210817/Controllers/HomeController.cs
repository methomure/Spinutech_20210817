using Spinutech_20210817.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Spinutech_20210817.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ToWords()
        {
            return View();
        }

        public ActionResult ToWordsSubmit(string Number)
        {
            NumberToWordsService s = new NumberToWordsService();
            ViewBag.Message = s.Evaluate(Number);

            return View("ToWords");
        }

        public ActionResult NumberPalidromeTest()
        {
            return View();
        }
        public ActionResult NumberPalidromeTestSubmit(string Number)
        {
            Regex rgx = new Regex(@"^[0-9]+$");
            if (!rgx.IsMatch(Number))
            {
                ViewBag.Message = "Number is in the incorrect format. Please try again.";
            }
            else
            {
                char[] array = Number.ToCharArray();
                Array.Reverse(array);
                string ReversedNumber = new String(array);

                ViewBag.message = "Number is not a Palidrome. Please try again.";
                if (Number == ReversedNumber) ViewBag.message = "Number is a Palidrome.";
            }

            return View("NumberPalidromeTest");
        }
    }
}