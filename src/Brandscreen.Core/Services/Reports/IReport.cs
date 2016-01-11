using System.Collections.Generic;

namespace Brandscreen.Core.Services.Reports
{
    public interface IReport
    {
        string ReportType { get; }
        string ReportLevel { get; }
        IEnumerable<object> Data { get; }
    }

    public class Report<TKey> : IReport
    {
        private readonly IEnumerable<PerformanceData<TKey>> _data;

        public Report(IEnumerable<PerformanceData<TKey>> data)
        {
            _data = data;
        }

        public string ReportType { get; set; }

        public string ReportLevel { get; set; }

        public IEnumerable<object> Data
        {
            get { return _data; }
        }
    }
}