using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using TodoList.Context;
using TodoList.Entities;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IActionResult Listado()
        {
            

            return Ok(_context.Todo.ToList());
        }

        [HttpGet]
        [Route ("ListadoFiltrado")]
        public IActionResult ListadoFiltradoPorId(int id, string descripcion,bool estado)
        {
            var list = _context.Todo.Where(x => x.Id==id && x.Descripcion.Contains($"{descripcion}") && x.Estado==estado);

            return Ok(list);

        }



        [HttpPost]
        public IActionResult Post([FromBody]Todo todo)
        {
            _context.Todo.Add(todo);
            _context.SaveChanges();

            return Ok(_context.Todo.ToList());
        }


        [HttpPut]

        public IActionResult Put(Todo todo)
        {
            var list = _context.Todo.Find(todo.Id);
            list.Id = todo.Id;
            list.Descripcion=todo.Descripcion;
            list.Estado=todo.Estado;
            list.Archivo = todo.Archivo;
            _context.Todo.Add(list);
            _context.SaveChanges();

            return Ok("se modifico correctamente");

        }





    }
}


