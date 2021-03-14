using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ChsWords
{
    public class ChsProcessor
    {
        public static void Run(string[] args)
        {
            string inputFile = "", outputFile = "result";

            if (args != null && args.Length != 0)
            {
                inputFile = args[0];
                outputFile = args[1];
            }
            else
            {
                Console.WriteLine("Path to the file to be processed is a required parameter.");
            }

            var content = new FileReader().Read(inputFile);

            string clean = new TextProcessor().CleanUpText(content);
            List<Word> dict = new TextProcessor().Process(clean);

            new FileWriter().WriteTxt(outputFile, clean);
            new FileWriter().Write(outputFile, dict);

            if (args.Any(a => a == "-open"))
            {
                Process fileopener = new Process();
                fileopener.StartInfo.FileName = "explorer";
                fileopener.StartInfo.Arguments = "\"" + args[1] + ".xlsx\"";
                fileopener.Start();
            }
        }
    }
}
