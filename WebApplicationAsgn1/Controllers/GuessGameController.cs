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
        public GuessGameController()
        {
            _randomService = new RandomService();
        }

        [HttpGet]
        public IActionResult GuessGame(string msg, int numguess)
        {
            string theGuess = "";
            string randNums = HttpContext.Session.GetString("RandNums");
            if (string.IsNullOrWhiteSpace(randNums))
            {
                randNums = _randomService.GenerateNum();
                HttpContext.Session.SetString("RandNums", randNums);
                theGuess = randNums;
            }
            else
                theGuess = numguess.ToString();

            string cookieHighest = Request.Cookies["NumberOfRight"];
            ViewBag.CookieHighest = cookieHighest;

            ViewData["Msg"] = msg;

            if (msg != null)
            {
                if (msg.Contains("CORRECT"))
                {
                    ViewBag.ColorCode = "green";
                    ViewBag.RandNums = numguess.ToString();
                }
                else
                {
                    ViewBag.ColorCode = "warning";
                    ViewBag.RandNums = "";
                }
            }
            ViewData["NumGuess"] = numguess.ToString();
            // For debugging use

            return View();
        }

        [HttpPost]
        public IActionResult CreateGuess(int guessnum)
        {
            bool correctGuess = false;
            string msg;
 
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(5);

            string randNums = HttpContext.Session.GetString("RandNums");

            //          RandNums = randNums;
            if (!string.IsNullOrWhiteSpace(randNums))
            {
                correctGuess= _randomService.GuessStart(randNums, guessnum);
            } else
            {
                randNums = _randomService.GenerateNum();
                HttpContext.Session.SetString("RandNums", randNums);
                correctGuess = _randomService.GuessStart(randNums, guessnum);
            }
            string cookieHighest = Request.Cookies["NumberOfRight"];
            if (cookieHighest == null)
            {
                cookieHighest = "0";
            }
            string itIsToo = "";
            _randomService.randNumSR = int.Parse(randNums);
            itIsToo = _randomService.GuessStart(guessnum);
            int numberRight = int.Parse(cookieHighest);
            if  (correctGuess == true)
            {
                numberRight += 1;
                //Response.Cookies.Add(new HttpCookie("Day", questions.Day));
                Response.Cookies.Append("NumberOfRight", numberRight.ToString());
                HttpContext.Session.SetString("RandNums", "");
                msg = "Congratulation, your guess is CORRECT!!!";
                correctGuess = false;
            } else
            {
                msg = $"Oops! Thats incorrect! {itIsToo}";
            }
 
            ViewBag.CookieHighest = cookieHighest;

            return RedirectToAction("GuessGame", new { Msg = msg,
                NumGuess = guessnum }) ; 
        }
    }
}
