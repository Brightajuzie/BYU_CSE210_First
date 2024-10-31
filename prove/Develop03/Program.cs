using System;

namespace ScriptureMemorization
{
    public class ScriptureReference
    {
        public string Book { get; set; }
        public int Chapter { get; set; }
        public int StartVerse { get; set; }
        public int? EndVerse { get; set; }

        public ScriptureReference(string book, int chapter, int startVerse, int? endVerse = null)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
        }

        public override string ToString()
        {
            if (EndVerse.HasValue)
            {
                return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
            }
            else
            {
                return $"{Book} {Chapter}:{StartVerse}";
            }
        }
    }

    public class Word
    {
        public string Text { get; set; }
        public bool IsHidden { get; set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        public void Hide()
        {
            IsHidden = true;
        }

        public override string ToString()
        {
            return IsHidden ? new string('_', Text.Length) : Text;
        }
    }

    public class Scripture
    {
        public ScriptureReference Reference { get; set; }
        public List<Word> Words { get; set; }

        public Scripture(ScriptureReference reference, string text)
        {
            Reference = reference;
            Words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        public void HideRandomWord()
        {
            Random random = new Random();
            int index = random.Next(Words.Count);
            Words[index].Hide();
        }

        public bool IsCompletelyHidden()
        {
            return Words.All(word => word.IsHidden);
        }

        public override string ToString()
        {
            return $"{Reference}\n{string.Join(" ", Words)}";
        }
    }

    class Program
    {
        static void Main()
        {
            Scripture scripture = new Scripture(
                new ScriptureReference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            );

            while (!scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture);
                Console.WriteLine("Press Enter to continue, or type 'quit' to exit:");
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    break;
                }
                scripture.HideRandomWord();
            }
        }
    }
}
