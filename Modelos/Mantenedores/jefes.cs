using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
namespace Modelos.Mantenedores
{
    public class jefes : IDataEntity
    {
        public string rut { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int id_departamento { get; set; }
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }
        public jefes()
        {
            Data = new data();
            parametros = new List<Parametros>();
        }
    }
}
