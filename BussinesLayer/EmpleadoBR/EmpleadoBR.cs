using DataLayer.DASql;
using Object.Empleado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BussinesLayer.EmpleadoBR
{
    public class EmpleadoBR
    {
        public string strConn { get; set; }
        public EmpleadoBR(string conn) => strConn = conn;


        #region get
        /// <summary>
        /// Obtiene lista de empleados
        /// </summary>
        /// <returns>Lista de empledos</returns>
        public List<EmpleadoObj> getEmpleado(EmpleadoObj empleado)
        {
            try
            {
                DataTable dt;
                List<EmpleadoObj> lst = new List<EmpleadoObj>();
                EmpleadoDA usr = new EmpleadoDA(strConn);
                dt = usr.getEmpleado(empleado);

                if (dt != null)
                {
                    foreach (DataRow p in dt.Rows)
                    {
                        EmpleadoObj us = new EmpleadoObj();
                        us.empleadoId = Convert.ToInt32(p["empleadoId"]);
                        us.nombre = p["nombre"].ToString();
                        us.apellidoPaterno = p["apellidoPaterno"].ToString();
                        us.apellidoMaterno = p["apellidoMaterno"].ToString();
                        us.edad = Convert.ToInt32(p["edad"]);
                        us.fechaNacimiento = Convert.ToDateTime(p["fechaNacimiento"]);
                        us.generoId = Convert.ToInt32(p["generoId"]);
                        us.estadoCivilId = Convert.ToInt32(p["estadoCivilId"]);
                        us.rfc = p["rfc"].ToString(); ;
                        us.direccion = p["direccion"].ToString();
                        us.email = p["email"].ToString(); ;
                        us.telefono = p["telefono"].ToString();
                        us.puestoId = Convert.ToInt32(p["puestoId"]);
                        us.puesto = p["puesto"].ToString();
                        us.fechaAlta = Convert.ToDateTime(p["fechaAlta"]);
                        if (!string.IsNullOrEmpty(p["fechaBaja"].ToString()))
                            us.fechaBaja = Convert.ToDateTime(p["fechaBaja"]);
                        lst.Add(us);
                    }
                }
                

                return lst;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        /// <summary>
        /// Obtiene lista de empleados por Id
        /// </summary>
        /// <returns>Lista de empledos por Id</returns>
        public EmpleadoObj getEmpleadoXId(int personaId)
        {
            try
            {
                DataTable dt;
                EmpleadoDA usr = new EmpleadoDA(strConn);
                EmpleadoObj us = new EmpleadoObj();

                dt = usr.getEmpleadoXId(personaId);

                if (dt != null)
                {
                    foreach (DataRow p in dt.Rows)
                    {
                        us.empleadoId = Convert.ToInt32(p["empleadoId"]);
                        us.nombre = p["nombre"].ToString();
                        us.apellidoPaterno = p["apellidoPaterno"].ToString();
                        us.apellidoMaterno = p["apellidoMaterno"].ToString();
                        us.edad = Convert.ToInt32(p["edad"]);
                        us.fechaNacimiento = Convert.ToDateTime(p["fechaNacimiento"]);
                        us.generoId = Convert.ToInt32(p["generoId"]);
                        us.estadoCivilId = Convert.ToInt32(p["estadoCivilId"]);
                        us.rfc = p["rfc"].ToString(); ;
                        us.direccion = p["direccion"].ToString(); ;
                        us.email = p["email"].ToString(); ;
                        us.telefono = p["telefono"].ToString();
                        us.puestoId = Convert.ToInt32(p["puestoId"]);
                        us.fechaAlta= Convert.ToDateTime(p["fechaAlta"]);
                        if (!string.IsNullOrEmpty(p["fechaBaja"].ToString()))
                            us.fechaBaja = Convert.ToDateTime(p["fechaBaja"]);
                    }
                }

                return us;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }


        /// <summary>
        /// Obtiene catalogo puesto
        /// </summary>
        /// <returns>Lista de puesto</returns>
        public List<CatalogoObj> getPuesto()
        {
            try
            {
                DataTable dt;
                List<CatalogoObj> lst = new List<CatalogoObj>();
                EmpleadoDA usr = new EmpleadoDA(strConn);
                dt = usr.getPuesto();

                foreach (DataRow p in dt.Rows)
                {
                    CatalogoObj us = new CatalogoObj();
                    us.id = Convert.ToInt32(p["puestoId"]);
                    us.descripcion = p["descripcion"].ToString();
                    //us.activo = Convert.ToBoolean(p["activo"]);
                    us.fechaCreacion = Convert.ToDateTime(p["fechaCreacion"]);
                    if (!string.IsNullOrEmpty(p["fechaModificacion"].ToString()))
                        us.fechaModificacion = Convert.ToDateTime(p["fechaModificacion"]);
                    lst.Add(us);
                }

                return lst;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        /// <summary>
        /// Obtiene catalogo estado civil
        /// </summary>
        /// <returns>Lista de estado civil</returns>
        public List<CatalogoObj> getEstadoCivil()
        {
            try
            {
                DataTable dt;
                List<CatalogoObj> lst = new List<CatalogoObj>();
                EmpleadoDA usr = new EmpleadoDA(strConn);
                dt = usr.getEstadoCivil();

                foreach (DataRow p in dt.Rows)
                {
                    CatalogoObj us = new CatalogoObj();
                    us.id = Convert.ToInt32(p["estadoCivilId"]);
                    us.descripcion = p["descripcion"].ToString();
                    //us.activo = Convert.ToBoolean(p["activo"]);
                    us.fechaCreacion = Convert.ToDateTime(p["fechaCreacion"]);
                    if (!string.IsNullOrEmpty(p["fechaModificacion"].ToString()))
                        us.fechaModificacion = Convert.ToDateTime(p["fechaModificacion"]);
                    lst.Add(us);
                }

                return lst;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        /// <summary>
        /// Obtiene catalogo estatus
        /// </summary>
        /// <returns>Lista de estatus</returns>
        public List<CatalogoObj> getEstatus()
        {
            try
            {
                DataTable dt;
                List<CatalogoObj> lst = new List<CatalogoObj>();
                EmpleadoDA usr = new EmpleadoDA(strConn);
                dt = usr.getEstatus();

                foreach (DataRow p in dt.Rows)
                {
                    CatalogoObj us = new CatalogoObj();
                    us.id = Convert.ToInt32(p["estatusId"]);
                    us.descripcion = p["descripcion"].ToString();
                    //us.activo = Convert.ToBoolean(p["activo"]);
                    us.fechaCreacion = Convert.ToDateTime(p["fechaCreacion"]);
                    if (!string.IsNullOrEmpty(p["fechaModificacion"].ToString()))
                        us.fechaModificacion = Convert.ToDateTime(p["fechaModificacion"]);
                    lst.Add(us);
                }

                return lst;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        /// <summary>
        /// Obtiene catalogo genero
        /// </summary>
        /// <returns>Lista de genero</returns>
        public List<CatalogoObj> getGenero()
        {
            try
            {
                DataTable dt;
                List<CatalogoObj> lst = new List<CatalogoObj>();
                EmpleadoDA usr = new EmpleadoDA(strConn);
                dt = usr.getGenero();

                foreach (DataRow p in dt.Rows)
                {
                    CatalogoObj us = new CatalogoObj();
                    us.id = Convert.ToInt32(p["generoId"]);
                    us.descripcion = p["descripcion"].ToString();
                    //us.activo = Convert.ToBoolean(p["activo"]);
                    us.fechaCreacion = Convert.ToDateTime(p["fechaCreacion"]);
                    if (!string.IsNullOrEmpty(p["fechaModificacion"].ToString()))
                        us.fechaModificacion = Convert.ToDateTime(p["fechaModificacion"]);
                    lst.Add(us);
                }

                return lst;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }
        #endregion

        #region set
        /// <summary>
        /// Inserta empleado
        /// </summary>
        /// <returns>1 si es exitoso, -1 si ocuurio un error</returns>
        public int setEmpleado(EmpleadoObj persona)
        {
            try
            {
                int r=0;
               
                EmpleadoDA usr = new EmpleadoDA(strConn);
                r = usr.setEmpleado(persona);                

                return r;
            }
            catch (Exception ex)
            {
                return -1;
                throw;
            }
        }

        /// <summary>
        /// Actualiza empleado
        /// </summary>
        /// <returns>1 si es exitoso, -1 si ocuurio un error</returns>
        public int updateEmpleado(EmpleadoObj persona)
        {
            try
            {
                int r = 0;

                EmpleadoDA usr = new EmpleadoDA(strConn);
                r = usr.updateEmpleado(persona);

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
        /// <returns>1 si es exitoso, -1 si ocuurio un error</returns>
        public int deleteEmpleado(EmpleadoObj persona)
        {
            try
            {
                int r = 0;

                EmpleadoDA usr = new EmpleadoDA(strConn);
                r = usr.deleteEmpleado(persona);

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
