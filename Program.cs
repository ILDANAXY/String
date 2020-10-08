using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace String
{
    class Program
    {
        static void CountSym(string x)
        {
            int pCount = x.Count(Char.IsPunctuation);
            Console.Write("Количество знаков препинания в этом тексте:");
            Console.WriteLine(pCount);
        }
        static void SpliterSentence(string Sen)
        {
            string[] sentences = Regex.Split(Sen, @"(?<=[\.!\?])\s+");
            Console.WriteLine("Предложения:");
            foreach (string sentence in sentences)
            {
                Console.WriteLine(sentence);
            }
        }

        public static string[] SpliterWords(string text)
        {
            string[] words = text.Split(' ', '.', ',', '!', '?', '(', ')', '"', '\'', '*', ';', ':');
            return words;
        }

        public static string LongWord(string text) // Находим самое длинное слово
        {
            Console.WriteLine("Самое длинное слово:");
            string[] words = SpliterWords(text);
            int max = -1;
            string maxWord = " ";
            foreach (string word in words)
            {
                if (word.Length >= max)
                {
                    max = word.Length;
                    maxWord = word;
                }
            }

            return maxWord;
        } 
        public static string ConvertWord(string word) // Изменяем слово в зависимости от четности его длины
        {
            if (word.Length / 2 == 0)
                {
                word = word.Substring(0, word.Length / 2);
                Console.WriteLine(word);
                Console.ReadLine();
                }
            else
            {
                int centerInt = word.Length / 2;
                char centerCh = word[centerInt];
                word = word.Replace(centerCh, '*');
            }

            return word;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваш текст:");
            var str = Console.ReadLine();
            Program.CountSym(str);
            SpliterSentence(str);
            //longword(str);
            //convertword(maxword);
            Console.WriteLine(ConvertWord(LongWord(str)));
        }

    }
}
