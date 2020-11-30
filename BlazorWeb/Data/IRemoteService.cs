using Modelo.Entidades;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWeb.Data
{
    public interface IRemoteService
    {
        //Usuario METHODS
        [Get("/usuario")]
        Task<List<Usuario>> GetAllUsuarios();

        [Get("/usuario/{idUsuario}")]
        Task<Usuario> GetUsuario(int idUsuario);

        [Post("/usuario")]
        Task<Usuario> SaveUsuario(Usuario newUsuario);

        [Delete("/usuario/{idUsuario}")]
        Task<Usuario> DeleteUsuario(int idUsuario);

        //Recurso METHODS
        [Get("/recurso")]
        Task<List<Recurso>> GetAllRecursos();

        [Get("/recurso/{idRecurso}")]
        Task<Recurso> GetRecurso(int idRecurso);

        [Post("/recurso")]
        Task<Recurso> SaveRecurso(Recurso newRecurso);

        [Delete("/recurso/{idRecurso}")]
        Task<Recurso> DeleteRecurso(int idRecurso);

        //Tarea METHODS
        [Get("/tarea")]
        Task<List<Tarea>> GetAllTareas();

        [Get("/tarea/{idTarea}")]
        Task<Tarea> GetTarea(int idTarea);

        [Post("/tarea")]
        Task<Tarea> SaveTarea(Tarea newTarea);

        [Delete("/tarea/{idTarea}")]
        Task<Tarea> DeleteTarea(int idTarea);

        //Detalle METHODS
        [Get("/detalle")]
        Task<List<Detalle>> GetAllDetalles();

        [Get("/detalle/{idDetalle}")]
        Task<Detalle> GetDetalle(int idDetalle);

        [Post("/detalle")]
        Task<Detalle> SaveDetalle(Detalle newDetalle);

        [Delete("/detalle/{idDetalle}")]
        Task<Detalle> DeleteDetalle(int idDetalle);
    }
}