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
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;
        public UsuarioController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Usuario>> Get()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return _context.Usuarios.Where(i => i.Id == id).Single();
        }

        [HttpPost]
        public Usuario Post(Usuario newUsuario)
        {
            if (newUsuario.Id == 0)
            {
                // Agregar usuario
                _context.Usuarios.Add(newUsuario);
            }
            else
            {
                //Actualizar Usuario
                //referencia: https://stackoverflow.com/questions/9591165/ef-4-how-to-properly-update-object-in-dbcontext-using-mvc-with-repository-patte
                Usuario usuarioActulizar = _context.Usuarios
                    .Where(usuario => usuario.Id == newUsuario.Id).FirstOrDefault();
                if (usuarioActulizar != null)
                {
                    _context.Entry(usuarioActulizar).CurrentValues.SetValues(newUsuario);
                }
            }
            _context.SaveChanges();
            return newUsuario;
        }

        // Borrar usuario
        // referencia: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio#the-deletetodoitem-method
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuarioBorrar = await _context.Usuarios.FindAsync(id);
            if (usuarioBorrar == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuarioBorrar);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
