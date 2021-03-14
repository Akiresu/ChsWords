using System.IO;
using System;

namespace ChsWords
{
    public class FileReader : IReader
    {
        public string Read(string source)
        {
            try
            {
                using (var sr = new StreamReader(source))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            
            
            Console.WriteLine("The file is empty.");
            return "";
        }
    }
}