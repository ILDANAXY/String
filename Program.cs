using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace String
{
    class Program
    {
        static void CountSym(string x) //Счётчик знаков препинания
        {
            int pCount = x.Count(Char.IsPunctuation);
            Console.Write("Количество знаков препинания в этом тексте:");
            Console.WriteLine(pCount);
        }
        static void SpliterSentence(string Sen) //Выводим предложения с новой строки
        {
            string[] sentences = Regex.Split(Sen, @"(?<=[\.!\?])\s+");
            Console.WriteLine("Предложения:");
            foreach (string sentence in sentences)
            {
                Console.WriteLine(sentence);
            }
        }

        static string[] SpliterWords(string str) //Создаем массив обработанных слов
        {
            string[] words = str.Split(' ', '.', ',', '!', '?', '-', ';', ':', '"', '(', ')');
            words = words.Where(x => x != "").ToArray();
            return words;
        }
        public static string TheLongestWord(string text) // Поиск самого длинного слова
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
            Program.CountSym(str);
            SpliterSentence(str);
            foreach (string word in SpliterWords(str).Distinct(StringComparer.CurrentCultureIgnoreCase))
            {
                Console.WriteLine($"{word.ToLower()}");
            }
            Console.WriteLine($"Самое длинное слово: {TheLongestWord(SpliterWords(str))}");
            Console.WriteLine($"Уникальные слова: {string.Join(", ", SpliterWords(str).Distinct()).ToLower()}");
            ConvertWord(str);
        }

    }
}
