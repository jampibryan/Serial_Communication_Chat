using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windLaboratorio001
{
    class ClaseArchivo
    {
        public int Num { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public long Tamaño { get; set; }
        public long Avance { get; set; }
        public Boolean primeraTramaActiva { get; set; }

        //RUTA COMPLETA DEL NUEVO ARCHIVO
        public string newNombreCompleto { get; set; }
        public int longitudNombre { get; set; }

        //-----TAMAÑO
        public string tamañoString { get; set; }
        public int longitudTamaño { get; set; }
    }
}
