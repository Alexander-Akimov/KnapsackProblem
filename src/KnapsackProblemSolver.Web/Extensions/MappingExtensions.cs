
using KnapsackProblemSolver.Lib;
using KnapsackProblemSolver.Web.Models;
using KnapsackProblemSolver.Web.ViewModels;

namespace KnapsackProblemSolver.Web.Extensions
{
    public static class MappingExtensions
    {
        public static TaskDetailsViewModel ToViewModel(this TaskModel taskModel)
        {
            return new TaskDetailsViewModel
            {
                TaskNumber = taskModel.taskNumber,
                TaskStatus = taskModel.taskStatus,
                Items = taskModel.task.Items,
                Ans = taskModel.task.Ans,
                MaxValue = taskModel.task.MaxValue
            };
        }

        public static KnapssackTask ToKnapssackTask(this TaskDetailsViewModel taskModel)
        {
            return new KnapssackTask(taskModel.Items, taskModel.MaxWeight);
        }
    }
}