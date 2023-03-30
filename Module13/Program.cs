using System;
using System.IO;
using System.Diagnostics;
namespace FinalTask
{
    class Program
    {        
        static List<string> StrList = new List<string>();
        static LinkedList<string> StrLinkList = new LinkedList<string>();
        static void Main(string[] args)
        {
            try
            {
                string Path = @"C:\Users\ivans\source\repos\13.6 (HW-03)\Text1.txt";
                string Text = File.ReadAllText(Path);
                var noPunctuationText = new string(Text.Where(c => !char.IsPunctuation(c)).ToArray());
                string[] Subs = noPunctuationText.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, int> Words = new Dictionary<string, int>();
                foreach (string item in Subs)
                {
                    if (Words.ContainsKey(item))
                    {
                        Words[item]++;
                    }
                    else
                    {
                        Words.Add(item, 1);
                    }
                }
                var top10 = Words.OrderByDescending(pair => pair.Value).Take(10);
                Console.WriteLine("10 слов, наиболее часто встречающихся в романе \'Обломов\':");
                foreach (var item in top10)
                {
                    Console.WriteLine($"Слово \'{item.Key}\'  встречается в тексте {item.Value} раз");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Измените путь к файлу");
            }
        }
    }
}
