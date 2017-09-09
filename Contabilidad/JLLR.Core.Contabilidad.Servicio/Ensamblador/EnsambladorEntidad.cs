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
        #region CUENTA POR COBRAR
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
               NUMERO_FACTURA = m.NumeroFactura,
               PUNTO_VENTA_ID = m.PuntoVentaId,
               SUCURSAL_ID = m.SucursalId,
               CLIENTE_ID = m.ClienteId,
               FECHA_MODIFICACION = m.FechaModificacion,
               FECHA_VENCIMIENTO = m.FechaVencimiento,
               USUARIO_CREACION_ID = m.UsuarioCreacionId,
               USUARIO_MODIFICACION_ID = m.UsuarioModificacionId,
               NUMERO_ORDEN = m.NumeroOrden,
               SALDO = m.Saldo,
               VALOR = m.Valor,
               ESTADO_PAGO_ID = m.EstadoPagoId
                

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

        #region HISTORIAL CUENTA  POR COBRAR

        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.HISTORIAL_CUENTA_POR_COBRAR CrearHistorialCuentaPorCobrar(modelo.HistorialCuentaPorCobrarModelo m)
        {
            return new entidad.HISTORIAL_CUENTA_POR_COBRAR()
            {
                CUENTA_POR_COBRAR_ID = m.CuentaPorCobrarId,
                FECHA_COBRO = m.FechaCobro,
                HISTORIAL_CUENTA_POR_COBRAR_ID = m.HistorialCuentaPorCobrarId,
                USUARIO_ID = m.UsuarioId,
                VALOR_COBRO = m.ValorCobro,
                FORMA_PAGO_ID = m.FormaPago.FormaPagoId
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.HISTORIAL_CUENTA_POR_COBRAR> CrearHistorialCuentasPorCobrar(List<Modelo.HistorialCuentaPorCobrarModelo> listadoModelo)
        {
            List<entidad.HISTORIAL_CUENTA_POR_COBRAR> listaEntidad = new List<entidad.HISTORIAL_CUENTA_POR_COBRAR>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearHistorialCuentaPorCobrar(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region CUENTA POR PAGAR
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.CUENTA_POR_PAGAR CrearCuentaPorPagar(modelo.CuentaPorPagarModelo m)
        {
            return new entidad.CUENTA_POR_PAGAR()
            {
                CUENTA_POR_PAGAR_ID = m.CuentaPorPagarId,
                FECHA_CREACION = m.FechaCreacion,
                NUMERO_FACTURA = m.NumeroFactura,
                PUNTO_VENTA_ID = m.PuntoVentaId,
                SUCURSAL_ID = m.SucursalId,
                PROVEDOR_ID = m.ProveedorId,
                FECHA_MODIFICACION = m.FechaModificacion,
                FECHA_VENCIMIENTO = m.FechaVencimiento,
                USUARIO_CREACION_ID = m.UsuarioCreacionId,
                USUARIO_MODIFICACION_ID = m.UsuarioModificacionId,
                NUMERO_ORDEN = m.NumeroOrden,
                SALDO = m.Saldo,
                VALOR = m.Valor


            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.CUENTA_POR_PAGAR> CrearCuentasPorPagar(List<Modelo.CuentaPorPagarModelo> listadoModelo)
        {
            List<entidad.CUENTA_POR_PAGAR> listaEntidad = new List<entidad.CUENTA_POR_PAGAR>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearCuentaPorPagar(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region HISTORIAL CUENTA  POR PAGAR

        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.HISTORIAL_CUENTA_POR_PAGAR CrearHistorialCuentaPorPagar(modelo.HistorialCuentaPorPagarModelo m)
        {
            return new entidad.HISTORIAL_CUENTA_POR_PAGAR()
            {
               HISTORIAL_CUENTA_POR_PAGAR_ID = m.HistorialCuentaPorPagarId,
               CUENTA_POR_PAGAR_ID = m.CuentaPorPagarId,
               VALOR_PAGO = m.ValorPago,
               USUARIO_ID = m.UsuarioId,
               FECHA_PAGO = m.FechaPago
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.HISTORIAL_CUENTA_POR_PAGAR> CrearHistorialCuentasPorPagar(List<Modelo.HistorialCuentaPorPagarModelo> listadoModelo)
        {
            List<entidad.HISTORIAL_CUENTA_POR_PAGAR> listaEntidad = new List<entidad.HISTORIAL_CUENTA_POR_PAGAR>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearHistorialCuentaPorPagar(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region CIERRE DE MES

        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.CIERRE_MES CrearCierreMes(modelo.CierreMesModelo m)
        {
            return new entidad.CIERRE_MES()
            {
               CIERRE_MES_ID = m.CierreMesId,
               SUCURSAL_ID = m.Sucursal.SucursalId,
               PUNTO_VENTA_ID = m.PuntoVenta.PuntoVentaId,
               USUARIO_ID = m.Usuario.UsuarioId,
               CUENTA_POR_PAGAR_ID = m.CuentaPorPagar.CuentaPorPagarId,
               MES_ID = m.Mes.MesId,
               VALOR = m.Valor,
               FECHA_CREACION = m.FechaCreacion
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.CIERRE_MES> CrearCierreMeses(List<Modelo.CierreMesModelo> listadoModelo)
        {
            List<entidad.CIERRE_MES> listaEntidad = new List<entidad.CIERRE_MES>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearCierreMes(modelo));
            }
            return listaEntidad;

        }
        #endregion

        #region APLICACION DE PAGO

        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.APLICACION_PAGO CrearAplicacionPago(modelo.AplicacionPagoModelo m)
        {
            return new entidad.APLICACION_PAGO()
            {
               APLICACION_PAGO_ID = m.AplicacionPagoId,
               CIERRE_MES_ID = m.CierreMes.CierreMesId,
               VALOR = m.Valor,
               FECHA_CREACION = m.FechaCreacion,
               ESTA_VALIDADO = m.EstaValidado,
               NUMERO_DOCUMENTO = m.NumeroDocumento,
               FECHA_DEPOSITO = m.FechaDeposito,
               FECHA_VALIDACION = m.FechaValidacion,
               DOCUMENTO = m.Documento,
               USUARIO_APLICA_ID = m.UsuarioAplicaId,
               USUARIO_VALIDA_ID = m.UsuarioValidaId
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.APLICACION_PAGO> CrearAplicacionesPago(List<Modelo.AplicacionPagoModelo> listadoModelo)
        {
            List<entidad.APLICACION_PAGO> listaEntidad = new List<entidad.APLICACION_PAGO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearAplicacionPago(modelo));
            }
            return listaEntidad;

        }
        #endregion

    }
}