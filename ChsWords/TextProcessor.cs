using System.Data;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Net.Sockets;
using System.IO;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace ChsWords
{
    public class TextProcessor : IProcessor
    {
        public void Validate(string data)
        {
            if (!TextProcessor.IsHanzi(data.Last()))
                throw new ArgumentException("Text doesn't start with Hanzi");

            if (!TextProcessor.IsPinyin(data.Last()))
                throw new ArgumentException("Text doesn't end with Pinyin");

        }
        public string CleanUpText(string data)
        {
            var sb = new StringBuilder();
            char previous = ' ';

            foreach (var c in data)
            {
                if (c == '一')
                {

                }

                if (TextProcessor.IsPinyin(c) || TextProcessor.IsHanzi(c))
                {
                    if (TextProcessor.IsPinyin(c) && TextProcessor.IsHanzi(previous))
                        sb.Append(" ");

                    if (TextProcessor.IsHanzi(c) && TextProcessor.IsPinyin(previous))
                        sb.Append(Environment.NewLine);

                    sb.Append(Char.ToLower(c));
                    previous = c;
                }
                else
                {

                }
            }

            return sb.ToString();
        }
        public List<Word> Process(string cleanData)
        {
            var dict = new List<Word>();
            int ln = 0;

            foreach (var line in cleanData.Split(
                new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                var hanzi = line.Split(' ')[0];
                var pinyin = line.Split(' ')[1];

                var item = dict.SingleOrDefault(w => w.Hanzi == hanzi);
                if (item == null)
                {
                    dict.Add(new Word() { Hanzi = hanzi, Pinyin = pinyin, NumOfOccurences = 1 });
                }
                else
                {
                    if (pinyin == "shìyì")
                    {

                    }

                    if (!item.Pinyin.Contains(pinyin))
                        item.Pinyin += "| " + pinyin;
                    item.NumOfOccurences++;
                }
                ln++;
            }

            dict = dict.OrderByDescending(w => w.NumOfOccurences).ToList();

            return dict;
        }

        public static bool IsPinyin(char c)
        {
            return ChsWordsUtils.PinyinChars.Contains(Char.ToLower(c));
        }

        public static bool IsHanzi(char c)
        {
            // Todo: add other rare or uncommon ranges from
            // https://stackoverflow.com/questions/1366068/whats-the-complete-range-for-chinese-characters-in-unicode
            if ((c >= '\u4E00' && c <= '\u9FFF') // Common chars
                || (c >= '\u3400' && c <= '\u4DBF') // Rare chars
                || (c >= '\uF900' && c <= '\uFAFF')) // Duplicates, unifiable variants, corporate characters

                return true;

            return false;
        }
    }

    public static class ChsWordsUtils
    {
        public static readonly char[] PinyinChars = {'a', 'ā',  'á', 'ǎ', 'à', 'e', 'ē', 'é', 'ě', 'è', 
                'i', 'ī', 'í', 'ǐ', 'ì', 'o', 'ō', 'ó', 'ǒ', 'ò', 'u', 'ū', 'ú', 'ǔ', 'ù',
                'ǖ', 'ǖ', 'ǘ', 'ǚ', 'ǜ', 'b', 'p', 'm', 'f', 'd', 't', 'n', 'l', 'g', 'k',
                'h', 'j', 'q', 'x', 'z', 'c', 's', 'r', 'y', 'w', 'ʼ'};
    }
}