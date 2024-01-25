using MvcToDoApp.Data;
using System.ComponentModel.DataAnnotations;

namespace MvcToDoApp.Models
{
    public class HomeViewModel
    {
        [Required(ErrorMessage = "* Required")]
        public string Title { get; set; } = null!;

        public List<TodoItem> TodoItems { get; set; } = new();
    }
}
