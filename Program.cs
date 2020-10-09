using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace String
{
    class Program
    {
        static void CountSymb(string x) //Счётчик знаков препинания
        {
            int pCount = x.Count(Char.IsPunctuation);
            Console.Write("Количество знаков препинания в этом тексте:");
            Console.WriteLine(pCount);
        }
        static void SplitSentence(string Sen) //Выводим предложения с новой строки
        {
            string[] sentences = Regex.Split(Sen, @"(?<=[\.!\?])\s+");
            Console.WriteLine("Предложения:");
            foreach (string sentence in sentences)
            {
                Console.WriteLine(sentence);
            }
        }

        static string[] SplitWords(string str) //Создаем массив обработанных слов
        {
            string[] words = str.Split(' ', '.', ',', '!', '?', '-', ';', ':', '"', '(', ')');
            words = words.Where(x => x != "").ToArray();
            return words;
        }
        public static string FindTheLongestWord(string text) // Поиск самого длинного слова
        {
            Console.WriteLine("Самое длинное слово:");
            string[] words = SplitWords(text);
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
        static string ConvertWord(string maxWord) //Проверка чётности и нечётности
        {
            if ((maxWord.Length % 2) == 0) 
                maxWord = maxWord.Substring(maxWord.Length / 2);
            else
            {
                maxWord = maxWord.Replace(maxWord[maxWord.Length / 2], '*');
            }
            return maxWord;
        }

        static void Main(string[] args) //Вызов всех методов 
        {
            Console.WriteLine("Введите ваш текст:");
            var str = Console.ReadLine();
            Program.CountSymb(str);
            SplitSentence(str);
            Console.WriteLine($"Уникальные слова: {string.Join(", ", SplitWords(str).Distinct()).ToLower()}");
            Console.WriteLine($"Самое длинное слово: {FindTheLongestWord(SplitWords(str))}");
            ConvertWord(str);
        }

    }
}
