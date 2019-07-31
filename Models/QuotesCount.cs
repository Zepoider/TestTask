using System.Collections.Generic;
using System.Linq;
using TestTask.Interfaces;

namespace TestTask.Models
{
    public class QuotesCount : IMetrics
    {
        public string Description { get; set; }
        public string Result { get; set; }

        public QuotesCount(List<string> list)
        {
            this.Description = "Quotes count: ";
        }

        public void CalculateMetric(string text)
        {
            var sort = text.Where(x => x == '"' || x == '«' || x == '»' || x == '“' || x == '”' || x == '„' || x == '“').ToList();
            Result = (sort.Count/2).ToString();
        }
    }
}