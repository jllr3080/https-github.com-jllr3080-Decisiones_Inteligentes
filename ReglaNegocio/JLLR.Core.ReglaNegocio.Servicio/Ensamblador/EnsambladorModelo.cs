#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.General.Servicio.Modelo;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modelo = JLLR.Core.ReglaNegocio.Servicio.Modelo;
using JLLR.Core.Inventario.Servicio.Modelo;
using JLLR.Core.Inventario.Servicio.Modelo.Parametrizacion;

#endregion

namespace JLLR.Core.ReglaNegocio.Servicio.Ensamblador
{

    public class EnsambladorModelo
    {

        #region  REGLA
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.ReglaModelo CrearRegla(entidad.REGLA e)
        {

            SucursalModelo _sucursalModelo= new SucursalModelo();
            _sucursalModelo.SucursalId = Convert.ToInt32(e.SUCURSAL_ID);

            PuntoVentaModelo _puntoVentaModelo = new PuntoVentaModelo();
            _puntoVentaModelo.PuntoVentaId = Convert.ToInt32(e.SUCURSAL_ID);

            TipoReglaModelo _tipoReglaModelo= new TipoReglaModelo();
            _tipoReglaModelo.TipoReglaId = Convert.ToInt32(e.TIPO_REGLA_ID);

            return new modelo.ReglaModelo
            {
                Sucursal = _sucursalModelo,
                FechaCreacion = e.FECHA_CREACION,
                UsuarioModificacionId = e.USUARIO_MODIFICA_ID,
                UsuarioCreacionId = e.USUARIO_CREACION_ID,
                FechaModificacion = e.FECHA_MODIFICACION,
                PuntoVenta = _puntoVentaModelo,
                FechaFin = e.FECHA_FIN,
                FechaInicio = e.FECHA_INICIO,
                NombreRegla = e.NOMBRE_REGLA,
                ReglaId = e.REGLA_ID,
                TipoRegla = _tipoReglaModelo

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.ReglaModelo> CrearReglas(IQueryable<entidad.REGLA> listadoEntidad)
        {
            List<modelo.ReglaModelo> listaModelo = new List<modelo.ReglaModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearRegla(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  ACCION REGLA
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.AccionReglaModelo CrearAccionRegla(entidad.ACCION_REGLA e)
        {

          modelo.ReglaModelo _regla= new modelo.ReglaModelo
          {
              ReglaId = Convert.ToInt32(e.REGLA_ID)
          };

            
            return new modelo.AccionReglaModelo
            {
               AccionreglaId = e.ACCION_REGLA_ID,
               Valor = e.VALOR,
               EstaHabilitado = e.ESTA_HABILITADO,
               Regla = _regla,
               ProductoId = Convert.ToInt32(e.PRODUCTO_ID)

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.AccionReglaModelo> CrearAccionReglas(List<entidad.ACCION_REGLA> listadoEntidad)
        {
            List<modelo.AccionReglaModelo> listaModelo = new List<modelo.AccionReglaModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearAccionRegla(entidad));
            }
            return listaModelo;

        }

        #endregion
    }
}