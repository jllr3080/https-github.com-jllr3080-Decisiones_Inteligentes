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
    /// Ingresa un modelo y devuleve una entidad
    /// </summary>
	public class EnsambladorEntidad
	{
        #region CUENTA POR PAGAR
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.CUENTA_POR_COBRAR CrearCuentaPorCobrar(modelo.CuentaPorCobrarModelo m)
        {
            return new entidad.CUENTA_POR_COBRAR()
            {
               CUENTA_POR_COBRAR_ID = m.CuentaPorCobrarId,
               FECHA_CREACION = m.FechaCreacion,
               INDIVIDUO_ID = m.IndividuoId,
               PUNTO_VENTA_ID = m.PuntoVentaId,
               SUCURSAL_ID = m.SucursalId,
               ESTADO_CUENTA_POR_SUCURSAL = m.EstadoCuentaPorSucursal,
               ESTADO_CUENTA_POR_PUNTO_VENTA = m.EstadoCuentaPorPuntoVenta,
               USUARIO_ID = m.UsuarioId

            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.CUENTA_POR_COBRAR> CrearCuentasPorCobrar(List<Modelo.CuentaPorCobrarModelo> listadoModelo)
        {
            List<entidad.CUENTA_POR_COBRAR> listaEntidad = new List<entidad.CUENTA_POR_COBRAR>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearCuentaPorCobrar(modelo));
            }
            return listaEntidad;

        }
        #endregion


        #region DETALLE CUENTA POR PAGAR
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.DETALLE_CUENTA_POR_COBRAR CrearDetalleCuentaPorCobrar(modelo.DetalleCuentaPorCobrarModelo m)
        {
            return new entidad.DETALLE_CUENTA_POR_COBRAR()
            {
               DETALLE_CUENTA_POR_COBRAR_ID = m.DetalleCuentaPorCobrarId,
               CUENTA_POR_COBRAR_ID = m.CuentaPorCobrarId,
               FECHA_CREACION = m.FechaCreacion,
               ESTADO_PAGO_ID = m.EstadoPagoId,
               FECHA_CANCELACION = m.FechaCancelacion,
               NUMERO_FACTURA = m.NumeroFactura,
               CREDITO = m.Credito,
               DESCRIPCION = m.Descripcion,
               DEBITO = m.Debito,
               USUARIO_ID = m.UsuarioId
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.DETALLE_CUENTA_POR_COBRAR> CrearDetalleCuentasPorCobrar(List<Modelo.DetalleCuentaPorCobrarModelo> listadoModelo)
        {
            List<entidad.DETALLE_CUENTA_POR_COBRAR> listaEntidad = new List<entidad.DETALLE_CUENTA_POR_COBRAR>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearDetalleCuentaPorCobrar(modelo));
            }
            return listaEntidad;

        }
        #endregion
    }
}