using Microsoft.EntityFrameworkCore;

namespace MvcToDoApp.Data
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem() { Id = 1, Title = "Go Shopping", Done = false },
                new TodoItem() { Id = 2, Title = "Study", Done = true },
                new TodoItem() { Id = 3, Title = "Do your homework", Done = false }
                );
        }
    }
}
