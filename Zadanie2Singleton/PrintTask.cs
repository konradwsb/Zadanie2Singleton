using System;

public class PrintTask
{
    public string DocumentName { get; private set; }
    public DateTime SubmissionTime { get; private set; }

    public PrintTask(string documentName)
    {
        DocumentName = documentName;
        SubmissionTime = DateTime.Now;
    }

    public void Print()
    {
        Console.WriteLine($"Printing document: {DocumentName}, submitted at: {SubmissionTime}");
    }
}
