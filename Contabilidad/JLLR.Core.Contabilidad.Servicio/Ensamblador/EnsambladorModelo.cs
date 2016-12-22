#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modelo = JLLR.Core.Contabilidad.Servicio.Modelo;
#endregion
namespace JLLR.Core.Contabilidad.Servicio.Ensamblador
{

    /// <summary>
    /// Ingresa una entidad y devuleve un modelo
    /// </summary>
    public class EnsambladorModelo
    {
        
        #region  CUENTA POR COBRAR  
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.CuentaPorCobrarModelo CrearCuentaPorPagar(entidad.CUENTA_POR_COBRAR e)
        {
           
            return new modelo.CuentaPorCobrarModelo
            {
              SucursalId = e.SUCURSAL_ID,
              PuntoVentaId = e.PUNTO_VENTA_ID,
              IndividuoId = e.INDIVIDUO_ID,
              UsuarioId = e.USUARIO_ID,
              FechaCreacion = e.FECHA_CREACION,
              EstadoCuentaPorPuntoVenta = e.ESTADO_CUENTA_POR_PUNTO_VENTA,
              CuentaPorCobrarId = e.CUENTA_POR_COBRAR_ID,
              EstadoCuentaPorSucursal = e.ESTADO_CUENTA_POR_SUCURSAL



            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.CuentaPorCobrarModelo> CrearCuentasPorPagar(IQueryable<entidad.CUENTA_POR_COBRAR> listadoEntidad)
        {
            List<modelo.CuentaPorCobrarModelo> listaModelo = new List<modelo.CuentaPorCobrarModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearCuentaPorPagar(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  DETALLE  CUENTA POR COBRAR  
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.DetalleCuentaPorCobrarModelo CrearDetalleCuentaPorPagar(entidad.DETALLE_CUENTA_POR_COBRAR e)
        {

            return new modelo.DetalleCuentaPorCobrarModelo
            {
              CuentaPorCobrarId = e.CUENTA_POR_COBRAR_ID,
              Descripcion = e.DESCRIPCION,
              UsuarioId = e.USUARIO_ID,
              FechaCreacion = e.FECHA_CREACION,
              DetalleCuentaPorCobrarId = e.DETALLE_CUENTA_POR_COBRAR_ID,
              EstadoPagoId = e.ESTADO_PAGO_ID,
              NumeroFactura = e.NUMERO_FACTURA,
              FechaCancelacion = e.FECHA_CANCELACION,
              Debito = e.DEBITO,
              Credito = e.CREDITO



            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.DetalleCuentaPorCobrarModelo> CrearDetalleCuentasPorPagar(IQueryable<entidad.DETALLE_CUENTA_POR_COBRAR> listadoEntidad)
        {
            List<modelo.DetalleCuentaPorCobrarModelo> listaModelo = new List<modelo.DetalleCuentaPorCobrarModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearDetalleCuentaPorPagar(entidad));
            }
            return listaModelo;

        }

        #endregion
    }
}