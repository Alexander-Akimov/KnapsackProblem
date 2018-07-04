using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KnapsackProblemSolver.Web.Models;
using KnapsackProblemSolver.Web.Services;

namespace KnapsackProblemSolver.Web.HostedServices
{
    public class TaskRunnerService : HostedService
    {
        private readonly TaskSolverService _taskSolverService;

        public TaskRunnerService(TaskSolverService taskSolverService)
        {
            _taskSolverService = taskSolverService;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            //var index = 0;
            while (!cancellationToken.IsCancellationRequested)
            {
                var tasksToRun = _taskSolverService.GetTasksToRun();
                if(tasksToRun.Count == 0)
                    continue;
 

               // var taskList = new List<Task>();

                foreach (var task in tasksToRun)
                {
                    await Task.Factory.StartNew(() =>
                        {
                            task.taskStatus = Task_Status.started;
                            Thread.Sleep(2000);
                            task.task.Solve();
                            task.taskStatus = Task_Status.done;
                        }, cancellationToken);
                }
                // if (taskList.Count > 0)
                //     await Task.WhenAny(taskList.ToArray());
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
                // Console.WriteLine(index++);
            }
        }
    }
}