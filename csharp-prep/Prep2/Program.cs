using System;

class Program
{
    static void Main(string[] args)
    {
         
        Console.WriteLine("Welcome!");
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percentage = int.Parse(answer);
        string Grade ="";
        if (percentage >= 90)
        {
            Grade="A";
        }
            else if (percentage >= 80)
        {
            Grade = "B";
        }
            else if (percentage % 10 >= 7)
        {
             Grade = "B+";
        }
             else if (percentage % 10 <= 3)
        {
             Grade = "B-";
        }

            else if (percentage >= 70)
        {
            Grade="C";
        }
            else if (percentage % 10 >= 7)
        {
            Grade = "C+";
        }
            else if (percentage % 10 <= 3)
        {
            Grade = "C-";
        }
            else if (percentage >= 60)
        {
            Grade="D";
        }
            else if (percentage % 10 >= 7)
        {
             Grade = "D+";
        }
             else if (percentage % 10 <= 3)
        {
             Grade = "D-";
        }
            else
        {
            Grade="F";
        }    
            Console.WriteLine ($"Your Grade is: {Grade}");
            if (percentage >= 70 )
        {
            Console.WriteLine("You Passed");
        }
            else
        {
            Console.Write("we Appreciate Your efforts so far and we encourage you to put more effort so you will pass the next exam");
        }

        
    }
}
