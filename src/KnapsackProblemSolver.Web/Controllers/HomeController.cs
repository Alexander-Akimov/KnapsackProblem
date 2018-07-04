using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KnapsackProblemSolver.Web.Models;
using KnapsackProblemSolver.Web.Services;
using static KnapsackProblemSolver.Lib.KnapssackTask;
using KnapsackProblemSolver.Web.ViewModels;
using KnapsackProblemSolver.Lib;
using KnapsackProblemSolver.Web.Extensions;

namespace KnapsackProblemSolver.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskSolverService _taskSolverService;
        public HomeController(TaskSolverService taskSolverService)
        {
            _taskSolverService = taskSolverService;
        }
        public IActionResult Index()
        {
            var tasks = _taskSolverService.GetTaskList().Select(tm => tm.ToViewModel());
            return View(tasks);
        }

        public IActionResult Details(int? taskNumber)
        {
            if (taskNumber != null)
            {
                var task = _taskSolverService.GetTaskByNumber(taskNumber);
                if (task != null)
                    return View(task.ToViewModel());
            }
            return NotFound();
        }

        public IActionResult Test()
        {
            var items = new List<Item>{
                new Item("Five", 9, 6),
                new Item("Two", 4, 6),
                new Item("Three", 5, 4),
                new Item("Four", 8, 7),
                new Item("One", 3, 1)
            };
            var newTask = new KnapssackTask(items, 13);
            _taskSolverService.AddTask(newTask);
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Create()
        {
            return View(/*new TaskDetailsViewModel()*/);
        }

        [HttpPost]
        public IActionResult Create(TaskDetailsViewModel taskDetailsViewModel)
        {
            if (ModelState.IsValid)
            {
                var newTask = taskDetailsViewModel.ToKnapssackTask();

                _taskSolverService.AddTask(newTask);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult AddItem()
        {
            // var itemView = new Item();
            return PartialView("ItemEditor");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
