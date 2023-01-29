using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharpTodoApi.Entities;
using SharpTodoApi.Repositories;

namespace SharpTodoApi.Controllers;

[ApiController]
[Route("api/todo")]
public class TodoItemController : ControllerBase
{
    private readonly TodoListContext _context;
    public TodoItemController(TodoListContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAll()
    {
        List<TodoItemEntity> todoList = await _context.TodoList.ToListAsync();
        return StatusCode(200, todoList);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        TodoItemEntity todo = await _context.TodoList.FirstOrDefaultAsync(todo => todo.Id == id);
        return StatusCode(200, todo);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> Create(TodoItemEntity todoItem)
    {
        if (todoItem == null)
        {
            return StatusCode(401, new { message = "Todo item was not provided!" });
        }
        else
        {
            await _context.TodoList.AddAsync(todoItem);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateById(int id, TodoItemEntity todoItem)
    {
        TodoItemEntity todo = await _context.TodoList.Where(todo => todo.Id == id).FirstOrDefaultAsync();
        if (todo == null)
        {
            return StatusCode(400, new { message = "Todo was not found!" });
        }
        else
        {
            todo.Title = todoItem.Title.Trim();
            todo.IsComplete = todoItem.IsComplete || todo.IsComplete;
            await _context.SaveChangesAsync();
            return StatusCode(200);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        TodoItemEntity todo = await _context.TodoList.Where(todo => todo.Id == id).FirstOrDefaultAsync();
        if (todo == null)
        {
            return StatusCode(400, new { message = "Todo was not found!" });
        }
        else
        {
            _context.TodoList.Remove(todo);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }
    }
}
