#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.Seguridad.Servicio.Modelo;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modelo = JLLR.Core.Contabilidad.Servicio.Modelo;
using modeloGeneral = JLLR.Core.General.Servicio.Modelo;
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
        public modelo.CuentaPorCobrarModelo CrearCuentaPorCobrar(entidad.CUENTA_POR_COBRAR e)
        {
           
            return new modelo.CuentaPorCobrarModelo
            {
              SucursalId = e.SUCURSAL_ID,
              PuntoVentaId = e.PUNTO_VENTA_ID,
              FechaCreacion = e.FECHA_CREACION,
              ClienteId = e.CLIENTE_ID,
              CuentaPorCobrarId = e.CUENTA_POR_COBRAR_ID,
              NumeroFactura = e.NUMERO_FACTURA,
              Valor = e.VALOR,
              FechaVencimiento = e.FECHA_VENCIMIENTO,
              UsuarioModificacionId = e.USUARIO_MODIFICACION_ID,
              UsuarioCreacionId = e.USUARIO_CREACION_ID,
              NumeroOrden = e.NUMERO_ORDEN,
              Saldo = e.SALDO,
              FechaModificacion = e.FECHA_MODIFICACION,
              EstadoPagoId = e.ESTADO_PAGO_ID


            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.CuentaPorCobrarModelo> CrearCuentasPorCobrar(IQueryable<entidad.CUENTA_POR_COBRAR> listadoEntidad)
        {
            List<modelo.CuentaPorCobrarModelo> listaModelo = new List<modelo.CuentaPorCobrarModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearCuentaPorCobrar(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  HISTORIAL  CUENTA POR COBRAR  
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.HistorialCuentaPorCobrarModelo CrearHistorialCuentaPorCobrar(entidad.HISTORIAL_CUENTA_POR_COBRAR e)
        {
            modeloGeneral.FormaPagoModelo _formaPago = new modeloGeneral.FormaPagoModelo()
            {
                FormaPagoId = Convert.ToInt32( e.FORMA_PAGO_ID)
            };


            return new modelo.HistorialCuentaPorCobrarModelo
            {
                UsuarioId = e.USUARIO_ID,
                CuentaPorCobrarId = e.CUENTA_POR_COBRAR_ID,
                HistorialCuentaPorCobrarId = e.HISTORIAL_CUENTA_POR_COBRAR_ID,
                FechaCobro = e.FECHA_COBRO,
                ValorCobro = e.VALOR_COBRO,
                FormaPago = _formaPago

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.HistorialCuentaPorCobrarModelo> CrearHistorialCuentasPorCobrar(IQueryable<entidad.HISTORIAL_CUENTA_POR_COBRAR> listadoEntidad)
        {
            List<modelo.HistorialCuentaPorCobrarModelo> listaModelo = new List<modelo.HistorialCuentaPorCobrarModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearHistorialCuentaPorCobrar(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  CUENTA POR PAGAR  
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.CuentaPorPagarModelo CrearCuentaPorPagar(entidad.CUENTA_POR_PAGAR e)
        {

            return new modelo.CuentaPorPagarModelo
            {
                SucursalId = e.SUCURSAL_ID,
                PuntoVentaId = e.PUNTO_VENTA_ID,
                FechaCreacion = e.FECHA_CREACION,
                ProveedorId = e.PROVEDOR_ID,
                CuentaPorPagarId= e.CUENTA_POR_PAGAR_ID,
                NumeroFactura = e.NUMERO_FACTURA,
                Valor = e.VALOR,
                FechaVencimiento = e.FECHA_VENCIMIENTO,
                UsuarioModificacionId = e.USUARIO_MODIFICACION_ID,
                UsuarioCreacionId = e.USUARIO_CREACION_ID,
                NumeroOrden = e.NUMERO_ORDEN,
                Saldo = e.SALDO,
                FechaModificacion = e.FECHA_MODIFICACION


            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.CuentaPorPagarModelo> CrearCuentasPorPagar(IQueryable<entidad.CUENTA_POR_PAGAR> listadoEntidad)
        {
            List<modelo.CuentaPorPagarModelo> listaModelo = new List<modelo.CuentaPorPagarModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearCuentaPorPagar(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  HISTORIAL  CUENTA POR COBRAR  
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.HistorialCuentaPorPagarModelo CrearHistorialCuentaPorPagar(entidad.HISTORIAL_CUENTA_POR_PAGAR e)
        {

            return new modelo.HistorialCuentaPorPagarModelo
            {
                UsuarioId = e.USUARIO_ID,
               CuentaPorPagarId = e.CUENTA_POR_PAGAR_ID,
               FechaPago = e.FECHA_PAGO,
               ValorPago = e.VALOR_PAGO,
               HistorialCuentaPorPagarId = e.HISTORIAL_CUENTA_POR_PAGAR_ID
            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.HistorialCuentaPorPagarModelo> CrearHistorialCuentasPorPagar(IQueryable<entidad.HISTORIAL_CUENTA_POR_PAGAR> listadoEntidad)
        {
            List<modelo.HistorialCuentaPorPagarModelo> listaModelo = new List<modelo.HistorialCuentaPorPagarModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearHistorialCuentaPorPagar(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  CIERRE MES
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.CierreMesModelo CrearCierre(entidad.CIERRE_MES e)
        {
            modeloGeneral.SucursalModelo _sucursal = new modeloGeneral.SucursalModelo()
            {
                SucursalId = Convert.ToInt32(e.SUCURSAL_ID)
            };

            modeloGeneral.PuntoVentaModelo _puntoVenta = new modeloGeneral.PuntoVentaModelo()
            {
                PuntoVentaId = Convert.ToInt32(e.PUNTO_VENTA_ID)
            };
            UsuarioModelo _usuario = new UsuarioModelo()
            {
                UsuarioId = Convert.ToInt32(e.USUARIO_ID)
            };
            modelo.CuentaPorPagarModelo _cuentaPorPagar = new modelo.CuentaPorPagarModelo()
            {
                CuentaPorPagarId = Convert.ToInt32(e.CUENTA_POR_PAGAR_ID)
            };

            modeloGeneral.MesModelo _mes = new modeloGeneral.MesModelo()
            {
                MesId = Convert.ToInt32(e.MES_ID)
            };



            return new modelo.CierreMesModelo
            {
                CierreMesId = e.CIERRE_MES_ID,
                Sucursal = _sucursal,
                CuentaPorPagar = _cuentaPorPagar,
                FechaCreacion = e.FECHA_CREACION,
                Valor = e.VALOR,
                PuntoVenta = _puntoVenta,
                Usuario = _usuario,
                Mes = _mes

             
            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.CierreMesModelo> CrearCierres(IQueryable<entidad.CIERRE_MES> listadoEntidad)
        {
            List<modelo.CierreMesModelo> listaModelo = new List<modelo.CierreMesModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearCierre(entidad));
            }
            return listaModelo;

        }

        #endregion

        #region  APLICACION DE  PAGO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.AplicacionPagoModelo CrearAplicacionPago(entidad.APLICACION_PAGO e)
        {


            modelo.CierreMesModelo cierreMes = new modelo.CierreMesModelo()
            {
                CierreMesId = Convert.ToInt32(e.CIERRE_MES_ID)
            };


            return new modelo.AplicacionPagoModelo
            {
               FechaCreacion = e.FECHA_CREACION,
               Valor = e.VALOR,
               CierreMes = cierreMes,
               NumeroDocumento = e.NUMERO_DOCUMENTO,
               EstaValidado = e.ESTA_VALIDADO,
               AplicacionPagoId = e.APLICACION_PAGO_ID,
               FechaDeposito = e.FECHA_DEPOSITO,
               UsuarioAplicaId = e.USUARIO_APLICA_ID,
               Documento = e.DOCUMENTO,
               FechaValidacion = e.FECHA_VALIDACION,
               UsuarioValidaId = e.USUARIO_VALIDA_ID



            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.AplicacionPagoModelo> CrearAplicacionesPago(IQueryable<entidad.APLICACION_PAGO> listadoEntidad)
        {
            List<modelo.AplicacionPagoModelo> listaModelo = new List<modelo.AplicacionPagoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearAplicacionPago(entidad));
            }
            return listaModelo;

        }

        #endregion

    }
}