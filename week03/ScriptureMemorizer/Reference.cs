using System;

public class Reference
{
    public string Book {get; private set;}
    public int Chapter {get; private set;}

    public int VerseStart {get; private set;}

    public int VerseEnd {get; private set;}


    public Reference(string book, string range)
     {
        Book = book;

        
        var parts = range.Split(':');
        Chapter = int.Parse(parts[0]);

        
        var verseParts = parts[1].Split('-');
        VerseStart = int.Parse(verseParts[0]);

        
        VerseEnd = verseParts.Length > 1 ? int.Parse(verseParts[1]) : VerseStart;
    }

    public string GetFormattedReference()
    {
        if (VerseStart == VerseEnd)
            return $"{Book} {Chapter}:{VerseStart}";
        else
            return $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
    }
}