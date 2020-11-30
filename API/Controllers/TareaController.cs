using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly DataContext _context;

        public TareaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Tarea>> Get()
        {
            return await _context.Tareas.Include(tarea => tarea.Responsable).ToListAsync();
        }

        [HttpGet("{id}")]
        public Tarea Get(int id)
        {
            return _context.Tareas.Where(i => i.Id == id).Single();
        }

        [HttpPost]
        public Tarea Post(Tarea newTarea)
        {
            if (newTarea.Id == 0)
            {
                // Agregar Tarea
                _context.Tareas.Add(newTarea);
            }
            else
            {
                //Actualizar Tarea
                //referencia: https://stackoverflow.com/questions/9591165/ef-4-how-to-properly-update-object-in-dbcontext-using-mvc-with-repository-patte
                Tarea tareaActulizar = _context.Tareas
                    .Where(tarea => tarea.Id == newTarea.Id).FirstOrDefault();
                if (tareaActulizar != null)
                {
                    _context.Entry(tareaActulizar).CurrentValues.SetValues(newTarea);
                }
            }
            _context.SaveChanges();
            return newTarea;
        }

        // Borrar Tarea
        // referencia: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio#the-deletetodoitem-method
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tareaBorrar = await _context.Tareas.FindAsync(id);
            if (tareaBorrar == null)
            {
                return NotFound();
            }

            _context.Tareas.Remove(tareaBorrar);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}