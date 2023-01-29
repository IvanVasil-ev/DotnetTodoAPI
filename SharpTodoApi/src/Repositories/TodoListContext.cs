using Microsoft.EntityFrameworkCore;
using SharpTodoApi.Entities;

namespace SharpTodoApi.Repositories;

public class TodoListContext : DbContext
{
    public DbSet<TodoItemEntity> TodoList { get; set; }

    public DbSet<AccountEntity> Accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TodoList;Username=postgres;Password=postgres");
    }
}
