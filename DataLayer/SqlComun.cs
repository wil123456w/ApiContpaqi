namespace DataLayer
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    public class SqlComun
    {
        SqlConnection con;
        SqlCommand comm = new SqlCommand();

        public enum tipo
        {
            sp = 1,
            text = 2
        }

        public enum tipoParam
        {
            ent = 1,
            sal = 2
        }

        /// <summary>
        /// Se genera conxión a BD
        /// </summary>
        /// <param name="DB"></param>
        public void getDB(string DB)
        {
            con = new SqlConnection(DB);
        }

        /// <summary>
        /// Limpia parametros de command
        /// </summary>
        public void limpiarPrametro()
        {
            comm.Parameters.Clear();
        }

        /// <summary>
        /// Crea el tipo de partametro
        /// </summary>
        /// <param name="t"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public bool crearComando(tipo t, string sp)
        {
            try
            {
                if (t == tipo.sp)
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                    comm.CommandType = System.Data.CommandType.Text;

                comm.CommandText = sp;

                return true;
            }
            catch (Exception ex)
            {
                return false;
                //throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t">tipo de parametro</param>
        /// <param name="parametro">Definición de parametro</param>
        /// <param name="ti">Tipo de dato</param>
        /// <param name="valor">Valor del objeto</param>
        /// <returns>Regresa el objeto command con datos</returns>
        public bool crearParametro(tipoParam t, string parametro, SqlDbType ti, object valor)
        {
            try
            {
                if (t == tipoParam.ent)
                {

                    SqlParameter param = new SqlParameter(parametro, ti);//ParameterDirection
                    param.Direction = ParameterDirection.Input;
                    param.Value = valor;
                    comm.Parameters.Add(param);
                }

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        /// <summary>
        /// Regresa colección de datos
        /// </summary>
        /// <returns>Regresa colección de datos</returns>
        public DataTable ejecutarDataTable()
        {
            SqlDataAdapter da = null;
            try
            {
                DataSet ds = new DataSet();
                comm.Connection = con;
                da = new SqlDataAdapter(comm);
                da.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
            finally
            {
                if (da != null)
                    da.Dispose();
            }
        }

        /// <summary>
        /// Se ejecuta el comando
        /// </summary>
        /// <returns></returns>
        public int executeComando()
        {
            try
            {
                int r = 0;

                comm.Connection = con;
                con.Open();
                r = comm.ExecuteNonQuery();
                con.Close();
                return r;
            }
            catch (Exception ex)
            {
                return -1;
                throw;
            }
            finally
            {
                if (con != null)
                    con.Close();
                if (comm.Parameters.Count > 0)
                    comm.Parameters.Clear();
            }
        }
    }
}
