using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KnapsackProblemSolver.Lib;
using static KnapsackProblemSolver.Lib.KnapssackTask;

namespace KnapsackProblemSolver
{
    public enum Task_Status
    {
        added,
        started,
        done
    }
    public class TaskModel
    {
        public int TaskNumber { get; set; }
        public Task_Status TaskStatus { get; set; }
        public KnapssackTask Task { get; set; }

        public TaskModel(int taskNumber, KnapssackTask task)
        {
            this.TaskNumber = taskNumber;
            this.TaskStatus = Task_Status.added;
            this.Task = task;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<TaskModel> tasksToRun = new List<TaskModel>();
            //Console.WriteLine("Hello World!");
            //var tempValues = new int[0, 0];
            var items = new List<Item>{
                new Item("Five", 9, 6),
                new Item("Two", 4, 6),
                new Item("Three" , 5, 4),
                new Item("Four" , 8, 7),
                new Item("One", 3, 1)
            };
            var task1 = new KnapssackTask(items, 13);
            var task2 = new KnapssackTask(items, 13);
            var task3 = new KnapssackTask(items, 13);
            var task4 = new KnapssackTask(items, 13);
            int i = 1;

            tasksToRun.Add(new TaskModel(i++, task1));
            tasksToRun.Add(new TaskModel(i++, task2));
            tasksToRun.Add(new TaskModel(i++, task3));
            tasksToRun.Add(new TaskModel(i++, task4));


            // foreach (Item item in newTask.Solve())
            //     Console.WriteLine(item.Name);
            var taskArray = RunTask(tasksToRun);

            foreach (var t in taskArray)
                t.Start();

           var whenAnyTask = Task.WhenAll(taskArray.ToArray());

whenAnyTask.Wait();
            Console.WriteLine("Press Enter to Exit...");
           // Console.ReadLine();
        }

        public static List<Task> RunTask(List<TaskModel> tasksToRun)
        {
            var taskList = new List<Task>();
            foreach (var task in tasksToRun)
            {
                taskList.Add(new Task(() =>
                    {                        
                        task.TaskStatus = Task_Status.started;
                        //Thread.Sleep(2000);
                        task.Task.Solve();
                        task.TaskStatus = Task_Status.done;
                        Console.WriteLine(task.TaskNumber + "\n");
                    }));
            }
            return taskList;
        }
    }
}