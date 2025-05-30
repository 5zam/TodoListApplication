using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApplication.Context;
using ToDoListApplication.Models;



namespace ToDoListApplication.Controllers
{
    public class TodoController : Controller
    {
        private ApplicationDbContext _context;
        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult DisplayAllTasks(int categoryId)
        {
            var category = _context.Categories
                .Include(c => c.TodoList)
                .FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
                return NotFound();

            return View(category);
        }


        [HttpGet]
        public IActionResult AddNewTask(int categoryId)
        {
            var todo = new Todo
            {
                CategoryId = categoryId,
                Deadline = DateTime.Today.AddDays(7) // يبدأ بعد أسبوع default
            };
            return View(todo);
        }


        [HttpPost]
        public IActionResult AddNewTask(Todo task)
        {
            _context.Todos.Add(task);
            _context.SaveChanges();

            return RedirectToAction("DisplayAllTasks", new { categoryId = task.CategoryId });
        }




        //update

        //display
        [HttpGet]
        public IActionResult EditTask(int id)
        {
            var task = _context.Todos.Find(id);
            if (task == null)
                return NotFound();

            return View(task);
        }

        //Save update
        [HttpPost]
        public IActionResult EditTask(Todo updatedTask)
        {
            var task = _context.Todos.Find(updatedTask.Id);
            if (task == null)
                return NotFound();
            task.TaskName = updatedTask.TaskName;
            task.Description = updatedTask.Description;
            task.Deadline = updatedTask.Deadline;
            task.Priority = updatedTask.Priority;

            _context.SaveChanges();

            return RedirectToAction("DisplayAllTasks", new { categoryId = task.CategoryId });
        }

        //done
        [HttpPost]
        public IActionResult MarkAsDone(int id)
        {
            var task = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound();

            task.IsFinished = true;
            _context.SaveChanges();

            return RedirectToAction("DisplayAllTasks", new { categoryId = task.CategoryId });
        }

        //Undo
        [HttpPost]
        public IActionResult MarkAsUnDone(int id)
        {
            var task = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound();

            task.IsFinished = false;
            _context.SaveChanges();

            return RedirectToAction("DisplayAllTasks", new { categoryId = task.CategoryId });
        }


        //delete
        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.Todos.Find(id);
            if (task == null)
                return NotFound();

            int categoryId = task.CategoryId;

            _context.Todos.Remove(task);
            _context.SaveChanges();

            return RedirectToAction("DisplayAllTasks", new { categoryId = categoryId });
        }


    }
}
