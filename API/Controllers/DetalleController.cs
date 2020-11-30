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
    public class DetalleController : ControllerBase
    {
        private readonly DataContext _context;

        public DetalleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Detalle>> Get()
        {
            return await _context.Detalles.Include(detalle => detalle.Tarea).Include(detalle => detalle.Recurso).ToListAsync();
        }

        [HttpGet("{id}")]
        public Detalle Get(int id)
        {
            return _context.Detalles.Where(i => i.Id == id).Single();
        }

        [HttpPost]
        public Detalle Post(Detalle newDetalle)
        {
            if (newDetalle.Id == 0)
            {
                // Agregar Detalle
                _context.Detalles.Add(newDetalle);
            }
            else
            {
                //Actualizar Detalle
                //referencia: https://stackoverflow.com/questions/9591165/ef-4-how-to-properly-update-object-in-dbcontext-using-mvc-with-repository-patte
                Detalle detalleActulizar = _context.Detalles
                    .Where(detalle => detalle.Id == newDetalle.Id).FirstOrDefault();
                if (detalleActulizar != null)
                {
                    _context.Entry(detalleActulizar).CurrentValues.SetValues(newDetalle);
                }
            }
            _context.SaveChanges();
            return newDetalle;
        }

        // Borrar Detalle
        // referencia: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio#the-deletetodoitem-method
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var detalleBorrar = await _context.Detalles.FindAsync(id);
            if (detalleBorrar == null)
            {
                return NotFound();
            }

            _context.Detalles.Remove(detalleBorrar);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}