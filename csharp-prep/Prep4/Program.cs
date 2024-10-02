// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
List<int> numbers = new List<int>();

int numbertouse = -1;
while (numbertouse != 0)
{
    Console.Write("Enter a number  (PRESS 0 to quit):");
    string response = Console.ReadLine();
    numbertouse = int.Parse(response);

    if (numbertouse!=0)
    {
        numbers.Add(numbertouse);
    }
}
// Computing SUM
int sum = 0;
foreach (int number in numbers)
{
    sum+= number;
}
Console.WriteLine($" The Sum is {sum}");

//Computing the Average
float averge = ((float)sum)/ numbers.Count;
Console.WriteLine($"The Average is {averge}");

//Max
int max = numbers[0];
foreach(int number in numbers)
{
    if(number > max )
    {
        max = number;
    }
}
Console.WriteLine($"The Max is {max}");
