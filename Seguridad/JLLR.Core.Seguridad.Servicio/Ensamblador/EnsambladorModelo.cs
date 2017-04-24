#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.General.Servicio.Modelo;
using JLLR.Core.Individuo.Servicio.Modelo;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modelo = JLLR.Core.Seguridad.Servicio.Modelo;
#endregion

namespace JLLR.Core.Seguridad.Servicio.Ensamblador
{
    public class EnsambladorModelo
    {
        #region  USUARIO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.UsuarioModelo CrearUsuario(entidad.USUARIO e)
        {
            IndividuoModelo _individuo= new IndividuoModelo();
            _individuo.IndividuoId = Convert.ToInt32(e.INDIVIDUO_ID);

            SucursalModelo _sucursal= new SucursalModelo();
            _sucursal.SucursalId = Convert.ToInt32(e.SUCURSAL_ID);

            PuntoVentaModelo _puntoVenta= new PuntoVentaModelo();
            _puntoVenta.PuntoVentaId = Convert.ToInt32(e.PUNTO_VENTA_ID);

            return new modelo.UsuarioModelo
            {
                UsuarioId = e.USUARIO_ID,
                Individuo = _individuo,
                Sucursal = _sucursal,
                PuntoVenta = _puntoVenta,
                NombreUsuario = e.NOMBRE_USUARIO,
                FechaCreacion = e.FECHA_CREACION,
                ClaveUsuario = e.CLAVE_USUARIO,
                DiasVigencia = e.DIAS_VIGENCIA,
                Habilitado = e.HABILITADO,
                HabilitadoSeguridad = e.HABILITADO_SEGURIDAD


            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.UsuarioModelo> CrearUsuarios(IQueryable<entidad.USUARIO> listadoEntidad)
        {
            List<modelo.UsuarioModelo> listaModelo = new List<modelo.UsuarioModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearUsuario(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  USUARIO PERFIL
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.UsuarioPerfilModelo CrearUsuarioPerfil(entidad.USUARIO_PERFIL e)
        {
            modelo.UsuarioModelo _usuario= new modelo.UsuarioModelo();
            _usuario.UsuarioId = Convert.ToInt32(e.USUARIO_ID);

            Modelo.PerfilModelo _perfil= new modelo.PerfilModelo();
            _perfil.PerfilId = Convert.ToInt32(e.PERFIL_ID);
           

            return new modelo.UsuarioPerfilModelo
            {
                Usuario = _usuario,
                Perfil = _perfil,
                UsuarioPerfilId = e.USUARIO_PERFIL_ID

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.UsuarioPerfilModelo> CrearUsuarioPerfiles(IQueryable<entidad.USUARIO_PERFIL> listadoEntidad)
        {
            List<modelo.UsuarioPerfilModelo> listaModelo = new List<modelo.UsuarioPerfilModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearUsuarioPerfil(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region   PERFIL
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.PerfilModelo CrearPerfil(entidad.PERFIL e)
        {
          return new modelo.PerfilModelo
          {
              Descripcion = e.DESCRIPCION,
              PerfilId = e.PERFIL_ID

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.PerfilModelo> CrearPerfiles(IQueryable<entidad.PERFIL> listadoEntidad)
        {
            List<modelo.PerfilModelo> listaModelo = new List<modelo.PerfilModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearPerfil(entidad));
            }
            return listaModelo;

        }

        #endregion
    }
}