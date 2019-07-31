using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TestTask.Interfaces;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        private List<IMetrics> metrics;
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TextAnalyze(string text)
        {

            WordDeposit(text);

            ViewBag.Text = text;
            return View(metrics);
        }

        private void WordDeposit(string text)
        {
            List<string> words = new List<string>();
            int counter = 0;

            while (counter < text.Length)
            {
                var word = text.Skip(counter).TakeWhile(x =>
                {
                    counter++;
                    if (Char.IsNumber(x) || Char.IsLetter(x))
                    {
                        return true;
                    }

                    return false;
                });

                words.Add(string.Join("", word));
            }

            metrics = new List<IMetrics> {
                new QuestionsCount(words),
                new SameLength(words),
                new MostCommonLetter(words),
                new QuotesCount(words),
                new UnpopularWord(words)
            };
        }
    }
}