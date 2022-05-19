using Microsoft.EntityFrameworkCore;
using TodoList.Entities;

namespace TodoList.Context
{
    public class TodoContext:DbContext
    {


        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            }
        public DbSet<Todo> Todo { get; set; }
    }
    
}
