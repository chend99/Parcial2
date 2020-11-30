using Modelo.Entidades;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeb.Data
{
    public class RecursoService
    {
        private readonly IRemoteService remoteService = RestService.For<IRemoteService>("https://localhost:44343/api/");
        public async Task<List<Recurso>> GetAll()
        {
            return await remoteService.GetAllRecursos();
        }
        public async Task<Recurso> Get(int idRecurso)
        {
            return await remoteService.GetRecurso(idRecurso);
        }
        public async Task<Recurso> Save(Recurso newRecurso)
        {
            return await remoteService.SaveRecurso(newRecurso);
        }
        public async Task<Recurso> Borrar(int idRecurso)
        {
            return await remoteService.DeleteRecurso(idRecurso);
        }
    }
}
