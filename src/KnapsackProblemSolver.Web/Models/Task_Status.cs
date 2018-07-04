using System.ComponentModel.DataAnnotations;

namespace KnapsackProblemSolver.Web.Models
{
    public enum Task_Status
    {
        added,
        started,
        done
    }

    public static class EnumExtension
    {
        public static string GetString(this Task_Status taskStatus)
        {
            switch (taskStatus)
            {
                case Task_Status.added: return "добавлена";
                case Task_Status.started: return "выполняется";
                case Task_Status.done: return "завершено";
                default: return taskStatus.ToString();
            };
        }        
    }
}