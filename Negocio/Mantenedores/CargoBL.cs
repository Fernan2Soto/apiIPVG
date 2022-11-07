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
    public class CargoBL : ICrud<Cargos>
    {
        public ResponseExec Create(Cargos o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.Data.execData("INSERT INTO Cargos(nombre) values("+o.nombre+")");
                res.mensaje = "Ingreso Correcto del Cargo";
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public ResponseExec Delete(Cargos o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                //o.parametros.Add(new Datos.Parametros("@CODIGO", o.codigo));
                //o.parametros.Add(new Datos.Parametros("@MENSAJE", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                o.Data.execData("DELETE FROM Cargos WHERE id_cargo = "+ o.cod);
                res.mensaje = "Cargo Eliminado";
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public List<Cargos> Get(Cargos o)
        {
            List<Cargos> cargos = new List<Cargos>();
            try
            {
                DataTable dt = o.Data.queryData("select * from cargos");

                return convertToList(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cargos;
        }

        public Cargos GetById(Cargos o)
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

        public List<Cargos> GetQuery(Cargos o)
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

        public ResponseExec Update(Cargos o)
        {
            ResponseExec res = new ResponseExec();
            res.mensaje = "";
            try
            {
                o.Data.execData("UPDATE cargos SET nombre="+o.nombre);
                res.mensaje = "Cargo Actualizado";
                return res;
            }
            catch (Exception ex)
            {
                res.error = true;
                res.mensaje = ex.Message;
                return res;
            }
        }

        public List<Cargos> convertToList(DataTable dt)
        {
            List<Cargos> listado = new List<Cargos>();

            foreach (DataRow item in dt.Rows)
            {
                Cargos o = new Cargos();
                o.cod = int.Parse(item.ItemArray[0].ToString());
                o.nombre = item.ItemArray[1].ToString();
                listado.Add(o);
            }

            return listado;
        }
    }
}
