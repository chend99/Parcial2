using Modelo.Entidades;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeb.Data
{
    public class DetalleService
    {
        private readonly IRemoteService remoteService = RestService.For<IRemoteService>("https://localhost:44343/api/");

        public async Task<List<Detalle>> GetAll()
        {
            return await remoteService.GetAllDetalles();
        }

        public async Task<Detalle> Get(int idDetalle)
        {
            return await remoteService.GetDetalle(idDetalle);
        }

        public async Task<Detalle> Save(Detalle newDetalle)
        {
            return await remoteService.SaveDetalle(newDetalle);
        }

        public async Task<Detalle> Borrar(int idDetalle)
        {
            return await remoteService.DeleteDetalle(idDetalle);
        }
    }
}