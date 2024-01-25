using System.ComponentModel.DataAnnotations;

namespace MvcToDoApp.Data
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} area is required")]
        [MaxLength(200, ErrorMessage = "{0} can be maximum 200 characters long")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "The {0} area is required")]
        public bool Done { get; set; }
    }
}
