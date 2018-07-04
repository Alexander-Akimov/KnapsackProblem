using System;
using System.Collections.Generic;
using KnapsackProblemSolver.Lib;
using static KnapsackProblemSolver.Lib.KnapssackTask;

namespace KnapsackProblemSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //var tempValues = new int[0, 0];
            var items = new List<Item>{
                new Item("Five", 9, 6),
                new Item("Two", 4, 6)
                new Item("Three" , 5, 4),
                new Item("Four" , 8, 7),
                new Item("One", 3, 1)
            };
            var newTask = new   KnapssackTask(items, 13);

            foreach (Item item in newTask.Solve())
                Console.WriteLine(item.Name);

    Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();
        }
    }
}