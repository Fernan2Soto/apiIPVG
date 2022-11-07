﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
namespace Modelos.Mantenedores
{
    public class departamentos : IDataEntity
    {
        public int cod { get; set; }
        public string nombre_departamento { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }
        public departamentos()
        {
            Data = new data();
            parametros = new List<Parametros>();
        }

    }
}
