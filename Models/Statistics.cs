using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPrictic.Models
{
    public class Statistics
    {
        public int ProcessedRecords => _processedRecords;
        public int SuccessfulReports => _successfulReports;

        private int _processedRecords;
        private int _successfulReports;

        public void AddProcessedRecords() =>
            Interlocked.Increment(ref _processedRecords);

        public void ReportSuccess() =>
            Interlocked.Increment(ref _successfulReports);
    }
}
