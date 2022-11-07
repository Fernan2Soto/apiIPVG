using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Modelos.Mantenedores
{
    public class Cargos : IDataEntity
    {
        public int cod { get; set; }
        public string nombre { get; set; }
        public data Data { get; set; }
        public List<Cargos> cargos { get; set; }
        public Cargos()
        {
            Data = new data();
            cargos = new List<Cargos>();
        }
    }
}
