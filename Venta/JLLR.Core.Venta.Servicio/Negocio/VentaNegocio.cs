#region using
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using JLLR.Core.Contabilidad.Servicio.DTOs;
using JLLR.Core.Contabilidad.Servicio.Modelo;
using JLLR.Core.FlujoProceso.Servicio.Modelo;
using JLLR.Core.General.Servicio.Modelo;
using JLLR.Core.Venta.Servicio.DTOs;
using JLLR.Core.Venta.Servicio.Ensamblador;
using JLLR.Core.Venta.Servicio.EnsambladorDTOs;
using JLLR.Core.Venta.Servicio.Modelo;
using JLLR.Core.Venta.Servicio.Modelo.Parametrizacion;
using JLLR.Core.Venta.Servicio.ServicioDelegado;
using JLLR.Core.Venta.Servicio.Transformador;
using Enum = JLLR.Core.Venta.Servicio.Enums.Enum;

#endregion
namespace JLLR.Core.Venta.Servicio.Negocio
{
    public class VentaNegocio
    {

        #region  Declaraciones  e INstancias
        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private readonly  VentaTransfomadorNegocio _ventaTransfomadorNegocio= new VentaTransfomadorNegocio();
        private readonly  ServicioDelegadoContabilidad _servicioDelegadoContabilidad= new ServicioDelegadoContabilidad();
        private  readonly  ServicioDelegadoFlujoProceso _servicioDelegadoFlujoProceso= new ServicioDelegadoFlujoProceso();
        private readonly EnsambladorEntidadDTOs _ensambladorEntidadDTOs = new EnsambladorEntidadDTOs();
        private readonly EnsambladorModeloDTOs _ensambladorModeloDTOs = new EnsambladorModeloDTOs();
        private readonly EnsambladorEntidad _ensambladorEntidad = new EnsambladorEntidad();
        private readonly EnsambladorModelo _ensambladorModelo = new EnsambladorModelo();
        #endregion
        /// <summary>
        /// Graba las comisiones  hace un asiento de  cuentas por cobrar y cuentas por pagar
        /// </summary>
        /// <param name="ordenTrabajoDtOs"></param>
        public string GrabarTransaccionInicialCompleta(OrdenTrabajoDTOs ordenTrabajoDtOs)
        {
            try
            {
                ordenTrabajoDtOs = _ventaTransfomadorNegocio.GrabarOrdenTrabajoCompleta(ordenTrabajoDtOs);
                decimal porcentajeMatriz = 0;
                decimal valorPago = 0;
                foreach (var detalleOrdenTrabajo in ordenTrabajoDtOs.DetalleOrdenTrabajo )
                {
                    bool vieneRegla = detalleOrdenTrabajo.PromocionAplicada != 0;

                    VentaComisionModelo _ventaComisionModelo =
                  _ventaTransfomadorNegocio.ObtenerbVentaComisionPorVariosParametros(
                      ordenTrabajoDtOs.OrdenTrabajo.Sucursal.SucursalId,
                      ordenTrabajoDtOs.OrdenTrabajo.PuntoVenta.PuntoVentaId, vieneRegla, ordenTrabajoDtOs.OrdenTrabajo.TipoLavado.TipoLavadoId,Convert.ToInt32(detalleOrdenTrabajo.PromocionAplicada));
                    OrdenTrabajoComisionModelo _ordenTrabajoComision=new OrdenTrabajoComisionModelo();
                    _ordenTrabajoComision.DetalleOrdenTrabajo = detalleOrdenTrabajo;
                    _ordenTrabajoComision.FechaGeneracionComision=DateTime.Now;
                    _ordenTrabajoComision.UsuarioId = ordenTrabajoDtOs.OrdenTrabajo.Usuario.UsuarioId;
                    _ordenTrabajoComision.VentaComision = _ventaComisionModelo;
                    _ordenTrabajoComision.Valor = (detalleOrdenTrabajo.ValorTotal*
                                                   _ventaComisionModelo.PorcentajeComision)/100;
                    _ventaTransfomadorNegocio.GrabaOrdenTrabajoComision(_ordenTrabajoComision);
                    porcentajeMatriz = 100 -Convert.ToDecimal(_ventaComisionModelo.PorcentajeComision);
                    valorPago+= (Convert.ToDecimal(detalleOrdenTrabajo.ValorTotal * porcentajeMatriz)) /100;
                }
                AsientoDTOs _asientoDtOs= new AsientoDTOs();

                CuentaPorCobrarModelo cuentaPorCobrar = new CuentaPorCobrarModelo();
                cuentaPorCobrar.PuntoVentaId = ordenTrabajoDtOs.OrdenTrabajo.PuntoVenta.PuntoVentaId;
                cuentaPorCobrar.SucursalId = ordenTrabajoDtOs.OrdenTrabajo.Sucursal.SucursalId;
                cuentaPorCobrar.ClienteId = ordenTrabajoDtOs.OrdenTrabajo.ClienteModelo.ClienteId;
                cuentaPorCobrar.EstadoPagoId = ordenTrabajoDtOs.OrdenTrabajo.EstadoPago.EstadoPagoId;
                cuentaPorCobrar.FechaCreacion=DateTime.Now;
                cuentaPorCobrar.FechaModificacion=DateTime.Now;
                cuentaPorCobrar.FechaVencimiento = ordenTrabajoDtOs.OrdenTrabajo.FechaEntrega;
                cuentaPorCobrar.NumeroFactura = "0";
                cuentaPorCobrar.NumeroOrden = ordenTrabajoDtOs.OrdenTrabajo.NumeroOrden;
                cuentaPorCobrar.UsuarioCreacionId = ordenTrabajoDtOs.OrdenTrabajo.Usuario.UsuarioId;
                cuentaPorCobrar.UsuarioModificacionId = ordenTrabajoDtOs.OrdenTrabajo.Usuario.UsuarioId;
                cuentaPorCobrar.Valor = ordenTrabajoDtOs.DetalleOrdenTrabajo.Sum(m => m.ValorTotal);
                cuentaPorCobrar.Saldo = ordenTrabajoDtOs.DetalleOrdenTrabajo.Sum(m => m.ValorTotal) - ordenTrabajoDtOs.Abono;
                _asientoDtOs.CuentaPorCobrar = cuentaPorCobrar;

                HistorialCuentaPorCobrarModelo historialCuentaPorCobrar= new HistorialCuentaPorCobrarModelo();
                historialCuentaPorCobrar.FechaCobro=DateTime.Now;

                FormaPagoModelo formaPago= new FormaPagoModelo();
                formaPago.FormaPagoId = Convert.ToInt32(JLLR.Core.Venta.Servicio.Enums.Enum.FormaPago.Efectivo);
                historialCuentaPorCobrar.FormaPago = formaPago;
                historialCuentaPorCobrar.UsuarioId = ordenTrabajoDtOs.OrdenTrabajo.Usuario.UsuarioId;
                historialCuentaPorCobrar.ValorCobro = ordenTrabajoDtOs.Abono;
                _asientoDtOs.HistorialCuentaPorCobrar = historialCuentaPorCobrar;


                CuentaPorPagarModelo cuentaPorPagar= new CuentaPorPagarModelo();

                cuentaPorPagar.PuntoVentaId = ordenTrabajoDtOs.OrdenTrabajo.PuntoVenta.PuntoVentaId;
                cuentaPorPagar.FechaCreacion=DateTime.Now;
                cuentaPorPagar.FechaModificacion=DateTime.Now;
                cuentaPorPagar.ProveedorId = Convert.ToInt32(JLLR.Core.Venta.Servicio.Enums.Enum.Proveedor.Quimica);
                cuentaPorPagar.UsuarioCreacionId= ordenTrabajoDtOs.OrdenTrabajo.Usuario.UsuarioId;
                cuentaPorPagar.UsuarioModificacionId= ordenTrabajoDtOs.OrdenTrabajo.Usuario.UsuarioId;
                cuentaPorPagar.FechaVencimiento=DateTime.Now;
                cuentaPorPagar.SucursalId= ordenTrabajoDtOs.OrdenTrabajo.Sucursal.SucursalId;
                cuentaPorPagar.Saldo = 0;
                cuentaPorPagar.Valor = valorPago;

                cuentaPorPagar.NumeroOrden= ordenTrabajoDtOs.OrdenTrabajo.NumeroOrden;
                cuentaPorPagar.NumeroFactura = "0";
                _asientoDtOs.CuentaPorPagar = cuentaPorPagar;

                HistorialCuentaPorPagarModelo historialCuentaPorPagar= new HistorialCuentaPorPagarModelo();
                historialCuentaPorPagar.FechaPago=DateTime.Now;
                historialCuentaPorPagar.UsuarioId= ordenTrabajoDtOs.OrdenTrabajo.Usuario.UsuarioId;
                historialCuentaPorPagar.ValorPago = 0;
                _asientoDtOs.HistorialCuentaPorPagar = historialCuentaPorPagar;

                _servicioDelegadoContabilidad.GrabarAsiento(_asientoDtOs);

                //GUarda el proceso inicial que es la entrega del cliente hacia  la franquicia
                HistorialProcesoModelo _historialProcesoVista = new HistorialProcesoModelo();
                _historialProcesoVista.OrdenTrabajoId = ordenTrabajoDtOs.OrdenTrabajo.OrdenTrabajoId;
                EtapaProcesoModelo _etapaProcesoVistaModelo = new EtapaProcesoModelo();
                _etapaProcesoVistaModelo.EtapaProcesoId =Convert.ToInt32( Enum.EtapaProceso.EntregaClienteHaciaFranquicia);
                _historialProcesoVista.EtapaProceso = _etapaProcesoVistaModelo;
                _historialProcesoVista.FechaRegistro = DateTime.Now;
                _historialProcesoVista.FechaInicio = DateTime.Now;
                _historialProcesoVista.FechaFin = DateTime.Now;
                _historialProcesoVista.SucursalId = ordenTrabajoDtOs.OrdenTrabajo.Sucursal.SucursalId;
                _historialProcesoVista.PuntoVentaId = ordenTrabajoDtOs.OrdenTrabajo.PuntoVenta.PuntoVentaId;
                _historialProcesoVista.NumeroOrden = ordenTrabajoDtOs.OrdenTrabajo.NumeroOrden;
                _historialProcesoVista.UsuarioRecibeId = ordenTrabajoDtOs.OrdenTrabajo.Usuario.UsuarioId;
                _historialProcesoVista.UsuarioEntregaId = ordenTrabajoDtOs.OrdenTrabajo.Usuario.UsuarioId;
                _historialProcesoVista.PerfilId =ordenTrabajoDtOs.PerfilId;
                _historialProcesoVista.PasoPorEstaEtapa = false;
                _servicioDelegadoFlujoProceso.GrabarHistorialProceso(_historialProcesoVista);

                return ordenTrabajoDtOs.OrdenTrabajo.NumeroOrden;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// Graba el reverso de la transaccion reversa comision,cuenta por  cobrar y cuenta por  pagar
        /// </summary>
        /// <param name="parametroReversoDtOs"></param>
        /// <returns></returns>
        public string GrabarReversoTransaccion(ParametroReversoDTOs parametroReversoDtOs)
        {
            try
            {
                HistorialProcesoModelo _historialProcesoVista = new HistorialProcesoModelo();
                _historialProcesoVista.OrdenTrabajoId = parametroReversoDtOs.OrdenTrabajoId;
                EtapaProcesoModelo _etapaProcesoVistaModelo = new EtapaProcesoModelo();
                _etapaProcesoVistaModelo.EtapaProcesoId = Convert.ToInt32(Enum.EtapaProceso.AnulacionOrdenTrabajo);
                _historialProcesoVista.EtapaProceso = _etapaProcesoVistaModelo;
                _historialProcesoVista.FechaRegistro = DateTime.Now;
                _historialProcesoVista.FechaInicio = DateTime.Now;
                _historialProcesoVista.FechaFin = DateTime.Now;
                _historialProcesoVista.SucursalId = parametroReversoDtOs.SucursalId;
                _historialProcesoVista.PuntoVentaId = parametroReversoDtOs.PuntoVentaId;
                _historialProcesoVista.NumeroOrden = parametroReversoDtOs.NumeroOrden;
                _historialProcesoVista.Texto = parametroReversoDtOs.Texto;
                _servicioDelegadoFlujoProceso.GrabarHistorialProceso(_historialProcesoVista);

                _ventaTransfomadorNegocio.GrabarReversoOrdenTrabajoComision(parametroReversoDtOs.OrdenTrabajoId, parametroReversoDtOs.UsuarioId);

                List<CuentaPorCobrarDTOs> cuentaPorCobrarDtOs =
                    _servicioDelegadoContabilidad.ObtenerHistorialCuentaPorCobrarPorVariosParametros(
                        parametroReversoDtOs.NumeroOrden, parametroReversoDtOs.PuntoVentaId,
                        parametroReversoDtOs.SucursalId);
                List<CuentaPorPagarDTOs> cuentaPorPagarDtOses = _servicioDelegadoContabilidad.ObtenerHistorialCuentaPorPagarPorVariosParametros(
                        parametroReversoDtOs.NumeroOrden, parametroReversoDtOs.PuntoVentaId,
                        parametroReversoDtOs.SucursalId);

                AsientoDTOs _asientoDtOs = new AsientoDTOs();

                CuentaPorCobrarModelo cuentaPorCobrar = new CuentaPorCobrarModelo();
                cuentaPorCobrar.PuntoVentaId = cuentaPorCobrarDtOs.Select(m => m.CuentaPorCobrar.PuntoVentaId).FirstOrDefault();
                cuentaPorCobrar.SucursalId = cuentaPorCobrarDtOs.Select(m => m.CuentaPorCobrar.SucursalId).FirstOrDefault();
                cuentaPorCobrar.ClienteId = cuentaPorCobrarDtOs.Select(m => m.CuentaPorCobrar.ClienteId).FirstOrDefault();
                cuentaPorCobrar.EstadoPagoId = cuentaPorCobrarDtOs.Select(m => m.CuentaPorCobrar.EstadoPagoId).FirstOrDefault();
                cuentaPorCobrar.FechaCreacion = DateTime.Now;
                cuentaPorCobrar.FechaModificacion = DateTime.Now;
                cuentaPorCobrar.FechaVencimiento = DateTime.Now;
                cuentaPorCobrar.NumeroFactura = cuentaPorCobrarDtOs.Select(m => m.CuentaPorCobrar.NumeroFactura).FirstOrDefault();
                cuentaPorCobrar.NumeroOrden = cuentaPorCobrarDtOs.Select(m => m.CuentaPorCobrar.NumeroOrden).FirstOrDefault();
                cuentaPorCobrar.UsuarioCreacionId = parametroReversoDtOs.UsuarioId;
                cuentaPorCobrar.UsuarioModificacionId = parametroReversoDtOs.UsuarioId;
                cuentaPorCobrar.Valor = cuentaPorCobrarDtOs.Select(m => m.CuentaPorCobrar.Valor).FirstOrDefault() * -1;
                cuentaPorCobrar.Saldo = cuentaPorCobrarDtOs.Select(m => m.CuentaPorCobrar.Saldo).FirstOrDefault() * -1;
                _asientoDtOs.CuentaPorCobrar = cuentaPorCobrar;

                HistorialCuentaPorCobrarModelo historialCuentaPorCobrar = new HistorialCuentaPorCobrarModelo();
                historialCuentaPorCobrar.FechaCobro = DateTime.Now;

                FormaPagoModelo formaPago = new FormaPagoModelo();
                formaPago.FormaPagoId = Convert.ToInt32(JLLR.Core.Venta.Servicio.Enums.Enum.FormaPago.Efectivo);
                historialCuentaPorCobrar.FormaPago = formaPago;
                historialCuentaPorCobrar.UsuarioId = parametroReversoDtOs.UsuarioId;
                historialCuentaPorCobrar.ValorCobro = (cuentaPorCobrarDtOs.Select(m => m.CuentaPorCobrar.Valor).FirstOrDefault()+ cuentaPorCobrarDtOs.Sum(m=>m.HistorialCuentaPorCobrar.ValorCobro)) * (-1);

                _asientoDtOs.HistorialCuentaPorCobrar = historialCuentaPorCobrar;


                CuentaPorPagarModelo cuentaPorPagar = new CuentaPorPagarModelo();

                cuentaPorPagar.PuntoVentaId = cuentaPorPagarDtOses.Select(m => m.CuentaPorPagar.PuntoVentaId).FirstOrDefault();
                cuentaPorPagar.FechaCreacion = DateTime.Now;
                cuentaPorPagar.FechaModificacion = DateTime.Now;
                cuentaPorPagar.ProveedorId = Convert.ToInt32(JLLR.Core.Venta.Servicio.Enums.Enum.Proveedor.Quimica);
                cuentaPorPagar.UsuarioCreacionId = parametroReversoDtOs.UsuarioId;
                cuentaPorPagar.UsuarioModificacionId = parametroReversoDtOs.UsuarioId;
                cuentaPorPagar.FechaVencimiento = DateTime.Now;
                cuentaPorPagar.SucursalId = cuentaPorPagarDtOses.Select(m => m.CuentaPorPagar.SucursalId).FirstOrDefault();
                cuentaPorPagar.Saldo = 0;
                cuentaPorPagar.Valor = cuentaPorPagarDtOses.Select(m => m.CuentaPorPagar.Valor).FirstOrDefault() * -1;
                cuentaPorPagar.NumeroOrden = cuentaPorPagarDtOses.Select(m => m.CuentaPorPagar.NumeroOrden).FirstOrDefault();
                cuentaPorPagar.NumeroFactura = "0";
                _asientoDtOs.CuentaPorPagar = cuentaPorPagar;

                HistorialCuentaPorPagarModelo historialCuentaPorPagar = new HistorialCuentaPorPagarModelo();
                historialCuentaPorPagar.FechaPago = DateTime.Now;
                historialCuentaPorPagar.UsuarioId = parametroReversoDtOs.UsuarioId;
                historialCuentaPorPagar.ValorPago = 0;
                _asientoDtOs.HistorialCuentaPorPagar = historialCuentaPorPagar;

                _servicioDelegadoContabilidad.GrabarAsiento(_asientoDtOs);

               

                return string.Empty;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Graba la operacion de descuento  
        /// </summary>
        /// <param name="parametroDescuentoDtOs"></param>
        public void GrabarTransaccionDescuentoOrden(ParametroDescuentoDTOs parametroDescuentoDtOs)
        {
            try
            {
                OrdenTrabajoDTOs ordenTrabajoDtOs= _ventaTransfomadorNegocio.ObtenerOrdenTrabajoPorOrdenTrabajoId(parametroDescuentoDtOs.OrdenTrabajoId);
                List<CuentaPorCobrarDTOs> cuentaPorCobrarDtOs =
                   _servicioDelegadoContabilidad.ObtenerHistorialCuentaPorCobrarPorVariosParametros(ordenTrabajoDtOs.OrdenTrabajo.NumeroOrden, ordenTrabajoDtOs.OrdenTrabajo.PuntoVenta.PuntoVentaId, ordenTrabajoDtOs.OrdenTrabajo.Sucursal.SucursalId);
                List<CuentaPorPagarDTOs> cuentaPorPagarDtOses = _servicioDelegadoContabilidad.ObtenerHistorialCuentaPorPagarPorVariosParametros(ordenTrabajoDtOs.OrdenTrabajo.NumeroOrden, ordenTrabajoDtOs.OrdenTrabajo.PuntoVenta.PuntoVentaId, ordenTrabajoDtOs.OrdenTrabajo.Sucursal.SucursalId);

                _ventaTransfomadorNegocio.GrabarDescuentoComision(parametroDescuentoDtOs.OrdenTrabajoId,Convert.ToInt32(parametroDescuentoDtOs.UsuarioId),Convert.ToDecimal(parametroDescuentoDtOs.ValorDescuentoFranquicia));
                AsientoDTOs _asientoDtOs = new AsientoDTOs();

                CuentaPorCobrarModelo cuentaPorCobrar = new CuentaPorCobrarModelo();
                cuentaPorCobrar.PuntoVentaId = cuentaPorCobrarDtOs.Select(m => m.CuentaPorCobrar.PuntoVentaId).FirstOrDefault();
                cuentaPorCobrar.SucursalId = cuentaPorCobrarDtOs.Select(m => m.CuentaPorCobrar.SucursalId).FirstOrDefault();
                cuentaPorCobrar.ClienteId = cuentaPorCobrarDtOs.Select(m => m.CuentaPorCobrar.ClienteId).FirstOrDefault();
                cuentaPorCobrar.EstadoPagoId = cuentaPorCobrarDtOs.Select(m => m.CuentaPorCobrar.EstadoPagoId).FirstOrDefault();
                cuentaPorCobrar.FechaCreacion = DateTime.Now;
                cuentaPorCobrar.FechaModificacion = DateTime.Now;
                cuentaPorCobrar.FechaVencimiento = DateTime.Now;
                cuentaPorCobrar.NumeroFactura = cuentaPorCobrarDtOs.Select(m => m.CuentaPorCobrar.NumeroFactura).FirstOrDefault();
                cuentaPorCobrar.NumeroOrden = cuentaPorCobrarDtOs.Select(m => m.CuentaPorCobrar.NumeroOrden).FirstOrDefault();
                cuentaPorCobrar.UsuarioCreacionId = parametroDescuentoDtOs.UsuarioId;
                cuentaPorCobrar.UsuarioModificacionId = parametroDescuentoDtOs.UsuarioId;
                cuentaPorCobrar.Valor = (-1)*((parametroDescuentoDtOs.ValorDescuentoFranquicia + parametroDescuentoDtOs.ValorDescuentoMatriz));
                cuentaPorCobrar.Saldo =  (-1) * (parametroDescuentoDtOs.ValorDescuentoFranquicia + parametroDescuentoDtOs.ValorDescuentoMatriz);
                _asientoDtOs.CuentaPorCobrar = cuentaPorCobrar;

                HistorialCuentaPorCobrarModelo historialCuentaPorCobrar = new HistorialCuentaPorCobrarModelo();
                historialCuentaPorCobrar.FechaCobro = DateTime.Now;

                FormaPagoModelo formaPago = new FormaPagoModelo();
                formaPago.FormaPagoId = Convert.ToInt32(JLLR.Core.Venta.Servicio.Enums.Enum.FormaPago.Efectivo);
                historialCuentaPorCobrar.FormaPago = formaPago;
                historialCuentaPorCobrar.UsuarioId = parametroDescuentoDtOs.UsuarioId;
                historialCuentaPorCobrar.ValorCobro =(parametroDescuentoDtOs.ValorDescuentoFranquicia+ parametroDescuentoDtOs.ValorDescuentoMatriz)*(-1);

                _asientoDtOs.HistorialCuentaPorCobrar = historialCuentaPorCobrar;


                CuentaPorPagarModelo cuentaPorPagar = new CuentaPorPagarModelo();

                cuentaPorPagar.PuntoVentaId = cuentaPorPagarDtOses.Select(m => m.CuentaPorPagar.PuntoVentaId).FirstOrDefault();
                cuentaPorPagar.FechaCreacion = DateTime.Now;
                cuentaPorPagar.FechaModificacion = DateTime.Now;
                cuentaPorPagar.ProveedorId = Convert.ToInt32(JLLR.Core.Venta.Servicio.Enums.Enum.Proveedor.Quimica);
                cuentaPorPagar.UsuarioCreacionId = parametroDescuentoDtOs.UsuarioId;
                cuentaPorPagar.UsuarioModificacionId = parametroDescuentoDtOs.UsuarioId;
                cuentaPorPagar.FechaVencimiento = DateTime.Now;
                cuentaPorPagar.SucursalId = cuentaPorPagarDtOses.Select(m => m.CuentaPorPagar.SucursalId).FirstOrDefault();
                cuentaPorPagar.Saldo = 0;
                cuentaPorPagar.Valor = (-1) * (parametroDescuentoDtOs.ValorDescuentoMatriz);
                cuentaPorPagar.NumeroOrden = cuentaPorPagarDtOses.Select(m => m.CuentaPorPagar.NumeroOrden).FirstOrDefault();
                cuentaPorPagar.NumeroFactura = "0";
                _asientoDtOs.CuentaPorPagar = cuentaPorPagar;

                HistorialCuentaPorPagarModelo historialCuentaPorPagar = new HistorialCuentaPorPagarModelo();
                historialCuentaPorPagar.FechaPago = DateTime.Now;
                historialCuentaPorPagar.UsuarioId = parametroDescuentoDtOs.UsuarioId;
                historialCuentaPorPagar.ValorPago = 0;
                _asientoDtOs.HistorialCuentaPorPagar = historialCuentaPorPagar;

                _servicioDelegadoContabilidad.GrabarAsiento(_asientoDtOs);
            }
            catch (Exception exception)
            {
                
                throw;
            }
        }
    }
}