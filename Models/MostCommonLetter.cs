using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.Interfaces;

namespace TestTask.Models
{
    public class MostCommonLetter : IMetrics
    {
        public string Description { get; set; }
        public string Result { get; set; }

        public MostCommonLetter(List<string> list)
        {
            this.Description = "Most common letter is: ";
        }

        public void CalculateMetric(string text)
        {
            var sort = text.Where(x => Char.IsLetter(x) || Char.IsDigit(x))
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .ToList();

            if (sort != null && sort.Count > 0)
            {
                Result = sort[0].ToString();
            }else
                {
                Result = new string('-', 5);
            }
        }
    }
}