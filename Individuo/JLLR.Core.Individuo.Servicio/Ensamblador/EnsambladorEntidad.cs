#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modelo = JLLR.Core.Individuo.Servicio.Modelo;
#endregion

namespace JLLR.Core.Individuo.Servicio.Ensamblador
{
    /// <summary>
    /// Ingresa un modelo y devuleve una entidad
    /// </summary>
    public class EnsambladorEntidad
    {
        #region INDIVIDUO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.INDIVIDUO CrearIndividuo(modelo.IndividuoModelo m)
        {
            return new entidad.INDIVIDUO()
            {
                INDIVIDUO_ID = m.IndividuoId,
                TIPO_IDENTIFICACION_ID = m.TipoIdentificacion.TipoIdentificacionId,
                TIPO_INDIVIDUO_ID = m.TipoIndividuo.TipoIndividuoId,
                PRIMER_CAMPO = m.PrimerCampo,
                SEGUNDO_CAMPO = m.SegundoCampo,
                TERCER_CAMPO = m.TercerCampo,
                CUARTO_CAMPO = m.CuartoCampo,
                HABILITADO = m.Habilitado,
                NUMERO_IDENTIFICACION = m.NumeroIdentificacion,
                FECHA_CREACION = m.FechaCreacion,
                FECHA_MODIFICACION = m.FechaModificacion,
                USUARIO_ID = m.UsuarioId

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.INDIVIDUO> CrearIndividuos(List<modelo.IndividuoModelo> listadoModelo)
        {
            List<entidad.INDIVIDUO> listaEntidad = new List<entidad.INDIVIDUO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearIndividuo(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region INDIVIDUO ROL
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.INDIVIDUO_ROL CrearIndividuoRol(modelo.IndividuoRolModelo m)
        {
            return new entidad.INDIVIDUO_ROL()
            {
                INDIVIDUO_ID = m.IndividuoId,
                INDIVIDUO_ROL_ID = m.IndividuoRolId,
                TIPO_ROL_INDIVIDUO_ID = m.TipoRolIndividuo.TipoRolIndividuoId

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.INDIVIDUO_ROL> CrearIndividuoRoles(List<modelo.IndividuoRolModelo> listadoModelo)
        {
            List<entidad.INDIVIDUO_ROL> listaEntidad = new List<entidad.INDIVIDUO_ROL>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearIndividuoRol(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region CLIENTE
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.CLIENTE CrearCliente(modelo.ClienteModelo m)
        {
            return new entidad.CLIENTE()
            {
               CLIENTE_ID = m.ClienteId,
               INDIVIDUO_ID = m.Individuo.IndividuoId,
               TIPO_GENERO_ID = m.TipoGenero.TipoGeneroId,
               FECHA_NACIMIENTO = m.FechaNacimiento

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>
        public List<entidad.CLIENTE> CrearClientes(List<modelo.ClienteModelo> listadoModelo)
        {
            List<entidad.CLIENTE> listaEntidad = new List<entidad.CLIENTE>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearCliente(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region CORREO ELECTRONICO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.E_MAIL CrearCorreoElectronico(modelo.CorreoElectronicoModelo m)
        {
            return new entidad.E_MAIL()
            {
              E_MAIL_ID = m.CorreoElectronicoId,
              INDIVIDUO_ID = m.Individuo.IndividuoId,
              TIPO_CORREO_ELECTRONICO_ID = m.TipoCorreoElectronico.TipoCorreoElectronicoId,
              DIRECCION_CORREO_ELECTRONICO = m.DireccionCorreoElectronico

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>
        public List<entidad.E_MAIL> CrearCorreosElectronico(List<modelo.CorreoElectronicoModelo> listadoModelo)
        {
            List<entidad.E_MAIL> listaEntidad = new List<entidad.E_MAIL>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearCorreoElectronico(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region DIRECCION
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.DIRECCION CrearDireccion(modelo.DireccionModelo m)
        {
            return new entidad.DIRECCION()
            {
              DIRECCION_ID = m.DireccionId,
              PAIS_ID = m.Pais.PaisId,
              ESTADO_ID = m.Estado.EstadoId,
              CIUDAD_ID = m.Ciudad.CiudadId,
              INDIVIDUO_ID = m.Individuo.IndividuoId,
              TIPO_DIRECCION_ID = m.TipoDireccion.TipoDireccionId,
              DESCRIPCION_DIRECCION=m.DescripcionDireccion

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>
        public List<entidad.DIRECCION> CrearDirecciones(List<modelo.DireccionModelo> listadoModelo)
        {
            List<entidad.DIRECCION> listaEntidad = new List<entidad.DIRECCION>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearDireccion(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region TELEFONO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.TELEFONO CrearTelefono(modelo.TelefonoModelo m)
        {
            return new entidad.TELEFONO()
            {
              TELEFONO_ID = m.TelefonoId,
              INDIVIDUO_ID = m.Individuo.IndividuoId,
              TIPO_TELEFONO_ID = m.TipoTelefono.TipoTelefonoId,
               NUMERO_TELEFONO = m.NumeroTelefono

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>
        public List<entidad.TELEFONO> CrearTelefonos(List<modelo.TelefonoModelo> listadoModelo)
        {
            List<entidad.TELEFONO> listaEntidad = new List<entidad.TELEFONO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearTelefono(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region PROVEEDOR
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.PROVEEDOR CrearProveedor(modelo.ProveedorModelo m)
        {
            return new entidad.PROVEEDOR()
            {
                INDIVIDUO_ID = m.Individuo.IndividuoId,
                FORMA_PAGO_ID =  m.FormaPago.FormaPagoId,
                PROVEEDOR_ID = m.ProveedorId,
                DIAS_CREDITO = m.DiasCredito


            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>
        public List<entidad.PROVEEDOR> CrearProveedores(List<modelo.ProveedorModelo> listadoModelo)
        {
            List<entidad.PROVEEDOR> listaEntidad = new List<entidad.PROVEEDOR>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearProveedor (modelo));
            }
            return listaEntidad;

        }
        #endregion

    }
}