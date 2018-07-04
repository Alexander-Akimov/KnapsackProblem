using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KnapsackProblemSolver.Lib;
using KnapsackProblemSolver.Web.Models;

namespace KnapsackProblemSolver.Web.Services
{
    public class TaskSolverService
    {
        private List<TaskModel> _taskList = new List<TaskModel>();
        private int _taskCounter = 1;
        public TaskSolverService()
        {

        }

        /*  public List<TaskResult> GetTaskList()
          {

          }*/

        public void AddTask(KnapssackTask task)
        {
            _taskList.Add(new TaskModel(_taskCounter++, task));
        }
        public TaskModel GetTaskByNumber(int? taskNumber)
        {
            return _taskList.FindLast(task => task.taskNumber == taskNumber);
        }

        public List<TaskModel> GetTaskList()
        {
            return _taskList;
        }
        public List<TaskModel> GetTasksToRun()
        {
            return _taskList.FindAll(task => task.taskStatus == Task_Status.added);

            /*_taskList
            .FindAll(task => task.taskStatus == Task_Status.added)
            .ForEach(task =>
            {
                task.taskStatus = Task_Status.added;
            });*/
        }

      /*  public Task RunTask(TaskModel taskToRun, CancellationToken cancellationToken)
        {
            var task = new Task(() => { });
            
            return task;
            //TaskScheduler

        }*/
    }
}