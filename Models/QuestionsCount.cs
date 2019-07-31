using System.Collections.Generic;
using System.Linq;
using TestTask.Interfaces;

namespace TestTask.Models
{
    public class QuestionsCount : IMetrics
    {
        public string Description { get; set; }
        public string Result { get; set; }

        public QuestionsCount(List<string> list)
        {
            this.Description = "Number of questions in the text: ";
        }

        public void CalculateMetric(string text)
        {

            var sort = text.Where(x => x == '?').ToList();
            Result = sort.Count.ToString();
        }
    }
}