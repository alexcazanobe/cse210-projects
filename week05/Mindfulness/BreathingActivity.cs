using System;

public class BreathingActivity : Activity
{
        public BreathingActivity() :base("Breathing Activity","This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {

        }

        public override void Run()
        {
            DisplayStartingMessage();

            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            int breathTime = 3;
            int maxBreathTime = 15;

            while (DateTime.Now < endTime)
            {
                ShowCountDown($"Breathe in ...", breathTime);
                ShowCountDown($"Breathe out ...", breathTime);

                if (breathTime < maxBreathTime)
                {
                    breathTime += 2;
                }


            }

            DisplayEndingMessage();
        
        }
}