using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelo.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        [MaxLength(255), MinLength(3)]
        public string Nombre { get; set; }
        [MaxLength(128), MinLength(8)]
        public string Clave { get; set; }

    }
}
