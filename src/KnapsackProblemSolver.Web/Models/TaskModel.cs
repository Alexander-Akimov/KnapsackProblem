using KnapsackProblemSolver.Lib;

namespace KnapsackProblemSolver.Web.Models
{
    public class TaskModel
    {
        public int taskNumber { get; set; }
        public Task_Status taskStatus { get; set; }
        public KnapssackTask task { get; set; }

        public TaskModel(int taskNumber, KnapssackTask task)
        {
            this.taskNumber = taskNumber;
            this.taskStatus = Task_Status.added;
            this.task = task;
        }
    }
}