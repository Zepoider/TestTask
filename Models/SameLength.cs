using System.Collections.Generic;
using System.Linq;
using TestTask.Interfaces;

namespace TestTask.Models
{
    public class SameLength : IMetrics
    {
        public string Description { get; set; }
        public string Result { get; set; }

        private List<string> words;

        public SameLength(List<string> list)
        {
            this.Description = "The most popular word: ";
            this.words = list;
        }

        public void CalculateMetric(string text)
        {

            var sort = words.Where(x => x != "" && x.Length > 3)
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .ToList();

            Result = sort[0];
        }
    }
}