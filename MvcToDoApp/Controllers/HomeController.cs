using Microsoft.AspNetCore.Mvc;
using MvcToDoApp.Data;
using MvcToDoApp.Models;
using System.Diagnostics;

namespace MvcToDoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UygulamaDbContext _db;

        public HomeController(ILogger<HomeController> logger, UygulamaDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var vm = new HomeViewModel()
            {
                TodoItems = _db.TodoItems.OrderBy(x => x.Done).ToList(),
            };
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(HomeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _db.TodoItems.Add(new TodoItem() { Title = vm.Title });
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            vm.TodoItems = _db.TodoItems.OrderBy(x => x.Done).ToList();
            return View(vm);
        }

        public IActionResult Sil(TodoItem todo)
        {
            _db.TodoItems.Remove(todo);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Update(int[] dones)
        {
            var items = _db.TodoItems.ToList();

            foreach (var item in items)
            {
                item.Done = dones.Contains(item.Id);
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var item = _db.TodoItems.Find(id);

            if (item == null)
                return NotFound();

            _db.TodoItems.Remove(item);
            _db.SaveChanges();

            return RedirectToAction("Index");
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
