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
    public class RecursoController : ControllerBase
    {
        private readonly DataContext _context;
        public RecursoController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Recurso> Get()
        {
            return _context.Recursos.Include(recurso => recurso.Usuario).ToList();
        }

        [HttpGet("{id}")]
        public Recurso Get(int id)
        {
            return _context.Recursos.Where(recurso => recurso.Id == id).Single();
        }

        [HttpPost]
        public Recurso Post(Recurso newRecurso)
        {
            if (newRecurso.Id == 0)
            {
                // Agregar Recurso
                _context.Recursos.Add(newRecurso);
            }
            else
            {
                //Actualizar Recurso
                //referencia: https://stackoverflow.com/questions/9591165/ef-4-how-to-properly-update-object-in-dbcontext-using-mvc-with-repository-patte
                Recurso recursoActulizar = _context.Recursos
                    .Where(recurso => recurso.Id == newRecurso.Id).FirstOrDefault();

                if (recursoActulizar != null)
                {
                    _context.Entry(recursoActulizar).CurrentValues.SetValues(newRecurso);
                }
            }
            _context.SaveChanges();
            return newRecurso;
        }

        // Borrar Recurso
        // referencia: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio#the-deletetodoitem-method
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var recursoBorrar = await _context.Recursos.FindAsync(id);
            if (recursoBorrar == null)
            {
                return NotFound();
            }

            _context.Recursos.Remove(recursoBorrar);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
