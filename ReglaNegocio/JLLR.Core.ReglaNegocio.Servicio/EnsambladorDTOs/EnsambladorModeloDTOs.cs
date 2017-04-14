#region using
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using entidadDTOs = JLLR.Core.ReglaNegocio.Proveedor.DTOs;
using modeloDTOs = JLLR.Core.ReglaNegocio.Servicio.DTOs;
using ensamblador = JLLR.Core.ReglaNegocio.Servicio.Ensamblador;
#endregion

namespace JLLR.Core.ReglaNegocio.Servicio.EnsambladorDTOs
{

    /// <summary>
    /// Transforma una entidad en un modelo DTO
    /// </summary>
    public class EnsambladorModeloDTOs
    {

        #region REGLA DE  NEGOCIO
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public modeloDTOs.ReglaDTOs CrearReglaNegocio(entidadDTOs.ReglaDTOs e)
        {
            return new modeloDTOs.ReglaDTOs()
            {
                ProductoId = e.ProductoId,
                NombreRegla = e.NombreRegla,
                ReglaId = e.ReglaId,
                Porcentaje = e.Porcentaje
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<modeloDTOs.ReglaDTOs> CrearReglasNegocio(IQueryable<entidadDTOs.ReglaDTOs> listadoModelo)
        {
            List<modeloDTOs.ReglaDTOs> listaEntidad = new List<modeloDTOs.ReglaDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearReglaNegocio(modelo));
            }
            return listaEntidad;

        }

        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public Collection<modeloDTOs.ReglaDTOs> CrearReglasNegocioColeccion(List<entidadDTOs.ReglaDTOs> listadoModelo)
        {
            Collection<modeloDTOs.ReglaDTOs> listaEntidad = new Collection<modeloDTOs.ReglaDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearReglaNegocio(modelo));
            }
            return listaEntidad;

        }

        #endregion

        #region PARAMETRO DE  ENTRADA
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public modeloDTOs.ParametroEntradaReglaNegocioDTOs CrearParametroEntradaReglaNegocioDtOs(entidadDTOs.ParametroEntradaReglaNegocioDTOs e)
        {
            return new modeloDTOs.ParametroEntradaReglaNegocioDTOs()
            {
                ProductoId = e.ProductoId,
                Cantidad = e.Cantidad,
                ValorTotal = e.ValorTotal,
                ValorUnitario = e.ValorUnitario,
                ValorPromocion = e.ValorPromocion,
                PuntoVentaId = e.PuntoVentaId,
                SucursalId = e.SucursalId
              
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<modeloDTOs.ParametroEntradaReglaNegocioDTOs> CrearParametrosEntradaReglaNegocioDtOs(IQueryable<entidadDTOs.ParametroEntradaReglaNegocioDTOs> listadoModelo)
        {
            List<modeloDTOs.ParametroEntradaReglaNegocioDTOs> listaEntidad = new List<modeloDTOs.ParametroEntradaReglaNegocioDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearParametroEntradaReglaNegocioDtOs(modelo));
            }
            return listaEntidad;

        }

        

        #endregion

        #region PARAMETRO DE  SALIDA
        /// <summary>
        /// Convierte el modelo DTO en una entidad DTO
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public modeloDTOs.ParametroSalidaReglaNegocioDTOs CRearParametroSalidaReglaNegocioDtOs(entidadDTOs.ParametroSalidaReglaNegocioDTOs e)
        {
            return new modeloDTOs.ParametroSalidaReglaNegocioDTOs()
            {
                ProductoId = e.ProductoId,
                Cantidad = e.Cantidad,
                ValorTotal = e.ValorTotal,
                ValorUnitario = e.ValorUnitario,
                ValorDescuento = e.ValorDescuento,
                ValorTotalPagar = e.ValorTotalPagar,
                NombrePromocion = e.NombrePromocion,
                PromocionId = e.PromocionId
               
                
            };
        }


        /// <summary>
        /// Convierte un listado de modelos  Usuario en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<modeloDTOs.ParametroSalidaReglaNegocioDTOs> CRearParametrosSalidaReglaNegocioDtOs(IQueryable<entidadDTOs.ParametroSalidaReglaNegocioDTOs> listadoModelo)
        {
            List<modeloDTOs.ParametroSalidaReglaNegocioDTOs> listaEntidad = new List<modeloDTOs.ParametroSalidaReglaNegocioDTOs>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CRearParametroSalidaReglaNegocioDtOs(modelo));
            }
            return listaEntidad;

        }

       

        #endregion
    }
}