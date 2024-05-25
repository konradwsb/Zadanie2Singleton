using System;

public class Program
{
    public static void Main(string[] args)
    {
        PrintBuffer printBuffer = PrintBuffer.Instance;

        printBuffer.AddPrintTask(new PrintTask("Document1.pdf"));
        printBuffer.AddPrintTask(new PrintTask("Document2.docx"));
        printBuffer.AddPrintTask(new PrintTask("Document3.pptx"));

        printBuffer.ProcessPrintTasks();
    }
}
