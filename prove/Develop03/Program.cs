using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        public ScriptureReference Reference { get; }
        public List<Word> Words { get; private set; }

        public Scripture(ScriptureReference reference, string text)
        {
            Reference = reference;
            Words = text.Split().Select(word => new Word(word)).ToList();
        }

        public void HideRandomWords(int count)
        {
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                Words[random.Next(Words.Count)].IsHidden = true;
            }
        }

        public override string ToString()
        {
            return $"{Reference}\n{string.Join(" ", Words.Select(w => w.ToString()))}";
        }
    }

    public class ScriptureReference
    {
        public string Book { get; }
        public int Chapter { get; }
        public int? StartVerse { get; }
        public int? EndVerse { get; }

        public ScriptureReference(string reference)
        {
            var parts = reference.Split();
            Book = parts[0];
            Chapter = int.Parse(parts[1]);

            if (parts.Length > 2)
            {
                StartVerse = int.Parse(parts[2]);
                if (parts.Length > 3)
                {
                    EndVerse = int.Parse(parts[3]);
                }
            }
        }

        public override string ToString()
        {
            return $"{Book} {Chapter}:{StartVerse ?? 1}-{EndVerse?.ToString() ?? StartVerse?.ToString()}";
        }
    }

    public class Word
    {
        public string Text { get; }
        public bool IsHidden { get; set; }

        public Word(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return IsHidden ? "-----" : Text;
        }
    }

    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter a scripture reference (e.g., John 3:16):");
            var referenceText = Console.ReadLine();
            var scriptureReference = new ScriptureReference(referenceText);

            Console.WriteLine("Enter the scripture text:");
            var scriptureText = Console.ReadLine();
            var scripture = new Scripture(scriptureReference, scriptureText);

            Console.Clear();
            Console.WriteLine(scripture);

            while (true)
            {
                Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit.");
                var input = Console.ReadLine();

                if (input == "quit")
                {
                    break;
                }

                scripture.HideRandomWords(3);
                Console.Clear();
                Console.WriteLine(scripture);
            }
        }
    }
}
