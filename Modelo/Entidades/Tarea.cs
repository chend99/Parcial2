using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Vencimiento { get; set; }
        public int Estimacion { get; set; }
        public int ResponsableId { get; set; }
        public Recurso Responsable { get; set; }
        public bool Estado { get; set; }
    }
}
