using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
namespace Modelos.Mantenedores
{
    public class Empleados:IDataEntity
    {
        public string rut { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int id_cargo { get; set; }
        public int id_jefe { get; set; }
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }
        public Empleados()
        {
            Data = new data();
            parametros = new List<Parametros>();
        }

    }
}
