namespace ChsWords
{
    public class Word
    {
        public string Hanzi { get; set; }
        public string Pinyin { get; set; }
        public string Translation { get; set; }

        public int NumOfOccurences { get; set; }
        public double Percentge { get; set; }
    }
}