using Modelo.Entidades;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeb.Data
{
    public class UsuarioService
    {
        private readonly IRemoteService remoteService = RestService.For<IRemoteService>("https://localhost:44343/api/");
        public async Task<List<Usuario>> GetAll()
        {
            return await remoteService.GetAllUsuarios();
        }
        public async Task<Usuario> Get(int idUsuario)
        {
            return await remoteService.GetUsuario(idUsuario);
        }
        public async Task<Usuario> Save(Usuario newUsuario)
        {
            return await remoteService.SaveUsuario(newUsuario);
        }
        public async Task<Usuario> Borrar(int idUsuario)
        {
            return await remoteService.DeleteUsuario(idUsuario);
        }

    }
}
