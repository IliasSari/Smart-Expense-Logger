using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Expense> expenses = new List<Expense>();
        Console.WriteLine("--- Welcome to Express Tracker ---");

        while (true)
        {
            Console.WriteLine("\n Choose: 1. Add output, 2. View all, 3. exit");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("1. Description: ");
                string desc = Console.ReadLine();
                Console.Write("2. Amount: ");
                string amt = Convert.ToDouble(Console.ReadLine());
                Console.Write("3. Category: ");
                string cat = Console.ReadLine;

                expenses.Add(new Expense { Description = desc, Amount = amt, Category = cat });
                Console.WriteLine("The Output has added");
            }
            else if (choice == "2")
            {
                Console.WriteLine("\n--- Output List ---");
                double total = 0;
                foreach (var exp in expenses)
                {
                    Console.WriteLine($"{exp.Description} | {exp.Amount}€ | {exp.Category}");
                    total += exp.Amount;
                }
                Console.WriteLine($"Total: {total}€");
            }
            else if (choice == "3") break;
        }
    }
}

public class Expense
{
    public string Description { get; set; }
    public double Amount { get; set; }
    public string Category { get; set; }
}