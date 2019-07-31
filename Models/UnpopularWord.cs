using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.Interfaces;

namespace TestTask.Models
{
    public class UnpopularWord : IMetrics
    {
        public string Description { get; set; }
        public string Result { get; set ; }

        private List<string> words;

        public UnpopularWord(List<string> list)
        {
            this.Description = "Percent the most popular char in the most unpopular word: ";
            this.words = list;
        }
        public void CalculateMetric(string text)
        {
            var popularChar = text.Where(x => Char.IsLetter(x) || Char.IsDigit(x))
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .ToList();

            var unpopularWord = words.Where(x => x != "" && x.Length > 3)
                .GroupBy(x => x)
                .OrderBy(x => x.Count())
                .Select(x => x.Key)
                .ToList();

            
            Result = ((decimal)unpopularWord[0]
                .Where(x => x == popularChar[0])
                .ToList()
                .Count/(decimal)unpopularWord[0].Length * 100).ToString("0.##");
        }
    }
}