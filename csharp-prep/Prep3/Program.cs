// See https://aka.ms/new-console-template for more information
 
 Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;
        while (guess != magicNumber)
        {
            Console.WriteLine("What is your Guess");
            guess= int.Parse(Console.ReadLine());
           
            if (magicNumber > guess)
            {
                Console.WriteLine("This looks Bigger");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("this looks Smaller");
            }
            else
            {
                Console.WriteLine("You got it");
            }

        }
