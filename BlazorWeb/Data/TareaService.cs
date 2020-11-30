using Modelo.Entidades;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeb.Data
{
    public class TareaService
    {
        private readonly IRemoteService remoteService = RestService.For<IRemoteService>("https://localhost:44343/api/");

        public async Task<List<Tarea>> GetAll()
        {
            return await remoteService.GetAllTareas();
        }

        public async Task<Tarea> Get(int idTarea)
        {
            return await remoteService.GetTarea(idTarea);
        }

        public async Task<Tarea> Save(Tarea newTarea)
        {
            return await remoteService.SaveTarea(newTarea);
        }

        public async Task<Tarea> Borrar(int idTarea)
        {
            return await remoteService.DeleteTarea(idTarea);
        }
    }
}