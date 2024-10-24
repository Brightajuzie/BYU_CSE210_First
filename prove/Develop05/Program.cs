using System;
using System.Threading;

namespace MindfulnessActivities
{
    abstract class Activity
    {
        protected string name;
        protected string description;
        protected int duration;

        public Activity(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public virtual void Start()
        {
            Console.WriteLine("\nActivity: " + name);
            Console.WriteLine("Description: " + description);
            Console.Write("Enter duration in seconds: ");
            duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Prepare to begin...");
            Thread.Sleep(1000);  
            Console.WriteLine("Going to sleep for a second...");
 
        }

        public abstract void Perform();
        

        public virtual void End()
        {
           
            Console.WriteLine("\nWell done!");
            Thread.Sleep(2000);
            Console.WriteLine("Activity completed: " + name);
            Console.WriteLine("Duration: " + duration + " seconds");
            Thread.Sleep(2000);
            Console.WriteLine("I'm back!!");
      
        }
    }

    class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing", "Relax by breathing in and out slowly.") { }

        public override void Perform()
        {
            for (int i = 0; i < duration; i++)
            {
                Console.WriteLine("Breathe in...");
                Thread.Sleep(2000); 
                Console.WriteLine("Breathe out...");
                Thread.Sleep(2000);  
            }
        }
    }
    
    class ReflectionActivity : Activity
    {
        private static readonly string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
          
        };

        private static readonly string[] questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            
        };

        public ReflectionActivity() : base("Reflection", "Reflect on times of strength and resilience.") { }

        public override void Perform()
        {
            Random random = new Random();
            for (int i = 0; i < duration; i++)
            {
                string prompt = prompts[random.Next(prompts.Length)];
                Console.WriteLine("\nPrompt: " + prompt);
                Thread.Sleep(2000);

                foreach (string question in questions)
                {
                    Console.WriteLine(question);
                    Thread.Sleep(2000);
                }
            }
        }
    }

    class ListingActivity : Activity
    {   // prompts
        private static readonly string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            
        };

        public ListingActivity() : base("Listing", "List things in a certain area.") { }

        public override void Perform()
        {
            Random random = new Random();
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine("\nPrompt: " + prompt);
            Thread.Sleep(2000);

            Console.WriteLine("Start listing items:");
            List<string> items = new List<string>();
            for (int i = 0; i < duration; i++)
            {
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(item);
                }
            }

            Console.WriteLine("\nNumber of items listed: " + items.Count);
        }
    }

    class Program
    {
        static void Main()
        {
            while (true)
            {
                 
                Console.WriteLine("\nChoose an activity:");
                Console.WriteLine("1. Breathing");
                Console.WriteLine("2. Reflection");
                Console.WriteLine("3. Listing");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Activity breathingActivity = new BreathingActivity();
                        breathingActivity.Start();
                        breathingActivity.Perform();
                        breathingActivity.End();
                        break;
                    case 2:
                        Activity reflectionActivity = new ReflectionActivity();
                        reflectionActivity.Start();
                        reflectionActivity.Perform();
                        reflectionActivity.End();
                        break;
                    case 3:
                        Activity listingActivity = new ListingActivity();
                        listingActivity.Start();
                        listingActivity.Perform();
                        listingActivity.End();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

