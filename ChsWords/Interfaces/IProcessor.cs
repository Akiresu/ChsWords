using System.Collections.Generic;

namespace ChsWords
{
    public interface IProcessor
    {
         void Validate(string data);
         string CleanUpText(string data);
         List<Word> Process(string cleanData);
    }
}