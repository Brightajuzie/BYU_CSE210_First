using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    public ScriptureReference Reference { get; }
    public string Text { get; private set; }
    private HashSet<string> HiddenWords { get; }

    public Scripture(string reference, string text)
    {
        Reference = new ScriptureReference(reference);
        Text = text;
        HiddenWords = new HashSet<string>();
    }

    public void HideRandomWord()
    {
        var words = Text.Split();
        if (words.Length > 0)
        {
            var randomIndex = Random.Shared.Next(words.Length);
            var word = words[randomIndex];
            if (!HiddenWords.Contains(word))
            {
                HiddenWords.Add(word);
                Text = Text.Replace(word, "_____");
            }
        }
    }

    public bool IsCompletelyHidden() => HiddenWords.Count == Text.Split().Length;

    public void Display() => Console.WriteLine($"{Reference}: {Text}");
}

class ScriptureReference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    public ScriptureReference(string reference)
    {
        var parts = reference.Split();
        Book = parts[0];
        Chapter = int.Parse(parts[1]);
        StartVerse = int.Parse(parts[2]);
        EndVerse = parts.Length > 3 ? int.Parse(parts[4]) : StartVerse;
    }

    public override string ToString() => EndVerse == StartVerse ? $"{Book} {Chapter}:{StartVerse}" : $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
}

class Program
{
    static void Main()
    {
        var scriptureText = "John 3:16 For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        var scripture = new Scripture(scriptureText, "John 3:16");

        while (true)
        {
            scripture.Display();
            Console.Write("Press Enter to continue or type 'quit' to exit: ");
            var input = Console.ReadLine();

            if (input?.ToLower() == "quit")
                break;

            scripture.HideRandomWord();
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden!");
                break;
            }
        }
    }
}
