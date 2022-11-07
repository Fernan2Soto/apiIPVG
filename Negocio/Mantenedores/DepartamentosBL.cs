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
    public class DepartamentosBL : ICrud<departamentos>
    {
        public ResponseExec Create(departamentos o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.Data.execData("INSERT INTO Departamentos set nombre_departamento="+ o.nombre_departamento + ",direccion="+ o.direccion + ",ciudad=" + o.ciudad + ")");
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

        public ResponseExec Delete(departamentos o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                //o.parametros.Add(new Datos.Parametros("@CODIGO", o.codigo));
                //o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                o.Data.execData("DELETE FROM Departamentos WHERE id_cargo = " + o.cod);
                res.mensaje = "Departamento Eliminado";
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public List<departamentos> Get(departamentos o)
        {
            List<departamentos> departamentos = new List<departamentos>();
            try
            {
                DataTable dt = o.Data.queryData("select * from Departamentos");

                return convertToList(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return departamentos;
        }

        public departamentos GetById(departamentos o)
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

        public List<departamentos> GetQuery(departamentos o)
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

        public ResponseExec Update(departamentos o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.Data.execData("UPDATE departamentos SET nombre_departamento=" + o.nombre_departamento + ", direccion="+ o.direccion +", ciudad="+ o.ciudad +"");
                res.mensaje = "Departamento Actualizado";
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public List<departamentos> convertToList(DataTable dt)
        {
            List<departamentos> listado = new List<departamentos>();

            foreach (DataRow item in dt.Rows)
            {
                departamentos o = new departamentos();
                o.cod = int.Parse(item.ItemArray[0].ToString());
                o.nombre_departamento = item.ItemArray[1].ToString();
                o.direccion = item.ItemArray[2].ToString();
                o.ciudad = item.ItemArray[3].ToString();
                listado.Add(o);
            }

            return listado;
        }
    }
}
