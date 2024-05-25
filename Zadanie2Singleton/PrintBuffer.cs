using System;
using System.Collections.Generic;

public class PrintBuffer
{
    private static PrintBuffer instance;
    private static readonly object _lock = new object();
    private Queue<PrintTask> printQueue;

    private PrintBuffer()
    {
        printQueue = new Queue<PrintTask>();
    }

    public static PrintBuffer Instance
    {
        get
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new PrintBuffer();
                }
                return instance;
            }
        }
    }

    public void AddPrintTask(PrintTask printTask)
    {
        lock (_lock)
        {
            printQueue.Enqueue(printTask);
            Console.WriteLine($"Added print task: {printTask.DocumentName}");
        }
    }

    public void ProcessPrintTasks()
    {
        while (true)
        {
            PrintTask taskToPrint = null;
            lock (_lock)
            {
                if (printQueue.Count > 0)
                {
                    taskToPrint = printQueue.Dequeue();
                }
            }

            if (taskToPrint != null)
            {
                taskToPrint.Print();
            }
            else
            {
                break;
            }
        }
    }
}
