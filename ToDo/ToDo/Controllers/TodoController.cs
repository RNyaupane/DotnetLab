using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using System.Collections.Generic; // Add this using statement to use List<Todo>

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        [Route("All")]
        [ProducesResponseType(StatusCodes.Status200OK)] //To document response status
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Todo>> GetTodoLists()
        {
            var todos = new List<TodoDTO>();
            foreach(var item in TodoRepository.Todos)
            {
                TodoDTO todosItem = new TodoDTO();
                {
                    todosItem.Id = item.Id; 
                    todosItem.Title = item.Title;
                    todosItem.Description = item.Description;
                    todosItem.Created= DateTime.Now;
                    todosItem.Updated= DateTime.Now;
                }
            }

            return Ok(TodoRepository.Todos);
        }


        [HttpGet("{title}", Name ="GetTodoByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)] //To document response status
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetTodoListByName([FromRoute] string title)
        {
            if(string.IsNullOrEmpty(title)) return BadRequest();
            var todo = TodoRepository.Todos.FirstOrDefault(n => n.Title == title);

            if (todo == null)
            {
                return NotFound($"The Todo list with title {title} not found"); // Returns a 404 
            }

            return Ok(todo); // Returns a 200
        }



        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)] //To document response status
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetTodoListById(int id)
        {
            if(id<=0) return BadRequest();

            var todo = TodoRepository.Todos.FirstOrDefault(n => n.Id == id);

            if (todo == null)
            {
                return NotFound($"The Todo list with id {id} not found"); // Returns a 404 
            }

            return Ok(todo); // Returns a 200
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)] //To document response status
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // HttpDelete("{id:min(1):max(5)}")
        public IActionResult DeleteTodoListById(int id)
        {
            if (id <= 0) return BadRequest();

            var todoToDelete = TodoRepository.Todos.FirstOrDefault(n => n.Id == id);

            if (todoToDelete == null)
            {
                return NotFound($"The Todo list with id {id} not found"); 
            }
            TodoRepository.Todos.Remove(todoToDelete);
            return NoContent();
        }
    }
}
