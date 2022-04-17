namespace DataLayer.DASql
{
    using Object.Empleado;
    using System;
    using System.Data;
    public class EmpleadoDA : SqlComun
    {
        public string strConn { get; set; }
        public EmpleadoDA(string conn) => strConn = conn;

        #region get
        /// <summary>
        /// Obtiene todos los empleados
        /// </summary>
        /// <returns>Lista de empleados</returns>
        public DataTable getEmpleado(EmpleadoObj empleado)
        {
            try
            {
                DataTable dt = new DataTable();
                getDB(strConn);
                limpiarPrametro();
                if (empleado.nombre != null)
                    crearParametro(tipoParam.ent, "nombre", SqlDbType.NVarChar, empleado.nombre);
                if (empleado.rfc != null)
                    crearParametro(tipoParam.ent, "rfc", SqlDbType.NVarChar, empleado.rfc);
                if (empleado.estatusId != null)
                    crearParametro(tipoParam.ent, "estatus", SqlDbType.Int, empleado.estatusId);
                crearComando(tipo.sp, "sp_GetEmpleado");
                dt = ejecutarDataTable();

                return dt;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los empleados por Id
        /// </summary>
        /// <returns>Lista de empleados por Id</returns>
        public DataTable getEmpleadoXId(int personaId)
        {
            try
            {
                DataTable dt = new DataTable();
                getDB(strConn);
                limpiarPrametro();
                crearParametro(tipoParam.ent, "empleadoId", SqlDbType.Int, personaId);
                crearComando(tipo.sp, "sp_GetEmpleadoXId");
                dt = ejecutarDataTable();

                return dt;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        /// <summary>
        /// Obtiene catalogo puesto
        /// </summary>
        /// <returns>Lista de puesto</returns>
        public DataTable getPuesto()
        {
            try
            {
                DataTable dt = new DataTable();
                getDB(strConn);
                crearComando(tipo.sp, "sp_GetPuesto");
                dt = ejecutarDataTable();

                return dt;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        /// <summary>
        /// Obtiene catalogo estado civil
        /// </summary>
        /// <returns>Lista de estado civil</returns>
        public DataTable getEstadoCivil()
        {
            try
            {
                DataTable dt = new DataTable();
                getDB(strConn);
                crearComando(tipo.sp, "sp_GetEstadoCivil");
                dt = ejecutarDataTable();

                return dt;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        /// <summary>
        /// Obtiene catalogo estatus
        /// </summary>
        /// <returns>Lista de estatus</returns>
        public DataTable getEstatus()
        {
            try
            {
                DataTable dt = new DataTable();
                getDB(strConn);
                crearComando(tipo.sp, "sp_GetEstatus");
                dt = ejecutarDataTable();

                return dt;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        /// <summary>
        /// Obtiene catalogo genero
        /// </summary>
        /// <returns>Lista de genero</returns>
        public DataTable getGenero()
        {
            try
            {
                DataTable dt = new DataTable();
                getDB(strConn);
                crearComando(tipo.sp, "sp_GetGenero");
                dt = ejecutarDataTable();

                return dt;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        #endregion

        #region Set
        /// <summary>
        /// inserta empleado
        /// </summary>
        /// <returns>-1 si hay error, > 0 si es correcto</returns>
        public int setEmpleado(EmpleadoObj persona)
        {
            try
            {
                int r = 0;
                DataTable dt = new DataTable();
                getDB(strConn);
                limpiarPrametro();
                crearParametro(tipoParam.ent, "nombre", SqlDbType.NVarChar, persona.nombre);
                crearParametro(tipoParam.ent, "apellidoPaterno", SqlDbType.NVarChar, persona.apellidoPaterno);
                crearParametro(tipoParam.ent, "apellidoMaterno", SqlDbType.NVarChar, persona.apellidoMaterno);
                crearParametro(tipoParam.ent, "edad", SqlDbType.Int, persona.edad);
                crearParametro(tipoParam.ent, "fechaNacimiento", SqlDbType.DateTime, persona.fechaNacimiento);
                crearParametro(tipoParam.ent, "generoId", SqlDbType.Int, persona.generoId);
                crearParametro(tipoParam.ent, "estadoCivilId", SqlDbType.Int, persona.estadoCivilId);
                crearParametro(tipoParam.ent, "rfc", SqlDbType.NVarChar, persona.rfc);
                crearParametro(tipoParam.ent, "direccion", SqlDbType.NVarChar, persona.direccion);
                crearParametro(tipoParam.ent, "email", SqlDbType.NVarChar, persona.email);
                crearParametro(tipoParam.ent, "telefono", SqlDbType.NVarChar, persona.telefono);
                crearParametro(tipoParam.ent, "puestoId", SqlDbType.Int, persona.puestoId);
                //crearParametro(tipoParam.ent, "estatusId", SqlDbType.Int, persona.estatusId);
                crearComando(tipo.sp, "sp_InsertEmpleado");
                r = executeComando();

                return r;

                
            }
            catch (Exception ex)
            {
                return -1;
                throw;
            }
        }

        /// <summary>
        /// actualiza empleado
        /// </summary>
        /// <returns>-1 si hay error, > 0 si es correcto</returns>
        public int updateEmpleado(EmpleadoObj persona)
        {
            try
            {
                int r = 0;
                DataTable dt = new DataTable();
                getDB(strConn);
                limpiarPrametro();
                crearParametro(tipoParam.ent, "empleadoId", SqlDbType.Int, persona.empleadoId);
                //crearParametro(tipoParam.ent, "nombre", SqlDbType.NVarChar, persona.nombre);
                //crearParametro(tipoParam.ent, "apellidoPaterno", SqlDbType.NVarChar, persona.apellidoPaterno);
                //crearParametro(tipoParam.ent, "apellidoMaterno", SqlDbType.NVarChar, persona.apellidoMaterno);
                //crearParametro(tipoParam.ent, "edad", SqlDbType.Int, persona.edad);
                //crearParametro(tipoParam.ent, "fechaNacimiento", SqlDbType.DateTime, persona.fechaNacimiento);
                //crearParametro(tipoParam.ent, "generoId", SqlDbType.Int, persona.generoId);
                crearParametro(tipoParam.ent, "estadoCivilId", SqlDbType.Int, persona.estadoCivilId);
                //crearParametro(tipoParam.ent, "rfc", SqlDbType.NVarChar, persona.rfc);
                crearParametro(tipoParam.ent, "direccion", SqlDbType.NVarChar, persona.direccion);
                crearParametro(tipoParam.ent, "email", SqlDbType.NVarChar, persona.email);
                //crearParametro(tipoParam.ent, "telefono", SqlDbType.NVarChar, persona.telefono);
                crearParametro(tipoParam.ent, "puestoId", SqlDbType.Int, persona.puestoId);

                if(persona.fechaBaja.Year != 0001)
                    crearParametro(tipoParam.ent, "fechaBaja", SqlDbType.DateTime, persona.fechaBaja);
                else
                    crearParametro(tipoParam.ent, "fechaBaja", SqlDbType.DateTime, null);
                //crearParametro(tipoParam.ent, "estatusId", SqlDbType.Int, persona.estatusId);
                crearComando(tipo.sp, "sp_UpdateEmpleado");
                r = executeComando();

                return r;


            }
            catch (Exception ex)
            {
                return -1;
                throw;
            }
        }

        /// <summary>
        /// Actualiza la fecha de baja de empleado
        /// </summary>
        /// <returns>-1 si hay error, > 0 si es correcto</returns>
        public int deleteEmpleado(EmpleadoObj persona)
        {
            try
            {
                int r = 0;
                DataTable dt = new DataTable();
                getDB(strConn);
                limpiarPrametro();
                crearParametro(tipoParam.ent, "empleadoId", SqlDbType.Int, persona.empleadoId);                
                crearComando(tipo.sp, "sp_DeleteEmpleado");
                r = executeComando();

                return r;


            }
            catch (Exception ex)
            {
                return -1;
                throw;
            }
        }

        #endregion

    }
}
