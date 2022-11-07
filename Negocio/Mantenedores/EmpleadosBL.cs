using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Modelos;
using Modelos.Mantenedores;

namespace Negocio.Mantenedores
{
    public class EmpleadosBL : ICrud<Empleados>
    {
        public ResponseExec Create(Empleados o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.Data.execData("INSERT INTO Empleados set rut=" + o.rut + ",nombre=" + o.nombre + ",apellidos=" + o.apellidos + ",id_cargo="+ o.id_cargo +",id_jefe="+ o.id_jefe +")");
                res.mensaje = "Ingreso Correcto del Departamento";
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public ResponseExec Delete(Empleados o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                //o.parametros.Add(new Datos.Parametros("@CODIGO", o.codigo));
                //o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                o.Data.execData("DELETE FROM Empleados WHERE rut = " + o.rut);
                res.mensaje = "Empleado Eliminado";
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public List<Empleados> Get(Empleados o)
        {
            List<Empleados> departamentos = new List<Empleados>();
            try
            {
                DataTable dt = o.Data.queryData("select * from Empleados");

                return convertToList(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return departamentos;
        }

        public Empleados GetById(Empleados o)
        {
            throw new NotImplementedException();
            //    Cargos cargo = new Cargos();
            //    try
            //    {

            //        DataTable dt = o.Data.execData("SELECT * FROM Cargos",o.cargos);
            //        if (dt.Rows.Count > 0)
            //        {
            //            cargo.codigo = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            //            cargo.nombre = dt.Rows[0].ItemArray[1].ToString();
            //        }
            //        else
            //        {
            //            return null;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    return cargo;
        }

        public List<Empleados> GetQuery(Empleados o)
        {
            throw new NotImplementedException();
            //List<Cargos> cargos = new List<Cargos>();
            //try
            //{
            //    DataTable dt = o.Data.execData("SELECT * FROM cargos WHERE id_cargo = "+o.cod+"");
            //    return convertToList(dt);

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //return cargos;
        }

        public ResponseExec Update(Empleados o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.Data.execData("UPDATE Empleados SET rut=" + o.rut + ", nombre=" + o.nombre + ", apellidos=" + o.apellidos + ",id_cargo="+ o.id_cargo +",id_jefe="+ o.id_jefe +"");
                res.mensaje = "Empleado Actualizado";
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public List<Empleados> convertToList(DataTable dt)
        {
            List<Empleados> listado = new List<Empleados>();

            foreach (DataRow item in dt.Rows)
            {
                Empleados o = new Empleados();
                o.rut = item.ItemArray[0].ToString();
                o.nombre = item.ItemArray[1].ToString();
                o.apellidos = item.ItemArray[2].ToString();
                o.id_cargo = int.Parse(item.ItemArray[3].ToString());
                o.id_jefe = int.Parse(item.ItemArray[4].ToString());

                listado.Add(o);
            }

            return listado;
        }
    }
}
