using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationAsgn1.Models;

namespace WebApplicationAsgn1.Controllers
{
    public class GuessGameController : Controller
    {
        RandomService _randomService;
        public string RandNums;
        public bool CorrectGuess;
        public GuessGameController()
        {
            _randomService = new RandomService();
        }

        [HttpGet]
        public IActionResult GuessGame()
        {
            // Set Sessions to store Random Number


            // Set Cookies to store Highest Score

            string cookieHighest = Request.Cookies["NumberOfRight"];
            if (cookieHighest == null)
            {
                cookieHighest = "0";
            }
            ViewBag.CookieHighest = cookieHighest;
            // For debugging use
            return View();

        }

        [HttpPost]
        public IActionResult CreateGuess(int guessnum)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(5);

            string randNums = HttpContext.Session.GetString("RandNums");

  //          RandNums = randNums;
            if (!string.IsNullOrWhiteSpace(randNums))
            {
                CorrectGuess= _randomService.GuessStart(guessnum);
            } else
            {
                randNums = _randomService.GenerateNum();
                HttpContext.Session.SetString("RandNums", randNums);
                CorrectGuess = _randomService.GuessStart(randNums, guessnum);
            }
            ViewBag.RandNums = randNums;
            if  (CorrectGuess == true)
            {
                //Response.Cookies.Add(new HttpCookie("Day", questions.Day));
                Response.Cookies.Append("NumberOfRight", _randomService.numberRight.ToString());
                HttpContext.Session.SetString("RandNums", "");
                CorrectGuess = false;
            }
            //            RandNums = randNums;
            ViewBag.NumGuess = guessnum.ToString();

            return RedirectToAction(nameof(GuessGame));
//            return View();
        }
    }
}
