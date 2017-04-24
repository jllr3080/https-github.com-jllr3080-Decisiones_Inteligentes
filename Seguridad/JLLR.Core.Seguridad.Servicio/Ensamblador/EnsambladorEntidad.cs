#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modelo = JLLR.Core.Seguridad.Servicio.Modelo;
#endregion

namespace JLLR.Core.Seguridad.Servicio.Ensamblador
{
    public class EnsambladorEntidad
    {
        #region USUARIO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.USUARIO CrearUsuario(modelo.UsuarioModelo m)
        {
            return new entidad.USUARIO()
            {
               USUARIO_ID = m.UsuarioId,
               SUCURSAL_ID = m.Sucursal.SucursalId,
               PUNTO_VENTA_ID = m.PuntoVenta.PuntoVentaId,
               INDIVIDUO_ID = m.Individuo.IndividuoId,
               NOMBRE_USUARIO = m.NombreUsuario,
               CLAVE_USUARIO = m.ClaveUsuario,
               FECHA_CREACION = m.FechaCreacion,
               DIAS_VIGENCIA = m.DiasVigencia,
               HABILITADO = m.Habilitado,
               HABILITADO_SEGURIDAD = m.HabilitadoSeguridad
            
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.USUARIO> CrearUsuarios(List<modelo.UsuarioModelo> listadoModelo)
        {
            List<entidad.USUARIO> listaEntidad = new List<entidad.USUARIO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearUsuario(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region USUARIO PERFIL
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.USUARIO_PERFIL CrearUsuarioPerfil(modelo.UsuarioPerfilModelo m)
        {
        
            return new entidad.USUARIO_PERFIL()
            {
              USUARIO_PERFIL_ID = m.UsuarioPerfilId,
              USUARIO_ID = m.Usuario.UsuarioId,
              PERFIL_ID = m.Perfil.PerfilId
              

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.USUARIO_PERFIL> CrearUsuarioPerfiles(List<modelo.UsuarioPerfilModelo> listadoModelo)
        {
            List<entidad.USUARIO_PERFIL> listaEntidad = new List<entidad.USUARIO_PERFIL>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearUsuarioPerfil(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region PERFIL
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.PERFIL CrearPerfil(modelo.PerfilModelo m)
        {
            return new entidad.PERFIL()
            {
                PERFIL_ID = m.PerfilId,
                DESCRIPCION = m.Descripcion


            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.PERFIL> CrearPerfiles(List<modelo.PerfilModelo> listadoModelo)
        {
            List<entidad.PERFIL> listaEntidad = new List<entidad.PERFIL>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearPerfil(modelo));
            }
            return listaEntidad;

        }
        #endregion
    }
}