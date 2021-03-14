using System;
using ChsWords;

namespace ChsWordsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Processing started.");

            args = new string[] { "chapter2.txt", "result", "-open" };
            ChsProcessor.Run(args);

            Console.WriteLine("Processing finished.");

        }
    }
}
