using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Recurso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
