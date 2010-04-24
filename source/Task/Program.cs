using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new Bootstrapper().Init(new TextWriterFeedbackProvider(Console.Out), args).Run();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                Console.Error.WriteLine("for help try 'task help'");
                Environment.Exit(-1);
            }

        }
    }
}
