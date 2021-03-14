using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ClosedXML.Excel;

namespace ChsWords
{
    public class FileWriter : IWriter
    {
        public void Write(string destination, string content)
        {
            this.WriteTxt(destination, content);
        }

        public void Write(string destination, List<Word> dict)
        {
            this.WriteXlsx(destination, dict);
        }

        public void WriteTxt(string destination, string content)
        {
            string filePath = destination.Contains(".txt") ? destination : destination + ".txt";
            File.WriteAllText(filePath, content);
        }

        public void WriteCsv(string destination, List<Word> content)
        {
            string filePath = destination.Contains(".csv") ? destination : destination + ".csv";
            string sep = System.Globalization.CultureInfo.GetCultureInfo("en-gb").TextInfo.ListSeparator;

            //dict.Add(new Word() { ChineseWord = "All words", Pinyin = "All words", NumOfOccurences = numOfWords, Percentge = 100 });
            string resultText = String.Join(System.Environment.NewLine, content.Select(
                x => x.Hanzi + sep + x.Pinyin + sep + x.Translation + sep + x.NumOfOccurences));

            var data = Encoding.UTF8.GetBytes(resultText);
            var result = Encoding.UTF8.GetPreamble().Concat(data).ToArray();
            File.WriteAllBytes(filePath, result);
            // If you get unauthorized exception run the VS as admin
        }

        public void WriteXlsx(string destination, List<Word> content)
        {
            IXLWorkbook wb = new XLWorkbook();
            IXLWorksheet ws = wb.Worksheets.Add("Chinese Words");
            int row = 1;
            int totalWords = content.Sum(w => w.NumOfOccurences);
            float addedPercent = 0;

            ws.Cell(row, 1).Value = "Hanzi";
            ws.Cell(row, 2).Value = "Pinyin";
            ws.Cell(row, 3).Value = "Translation";
            ws.Cell(row, 4).Value = "Count";
            ws.Cell(row, 5).Value = "Percantage";
            ws.Cell(row, 6).Value = "Cumulative percentage";
            ws.Cell(row, 8).Value = "Total words";
            ws.Cell(row, 9).Value = totalWords;

            foreach (var wrd in content)
            {
                row++;
                float percent = (float)wrd.NumOfOccurences / totalWords;
                addedPercent += percent;

                ws.Cell(row, 1).Value = wrd.Hanzi;
                ws.Cell(row, 2).Value = wrd.Pinyin;
                ws.Cell(row, 3).Value = wrd.Translation;
                ws.Cell(row, 4).Value = wrd.NumOfOccurences;
                ws.Cell(row, 5).FormulaA1 = "=D" + row + " / I$1 * 100";
                ws.Cell(row, 6).FormulaA1 = "=E" + row + "+IF(ISNUMBER(INDIRECT(ADDRESS(ROW()-1,COLUMN()))),INDIRECT(ADDRESS(ROW()-1,COLUMN())),0)";

                ws.Cell(row, 5).Style.NumberFormat.Format = "##0.00";
                ws.Cell(row, 6).Style.NumberFormat.Format = "##0.00";
            }

            try
            {
                wb.SaveAs((destination.Contains(".xlsx")) ? destination : destination + ".xlsx");
            }
            catch
            {
                destination += "_1";
                wb.SaveAs((destination.Contains(".xlsx")) ? destination : destination + ".xlsx");

            }
        }
    }
}