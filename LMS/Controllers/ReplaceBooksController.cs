﻿using Microsoft.AspNetCore.Mvc;
using LMS_Management.ReplacingBooks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace LMS.Controllers
{
    public class ReplaceBooksController : Controller
    {
        private ReplacingBooks game = new ReplacingBooks();
        private Dictionary<string, string> levels = new Dictionary<string, string>();
        private static List<string> callNumbers = new List<string>();

        public IActionResult Index()
        {        
            callNumbers = game.GenerateCallNumbers();
            ViewBag.Items = callNumbers;

            levels = game.GameLevelDescription();
            ViewBag.Levels = levels;

            return View();
        }

        [HttpPost]
        public IActionResult SubmitSortedItems([FromBody] string[] sortedItems)
        {
            //convert the array to a list
            var items = sortedItems.ToList();

            List<string> extractedNumbers = sortedItems
                    .Select(item =>
                    {
                        // Use a regular expression to match numbers (with or without periods)
                        MatchCollection matches = Regex.Matches(item, @"\d+(\.\d+)?");

                        // Join the matched numbers into a single string
                        return string.Join("", matches.Cast<Match>().Select(match => match.Value));
                    })
                    .ToList();

            //check the order of the items
            var outcome = game.CheckOrder(extractedNumbers, callNumbers);

            var result = "Lose";

            if (outcome)
            {
                result = "Win";
            }

            
            return Ok(result);
        }

    }
}
