using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class TodoController(StoreContext context, IMapper mapper) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetTodos()
        {
            return await context.TodoItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodo(int id)
        {
            var todoItem = await context.TodoItems.FindAsync(id);

            if (todoItem == null) return NotFound();

            return todoItem;
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateTodo(CreateTodoDto todoDto)
        {
            var todo = mapper.Map<TodoItem>(todoDto);

            context.TodoItems.Add(todo);

            var result = await context.SaveChangesAsync() > 0;

            if (result) return CreatedAtAction(nameof(GetTodo), new { Id = todo.Id }, todo);

            return BadRequest("Problem creating new todo");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTodo(UpdateTodoDto updateTodoDto)
        {
            var todo = await context.TodoItems.FindAsync(updateTodoDto.Id);

            if (todo == null) return NotFound();

            mapper.Map(updateTodoDto, todo);

            var result = await context.SaveChangesAsync() > 0;

            if (result) return NoContent();

            return BadRequest("Problem updating todo");
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            var todo = await context.TodoItems.FindAsync(id);

            if (todo == null) return NotFound();

            context.TodoItems.Remove(todo);

            var result = await context.SaveChangesAsync() > 0;

            if (result) return Ok();

            return BadRequest("Problem deleting the todo");
        }

    }
}
