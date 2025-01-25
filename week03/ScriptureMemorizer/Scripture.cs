using System;
using System.Collections.Generic;

public class Scripture
{
    public Reference Reference { get; private set; }
    public List<List<Word>> Verses { get; private set; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Verses = new List<List<Word>>();

        
        if (text.Contains(";"))
        {
            string[] verses = text.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var verse in verses)
            {
                var words = new List<Word>();
                foreach (var word in verse.Split(' '))
                {
                    words.Add(new Word(word));
                }
                Verses.Add(words);
            }
        }
        else
        {
            var words = new List<Word>();
            foreach (var word in text.Split(' '))
            {
                words.Add(new Word(word));
            }
            Verses.Add(words);
        }
    }

    public void DisplayScripture()
    {
        Console.Clear();
        Console.WriteLine(Reference.GetFormattedReference());  

        int verseCount = Reference.VerseStart; 

        foreach (var verse in Verses)
        {
            
            Console.Write($"{verseCount}: ");
            foreach (var word in verse)
            {
                Console.Write(word.GetDisplayText() + " ");
            }
            Console.WriteLine();
            verseCount++; 
        }

        Console.WriteLine();
    }

    public bool HideRandomWord()
    {
        var random = new Random();
        var hiddenWords = new List<Word>();

        
        foreach (var verse in Verses)
        {
            hiddenWords.AddRange(verse.FindAll(w => w.IsHidden));
        }

        
        if (hiddenWords.Count == CountTotalWords())
        {
            return false;
        }

        int index;
        do
        {
            index = random.Next(CountTotalWords());
        } while (IsWordHidden(index));

        SetWordHidden(index);
        return true;
    }

    public void ResetWords()
    {
        
        foreach (var verse in Verses)
        {
            foreach (var word in verse)
            {
                word.Show();
            }
        }

        DisplayScripture();
    }

    private int CountTotalWords()
    {
        int count = 0;
        foreach (var verse in Verses)
        {
            count += verse.Count;
        }
        return count;
    }

    private bool IsWordHidden(int index)
    {
        int wordCount = 0;
        foreach (var verse in Verses)
        {
            foreach (var word in verse)
            {
                if (wordCount == index)
                {
                    return word.IsHidden;
                }
                wordCount++;
            }
        }
        return false;
    }

    private void SetWordHidden(int index)
    {
        int wordCount = 0;
        foreach (var verse in Verses)
        {
            foreach (var word in verse)
            {
                if (wordCount == index)
                {
                    word.Hide();
                    return;
                }
                wordCount++;
            }
        }
    }
}
