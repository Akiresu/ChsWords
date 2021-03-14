using System.Collections.Generic;

namespace ChsWords
{
    public interface IWriter
    {
         void Write(string destination, List<Word> content);
    }
}