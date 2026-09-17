using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowPrictic.Models
{
    public class Report
    {
        public Report(string name, Task task)
        {
            Name = name;
            Task = task;
        }

        public string Name { get; private set; }
        public Task Task { get; private set; }
    }
}
