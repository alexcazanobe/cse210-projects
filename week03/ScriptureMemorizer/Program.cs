using System;

class Program
{
    static void Main(string[] args)
    {
       var scriptures = new List<Scripture>
       {
            new Scripture(new Reference("Jhon", "3:16"), " For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs", "3:5-6"),"Trust in the Lord with all thine heart, and lean not unto thine own understanding; In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("Psalm", "23:1"), "The Lord is my shepherd; I shall not want."),
            new Scripture(new Reference("Matthew", "5:14"), "Ye are the light of the world. A city that is set on an hill cannot be hid."),
       
            new Scripture(new Reference("1 Nephi", "3:7"), "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."),
            new Scripture(new Reference("Mosiah", "2:17"), "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God."),
            new Scripture(new Reference("Alma", "37:6"), "Now ye may suppose that this is foolishness in me, but behold I say unto you, that by small and simple things are great things brought to pass, and small means in many instances doth confound the wise."),
            new Scripture(new Reference("Ether", "12:27"), "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble, and my grace is sufficient for all men that humble themselves before me, for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them."),       
       };
    

        var random = new Random();


        while(true)
        {
            var selectedScripture = scriptures[random.Next(scriptures.Count)];


            selectedScripture.DisplayScripture();

            selectedScripture.ResetWords();


            while(true)
            {
                Console.WriteLine("Press Enter to hide a word or type 'quit' to exit.");
                var input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    Console.WriteLine("Program ended.");
                    return;
                }

                if (!selectedScripture.HideRandomWord())
                {
                    break;
                }

                selectedScripture.DisplayScripture();
            }
        
            selectedScripture.DisplayScripture();
            Console.WriteLine("All words are hidden. Would you like to continue with another scripture? (yes/no)");
    
            var continueInput = Console.ReadLine();
            if (continueInput.ToLower() != "yes")
            {
                break;
            }

        }

        Console.WriteLine("Program ended");

    }
}