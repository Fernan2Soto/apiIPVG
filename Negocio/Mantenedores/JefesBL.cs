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
    public class JefesBL : ICrud<jefes>
    {
        public ResponseExec Create(jefes o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.Data.execData("INSERT INTO jefes set rut=" + o.rut + ",nombre=" + o.nombre + ",apellidos=" + o.apellidos + ",id_departameto=" + o.id_departamento + ")");
                res.mensaje = "Ingreso Correcto del Jefe";
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public ResponseExec Delete(jefes o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                //o.parametros.Add(new Datos.Parametros("@CODIGO", o.codigo));
                //o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                o.Data.execData("DELETE FROM Jefes WHERE rut = " + o.rut);
                res.mensaje = "Jefe Eliminado";
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public List<jefes> Get(jefes o)
        {
            List<jefes> departamentos = new List<jefes>();
            try
            {
                DataTable dt = o.Data.queryData("select * from Jefes");

                return convertToList(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return departamentos;
        }

        public jefes GetById(jefes o)
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

        public List<jefes> GetQuery(jefes o)
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

        public ResponseExec Update(jefes o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.Data.execData("UPDATE Jefes SET rut=" + o.rut + ", nombre=" + o.nombre + ", apellidos=" + o.apellidos + ",id_departamento=" + o.id_departamento + " ");
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

        public List<jefes> convertToList(DataTable dt)
        {
            List<jefes> listado = new List<jefes>();

            foreach (DataRow item in dt.Rows)
            {
                jefes o = new jefes();
                o.rut = item.ItemArray[0].ToString();
                o.nombre = item.ItemArray[1].ToString();
                o.apellidos = item.ItemArray[2].ToString();
                o.id_departamento = int.Parse(item.ItemArray[3].ToString());

                listado.Add(o);
            }

            return listado;
        }
    }
}
