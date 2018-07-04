using System.Collections.Generic;
using KnapsackProblemSolver.Web.Models;
using KnapsackProblemSolver.Lib;
using System;
using System.Linq;

namespace KnapsackProblemSolver.Web.ViewModels
{
    public class TaskDetailsViewModel
    {
        public int TaskNumber { get; set; }
        public Task_Status TaskStatus { get; set; }
        public int MaxWeight { get; set; }
        
        public List<Item> Items { get; set; }

        public int MaxValue { get; set; }
        public List<Item> Ans = new List<Item>();

        public string AnsStr => String.Join(", ", Ans.Select(p => p.Name));

    }
}