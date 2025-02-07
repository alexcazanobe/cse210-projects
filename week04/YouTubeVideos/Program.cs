using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new  Video("Unboxing & Review of the X100Smartphone", "TechRwviews", 420);
        Video video2 = new Video("Sound Test of UltraBass Headphones", "AudioPro", 310);
        Video video3 = new Video("Mechanical Keyboard- Is It Worth It?", "TeachGear Reviews", 480);


        video1.AddComment(new Comment("Carlos", "This phone has an amazing camera"));
        

        video2.AddComment(new Comment ("Sophie", "Sounds Great, but does it have noise cancellation?"));
        video2.AddComment(new Comment("Fernanda", " Love the desing!"));

        video3.AddComment(new Comment("Mark", "I swithced to a mechanical keyboard last year, and I'll never go back!"));
        video3.AddComment(new Comment("Alex", "Are mechanical keyboards really better for gaming?"));
        video3.AddComment(new Comment("Xavier", "I loved the clicky sound, but some people say it's too loud for the office"));
    

        List<Video> videos = new List<Video> {video1, video2, video3};

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    
    
    
    }


}