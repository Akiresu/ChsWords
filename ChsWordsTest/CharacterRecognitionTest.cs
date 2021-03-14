using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChsWords;

namespace ChsWordsTest
{
    [TestClass]
    public class CharacterRecognitionTest
    {
        // Todo:
        // Filter out only Pinyin
        // Filter out only Hanzi
        // Filter out sample of input with all the regular content

        [TestMethod]
        public void TestForPinyinTrue()
        {
            // Tests that we expect to return true.
            string pinyinInput = "érqiězhèxiēdáʼànbìngbùnánlǐjiěZhēnyánShèngjīngxiànzàijiùnéngbāngzhùnǐguògèngkuàilèdeshēnghuóyěhuìgěinǐměihǎodewèiláiJiēxiàláiràngwǒmenxiānliǎojiěyígèhěnduōréndōuxiǎngguodewèntíRénshòukǔshìShàngdìzàikǎoyànrénmaZhège";

            foreach (var ch in pinyinInput)
            {
                bool result = TextProcessor.IsPinyin(ch);
                Assert.IsTrue(result,
                       String.Format("Expected for '{0}': true; Actual: {1}",
                                     ch.ToString(), result));
            }
        }
        [TestMethod]
        public void TestForPinyinFalse()
        {
            // Tests that we expect to return true.
            string pinyinInput = "现代汉语通用字表通用规范汉字字典第二版";

            foreach (var ch in pinyinInput)
            {
                bool result = TextProcessor.IsPinyin(ch);
                Assert.IsFalse(result,
                       String.Format("Expected for '{0}': true; Actual: {1}",
                                     ch.ToString(), result));
            }
        }
        [TestMethod]
        public void TestForHanziTrue()
        {
            // Tests that we expect to return true.
            string pinyinInput = "现代汉语通用字表通用规范汉字字典第二版";

            foreach (var ch in pinyinInput)
            {
                bool result = TextProcessor.IsHanzi(ch);
                Assert.IsTrue(result,
                       String.Format("Expected for '{0}': true; Actual: {1}",
                                     ch.ToString(), result));
            }
        }
        [TestMethod]
        public void TestForHanziFalse()
        {
            // Tests that we expect to return true.
            string pinyinInput = "érqiězhèxiēdáʼànbìngbùnánlǐjiěZhēnyánShèngjīngxiànzàijiùnéngbāngzhùnǐguògèngkuàilèdeshēnghuóyěhuìgěinǐměihǎodewèiláiJiēxiàláiràngwǒmenxiānliǎojiěyígèhěnduōréndōuxiǎngguodewèntíRénshòukǔshìShàngdìzàikǎoyànrénmaZhège";

            foreach (var ch in pinyinInput)
            {
                bool result = TextProcessor.IsHanzi(ch);
                Assert.IsFalse(result,
                       String.Format("Expected for '{0}': true; Actual: {1}",
                                     ch.ToString(), result));
            }
        }
    }
}
