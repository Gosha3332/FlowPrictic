using FlowPrictic.Models;

Console.WriteLine("REPORT PROCESSOR \n------------------");
Console.WriteLine();

SemaphoreSlim semaphore = new SemaphoreSlim(2);
Statistics statistic = new Statistics();

Report sales = TaskBuilder("Sales");
Report customers = TaskBuilder("Customers");
Report wirehouse = TaskBuilder("Wirehouse");

/*object resultLock = new object();*/

Report TaskBuilder(string name) 
{
    return new Report (name, new Task(() => ReportProcessor(name)));
}

void ReportProcessor(string name) 
{
    Console.WriteLine($"{name, -15}started");
    semaphore.Wait();
    try
    {
        for (int i = 0; i < 1000; i++)
        {
            statistic.AddProcessedRecords();
        }
        statistic.ReportSuccess();
    }
    finally
    {
        semaphore.Release();
    }
    
}

/*void ReportProcessor(string name)
{
    Console.WriteLine($"{name,-15}started");

    Monitor.Enter(resultLock);

    try
    {
        for (int i = 0; i < 1000; i++)
        {
            result++;
        }
    }
    finally
    {
        Monitor.Exit(resultLock);
    }
}*/



sales.Task.Start();
customers.Task.Start();
wirehouse.Task.Start();

await Task.WhenAll(sales.Task, customers.Task, wirehouse.Task);

Console.WriteLine($"\n{sales.Name,-15}{sales.Task.Status}");
Console.WriteLine($"{customers.Name,-15}{customers.Task.Status}");
Console.WriteLine($"{wirehouse.Name,-15}{wirehouse.Task.Status}");


Console.WriteLine("------------------ \nRESULT");

Console.WriteLine($"Processed records: {statistic.ProcessedRecords}");
Console.WriteLine($"Successful reports: {statistic.SuccessfulReports}");
