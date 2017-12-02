#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modelo = JLLR.Core.ReglaNegocio.Servicio.Modelo;
#endregion

namespace JLLR.Core.ReglaNegocio.Servicio.Ensamblador
{
    /// <summary>
    /// 
    /// </summary>
    public class EnsambladorEntidad
    {
        #region REGLA
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.REGLA CreaRegla(modelo.ReglaModelo m)
        {

            return new entidad.REGLA()
            {
                REGLA_ID = m.ReglaId,
                PUNTO_VENTA_ID = m.PuntoVenta.PuntoVentaId,
                SUCURSAL_ID = m.Sucursal.SucursalId,
                FECHA_MODIFICACION = m.FechaModificacion,
                FECHA_CREACION = m.FechaCreacion,
                FECHA_INICIO = m.FechaInicio,
                FECHA_FIN = m.FechaFin,
                NOMBRE_REGLA = m.NombreRegla
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.REGLA> CreaReglas(List<modelo.ReglaModelo> listadoModelo)
        {
            List<entidad.REGLA> listaEntidad = new List<entidad.REGLA>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CreaRegla(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region ACCION REGLA
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.ACCION_REGLA CrearAccionRegla(modelo.AccionReglaModelo m)
        {

            return new entidad.ACCION_REGLA()
            {
               ACCION_REGLA_ID = m.AccionreglaId,
               ESTA_HABILITADO = m.EstaHabilitado,
               REGLA_ID = m.Regla.ReglaId,
               PRODUCTO_ID = m.ProductoId,
               VALOR = m.Valor,
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.ACCION_REGLA> CrearAccionReglas(List<modelo.AccionReglaModelo> listadoModelo)
        {
            List<entidad.ACCION_REGLA> listaEntidad = new List<entidad.ACCION_REGLA>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearAccionRegla(modelo));
            }
            return listaEntidad;

        }
        #endregion
    }
}