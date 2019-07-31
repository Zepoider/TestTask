namespace TestTask.Interfaces
{
    public interface IMetrics
    {
        string Description { get; set; }
        string Result { get; set; }

        void CalculateMetric(string text);
      
    }
}
