                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         #region using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Base;
using Web.DTOs.Contabilidad;
using Web.DTOs.Venta;
using Web.Models.Contabilidad;
using Web.Models.FlujoProceso;
using Web.Models.General;
using Web.Models.Venta.Negocio;
using Web.Models.Venta.Parametrizacion;
using Web.ServicioDelegado;

#endregion

namespace Web.Venta
{
    public partial class ConsultaOrdenTrabajo :PaginaBase
    {
        #region Declaraciones  e Instancias
        private readonly ServicioDelegadoVenta _servicioDelegadoVenta= new ServicioDelegadoVenta();
        private readonly  ServicioDelegadoFlujoProceso _servicioDelegadoFlujoProceso= new ServicioDelegadoFlujoProceso();
        private readonly  ServicioDelegadoContabilidad _servicioDelegadoContabilidad= new ServicioDelegadoContabilidad();
        private readonly ServicioDelegadoGeneral _servicioDelegadoGeneral = new  ServicioDelegadoGeneral();
        private static List<ConsultaOrdenTrabajoVistaDTOs> _listaConsultaOrdenTrabajoVistaDtOses =null;
        private static List<DetalleOrdenTrabajoVistaModelo> _listaDetalleOrdenTrabajoVistaModelos= null;
        private static List<HistorialProcesoVistaModelo> _listaHistorialProcesoVistaModelos = null;
        private static  List<CuentaPorCobrarVistaDTOs>  _listaCuentaPorCobrarVistaDtOses = null;
        #endregion

        #region Eventos
        /// <summary>
        /// Si esta checkeado valida  que  los validadores se activen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _descuento_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (_descuento.Checked == true)
                {
                   // _valorDescuentoValidador.Enabled = true;
                }
                else
                {
                    //_valorDescuentoValidador.Enabled = false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// Totales del historial de pago
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private decimal _montoAbono = 0;
        protected void _datosPago_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                    _montoAbono += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "HistorialCuentaPorCobrar.ValorCobro"));
                
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Total Abono:";
                    e.Row.Cells[1].Text = _montoAbono.ToString("C");
                    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Font.Bold = true;
                }
            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }
        /// <summary>
        /// Carga los totales  de las prendas
        /// </summary>
        private decimal _montoTotal = 0;
        private int _cantidadTotal = 0;
        protected void _datos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //_montoTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ValorTotal"));
                //_cantidadTotal += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Cantidad"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                
                e.Row.Cells[0].Text = "Totales:";
                e.Row.Cells[1].Text = _listaDetalleOrdenTrabajoVistaModelos.Sum(a=>a.Cantidad).ToString();
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;

                e.Row.Cells[6].Text = _listaDetalleOrdenTrabajoVistaModelos.Sum(a => a.ValorTotal).ToString();
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;
            }
        }


        /// <summary>
        /// Abonar valor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _abonarValor_Click(object sender, EventArgs e)
        {
            try
            {
                if (_listaCuentaPorCobrarVistaDtOses.Sum(b => b.HistorialCuentaPorCobrar.ValorCobro) + Convert.ToDecimal(_valorAbonar.Text)<= _listaDetalleOrdenTrabajoVistaModelos.Sum(m => m.ValorTotal) )
                {
                
                if (_listaCuentaPorCobrarVistaDtOses.Count > 0)
                {
                        CuentaPorCobrarVistaModelo _cuentaPorCobrarVistaModelo = _listaCuentaPorCobrarVistaDtOses.Select(b => b.CuentaPorCobrar).FirstOrDefault();
                        _cuentaPorCobrarVistaModelo.Saldo = _listaCuentaPorCobrarVistaDtOses.Select(m => m.CuentaPorCobrar.Saldo).FirstOrDefault() -   Convert.ToDecimal(_valorAbonar.Text);
                        _servicioDelegadoContabilidad.ActualizaCuentaPorCobrar(_cuentaPorCobrarVistaModelo);

                        HistorialCuentaPorCobrarVistaModelo _historialCuentaPorCobrar =
                        new HistorialCuentaPorCobrarVistaModelo();
                    _historialCuentaPorCobrar.UsuarioId = User.Id;
                    _historialCuentaPorCobrar.CuentaPorCobrarId = Convert.ToInt32(_cuentaPorCobrarId.Value);
                    _historialCuentaPorCobrar.FechaCobro = DateTime.Now;
                    FormaPagoVistaModelo _formaPago = new FormaPagoVistaModelo();
                    _formaPago.FormaPagoId = Convert.ToInt32(Util.FormaPago.Efectivo);
                    _historialCuentaPorCobrar.FormaPago = _formaPago;
                    _historialCuentaPorCobrar.ValorCobro = Convert.ToDecimal(_valorAbonar.Text);
                    _historialCuentaPorCobrar =
                        _servicioDelegadoContabilidad.GrabarHistorialCuentaPorCobrar(_historialCuentaPorCobrar);
                }
                else
                {
                    CuentaPorCobrarVistaModelo _cuentaPorCobrarVista = new CuentaPorCobrarVistaModelo();
                    _cuentaPorCobrarVista.SucursalId = User.SucursalId;
                    _cuentaPorCobrarVista.PuntoVentaId = User.PuntoVentaId;
                    //_cuentaPorCobrarVista.ClienteId = ;
                    _cuentaPorCobrarVista.FechaCreacion = DateTime.Now;
                    _cuentaPorCobrarVista.FechaModificacion = DateTime.Now;
                    _cuentaPorCobrarVista.FechaVencimiento = DateTime.Now;
                    _cuentaPorCobrarVista.NumeroFactura = String.Empty;
                    _cuentaPorCobrarVista.NumeroOrden = _numeroOrden.Text;
                    _cuentaPorCobrarVista.Saldo = 0;
                    _cuentaPorCobrarVista.Valor = Convert.ToDecimal(_valorAbonar.Text);
                    _cuentaPorCobrarVista.UsuarioModificacionId = User.Id;
                    _cuentaPorCobrarVista.UsuarioCreacionId = User.Id;
                    _cuentaPorCobrarVista.EstadoPagoId = 1;

                    HistorialCuentaPorCobrarVistaModelo _historialCuentaPorCobrar =
                        new HistorialCuentaPorCobrarVistaModelo();
                    _historialCuentaPorCobrar.UsuarioId = User.Id;
                    _historialCuentaPorCobrar.CuentaPorCobrarId = Convert.ToInt32(_cuentaPorCobrarId.Value);
                    _historialCuentaPorCobrar.FechaCobro = DateTime.Now;
                    FormaPagoVistaModelo _formaPago = new FormaPagoVistaModelo();
                    _formaPago.FormaPagoId = Convert.ToInt32(Util.FormaPago.Efectivo);
                    _historialCuentaPorCobrar.FormaPago = _formaPago;
                    _historialCuentaPorCobrar.ValorCobro = Convert.ToDecimal(_valorAbonar.Text);
                    _historialCuentaPorCobrar =
                        _servicioDelegadoContabilidad.GrabarHistorialCuentaPorCobrar(_historialCuentaPorCobrar);
                }
                    _listaCuentaPorCobrarVistaDtOses = _servicioDelegadoContabilidad.ObtenerHistorialCuentaPorCobrarPorNumeroOrden(_numeroOrden.Text);
                    _datosPago.DataSource = _listaCuentaPorCobrarVistaDtOses;
                    _datosPago.DataBind();
                }
                else
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Abono_Excede").ToString(), "_btnBuscar");



            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }

        /// <summary>
        /// Abona a un numero de  orden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _abonar_Click(object sender, EventArgs e)
        {
            try
            {
                int ordenCerrada = Convert.ToInt32(_listaHistorialProcesoVistaModelos.Where(a => a.EtapaProceso.EtapaProcesoId.Equals(Convert.ToInt32(Util.EtapaProceso.EntregaFranquiciaHaciaCliente))).Select(b => b.EtapaProceso.EtapaProcesoId).FirstOrDefault().ToString());
                int ordenAnulada = Convert.ToInt32(_listaHistorialProcesoVistaModelos.Where(a => a.EtapaProceso.EtapaProcesoId.Equals(Convert.ToInt32(Util.EtapaProceso.AnulacionOrdenTrabajo))).Select(b => b.EtapaProceso.EtapaProcesoId).FirstOrDefault().ToString());

                if (ordenCerrada == Convert.ToInt32(Util.EtapaProceso.EntregaFranquiciaHaciaCliente) ||
                    ordenAnulada == Convert.ToInt32(Util.EtapaProceso.AnulacionOrdenTrabajo))
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Orden_Cerrada").ToString(), "_btnBuscar");
                else
                {

                   
                    if (Convert.ToDecimal(_listaDetalleOrdenTrabajoVistaModelos.Sum(m => m.ValorTotal))>Convert.ToDecimal( _listaCuentaPorCobrarVistaDtOses.Sum(b => b.HistorialCuentaPorCobrar.ValorCobro)))
                    {
                        _btnAbonar_ModalPopupExtender.TargetControlID = "_btnBuscar";
                        _btnAbonar_ModalPopupExtender.Show();

                        if (_listaCuentaPorCobrarVistaDtOses.Count() == 0)
                        _valorAbonar.Text = String.Format("{0:0.00}", _listaDetalleOrdenTrabajoVistaModelos.Sum(m => m.ValorTotal));
                    else
                        _valorAbonar.Text = String.Format("{0:0.00}", _listaDetalleOrdenTrabajoVistaModelos.Sum(m => m.ValorTotal) - _listaCuentaPorCobrarVistaDtOses.Sum(b => b.HistorialCuentaPorCobrar.ValorCobro));
                    }
                    else
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Abono_Completo").ToString(), "_abonar");

                }

            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }

        }

        /// <summary>
        /// Agrega Observaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnAceptarObservaciones_Click(object sender, EventArgs e)
        {
            try
            {
                DetalleOrdenTrabajoObservacionVistaModelo _detalleOrdenTrabajoObservacion =new DetalleOrdenTrabajoObservacionVistaModelo();
                _detalleOrdenTrabajoObservacion.UsuarioId = User.Id;
                _detalleOrdenTrabajoObservacion.DetalleOrdenTrabajoId = Convert.ToInt32(_detalleOrdenTrabajoId.Value);
                _detalleOrdenTrabajoObservacion.FechaCreacionObservacion = DateTime.Now;
                _detalleOrdenTrabajoObservacion.Observacion = _observacion.Text;
                _servicioDelegadoVenta.GrabarDetalleOrdenTrabajoObservacion(_detalleOrdenTrabajoObservacion);
                _observacion.Text=String.Empty;

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }

        /// <summary>
        /// Cierra la orden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnAceptarCerrarOrden_Click(object sender, EventArgs e)
        {
            try
            {
                
                //GUarda el proceso inicial que es la entrega del cliente hacia  la franquicia
                HistorialProcesoVistaModelo _historialProcesoVista = new HistorialProcesoVistaModelo();
                _historialProcesoVista.OrdenTrabajoId = _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.OrdenTrabajoId).First(); ;
                EtapaProcesoVistaModelo _etapaProcesoVistaModelo = new EtapaProcesoVistaModelo();
                _etapaProcesoVistaModelo.EtapaProcesoId = Convert.ToInt32(Util.EtapaProceso.EntregaFranquiciaHaciaCliente);
                _historialProcesoVista.EtapaProceso = _etapaProcesoVistaModelo;
                _historialProcesoVista.FechaRegistro = DateTime.Now;
                _historialProcesoVista.FechaInicio = DateTime.Now;
                _historialProcesoVista.FechaFin = DateTime.Now;
                _historialProcesoVista.SucursalId = User.SucursalId;
                _historialProcesoVista.PuntoVentaId = User.PuntoVentaId;
                _historialProcesoVista.NumeroOrden = _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NumeroOrden).First().ToString();
                _servicioDelegadoFlujoProceso.GrabarHistorialProceso(_historialProcesoVista);
                _listaHistorialProcesoVistaModelos = _servicioDelegadoFlujoProceso.ObtenerHIstorialProcesosPorNumeroOrden(_numeroOrden.Text);
                _datosHistorial.DataSource = _listaHistorialProcesoVistaModelos;
                _datosHistorial.DataBind();


                if (Convert.ToDecimal(_valorTotal.Text)!=0)
                { 
                if (_listaCuentaPorCobrarVistaDtOses.Count > 0)
                {

                     CuentaPorCobrarVistaModelo _cuentaPorCobrarVistaModelo= _listaCuentaPorCobrarVistaDtOses.Select(b => b.CuentaPorCobrar).FirstOrDefault();
                    _cuentaPorCobrarVistaModelo.Saldo = _cuentaPorCobrarVistaModelo.Saldo - Convert.ToDecimal(_valorTotal.Text);
                      _servicioDelegadoContabilidad.ActualizaCuentaPorCobrar(_cuentaPorCobrarVistaModelo);
                      HistorialCuentaPorCobrarVistaModelo _historialCuentaPorCobrar =new HistorialCuentaPorCobrarVistaModelo();
                    _historialCuentaPorCobrar.UsuarioId = User.Id;
                    _historialCuentaPorCobrar.CuentaPorCobrarId = Convert.ToInt32(_cuentaPorCobrarId.Value);
                    _historialCuentaPorCobrar.FechaCobro = DateTime.Now;
                    FormaPagoVistaModelo _formaPago = new FormaPagoVistaModelo();
                    _formaPago.FormaPagoId = Convert.ToInt32(Util.FormaPago.Efectivo);
                    _historialCuentaPorCobrar.FormaPago = _formaPago;
                    _historialCuentaPorCobrar.ValorCobro = Convert.ToDecimal(_valorTotal.Text);
                    _historialCuentaPorCobrar =
                        _servicioDelegadoContabilidad.GrabarHistorialCuentaPorCobrar(_historialCuentaPorCobrar);
                }
                _listaCuentaPorCobrarVistaDtOses = _servicioDelegadoContabilidad.ObtenerHistorialCuentaPorCobrarPorNumeroOrden(_numeroOrden.Text);
                _datosPago.DataSource = _listaCuentaPorCobrarVistaDtOses;
                _datosPago.DataBind();

                    if (_descuento.Checked == false)
                    {
                        #region GRABA LOS  DATOS DE LAS CUENTAS POR COBRAR, PAGAR Y LAS COMISIONES POR EL CIERRE DE LA ORDEN

                        //Graba la  cuenta por  cobrar  para  la franquicia 

                        CuentaPorCobrarVistaModelo _cuentaPorCobrarVista = new CuentaPorCobrarVistaModelo();
                        _cuentaPorCobrarVista.PuntoVentaId = User.PuntoVentaId;
                        _cuentaPorCobrarVista.FechaCreacion = DateTime.Now;
                        _cuentaPorCobrarVista.FechaModificacion = DateTime.Now;
                        _cuentaPorCobrarVista.FechaVencimiento = DateTime.Now;
                        _cuentaPorCobrarVista.SucursalId = User.SucursalId;
                        _cuentaPorCobrarVista.Saldo = 0;
                        _cuentaPorCobrarVista.Valor = 0;
                        _cuentaPorCobrarVista.UsuarioCreacionId = User.Id;
                        _cuentaPorCobrarVista.UsuarioModificacionId = User.Id;
                        _cuentaPorCobrarVista.NumeroOrden = "0";
                        _cuentaPorCobrarVista.EstadoPagoId = Convert.ToInt32(Util.EstadoPago.Pendiente);
                        _cuentaPorCobrarVista =
                         _servicioDelegadoContabilidad.GrabarCuentaPorCobrar(_cuentaPorCobrarVista);
                        


                        #endregion
                    }
                    else
                    {
                            OrdenTrabajoDescuentoVistaModelo _ordenTrabajoDescuentoVistaModelo= new OrdenTrabajoDescuentoVistaModelo();
                            OrdenTrabajoVistaModelo _ordenTrabajoVistaModelo= new OrdenTrabajoVistaModelo();
                            _ordenTrabajoVistaModelo.OrdenTrabajoId = Convert.ToInt64(_listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.OrdenTrabajoId).First());
                        _ordenTrabajoDescuentoVistaModelo.OrdenTrabajo = _ordenTrabajoVistaModelo;
                        _ordenTrabajoDescuentoVistaModelo.EstadoProceso = false;
                            _ordenTrabajoDescuentoVistaModelo.FechaActualizacion=DateTime.Now;
                        _ordenTrabajoDescuentoVistaModelo.Motivo = _motivoDescuento.Text;
                            _ordenTrabajoDescuentoVistaModelo.FechaCreacion=DateTime.Now;
                        _ordenTrabajoDescuentoVistaModelo.UsuarioCreacionId = User.Id;
                        _ordenTrabajoDescuentoVistaModelo.UsuarioActualizacionId = User.Id;
                        _ordenTrabajoDescuentoVistaModelo.Valor = Convert.ToDecimal(_valorDescuento.Text);
                        _ordenTrabajoDescuentoVistaModelo.PorcentajeFranquicia =
                            Convert.ToDecimal(_procentajeFranquicia.Text);
                        _ordenTrabajoDescuentoVistaModelo.PorcentajeMatriz = Convert.ToDecimal(_procentajeMatriz.Text);
                        HistorialReglaVistaModelo _historialReglaVista= new HistorialReglaVistaModelo();
                        _historialReglaVista.HistorialReglaId = 1;
                        _ordenTrabajoDescuentoVistaModelo.HistorialRegla = _historialReglaVista;
                            _servicioDelegadoVenta.GrabarOrdenTrabajoDescuento(_ordenTrabajoDescuentoVistaModelo);

                    }



                }
             
                
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }

        /// <summary>
        /// Anula la orden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void _btnAceptaAnulacionOrden_Click(object sender, EventArgs e)
        {
            try
            {
                //GUarda el proceso inicial que es la entrega del cliente hacia  la franquicia
                ParametroReversoVistaDTOs parametroReversoVistaDtOs= new ParametroReversoVistaDTOs();
                parametroReversoVistaDtOs.NumeroOrden = _numeroOrden.Text;
                parametroReversoVistaDtOs.PuntoVentaId =Convert.ToInt32(User.PuntoVentaId);
                parametroReversoVistaDtOs.SucursalId = Convert.ToInt32(User.SucursalId);
                parametroReversoVistaDtOs.UsuarioId= Convert.ToInt32(User.Id);
                parametroReversoVistaDtOs.Texto = _observacionAnularOrden.Text;
                parametroReversoVistaDtOs.OrdenTrabajoId= Convert.ToInt32(_listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.OrdenTrabajoId).First());
                _servicioDelegadoVenta.GrabarReversoTransaccion(parametroReversoVistaDtOs);
                _listaHistorialProcesoVistaModelos = _servicioDelegadoFlujoProceso.ObtenerHIstorialProcesosPorNumeroOrden(_numeroOrden.Text);
                _datosHistorial.DataSource = _listaHistorialProcesoVistaModelos;
                _datosHistorial.DataBind();

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }
        /// <summary>
        /// Agrega observaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Observacion")

                {
                    _observacion.Text = String.Empty;
                    _btnObservaciones_ModalPopupExtender.TargetControlID = "_btnBuscar";
                    _btnObservaciones_ModalPopupExtender.Show();
                    int index = Convert.ToInt32(e.CommandArgument);
                    List<DetalleOrdenTrabajoObservacionVistaDTOs> _lisaDetalleOrdenTrabajoObservacion= _servicioDelegadoVenta.ObtenerDetalleOrdenTrabajoObservacionPorDetalleOrdenTrabajoId(Convert.ToInt32(_datos.Rows[index].Cells[0].Text));
                    if (_lisaDetalleOrdenTrabajoObservacion.Count>0)
                    {
                        _datosObservaciones.DataSource = _lisaDetalleOrdenTrabajoObservacion;
                        _datosObservaciones.DataBind();
                    }

                    int ordenCerrada = Convert.ToInt32(_listaHistorialProcesoVistaModelos.Where(a => a.EtapaProceso.EtapaProcesoId.Equals(Convert.ToInt32(Util.EtapaProceso.EntregaFranquiciaHaciaCliente))).Select(b => b.EtapaProceso.EtapaProcesoId).FirstOrDefault().ToString());
                    int ordenAnulada = Convert.ToInt32(_listaHistorialProcesoVistaModelos.Where(a => a.EtapaProceso.EtapaProcesoId.Equals(Convert.ToInt32(Util.EtapaProceso.AnulacionOrdenTrabajo))).Select(b => b.EtapaProceso.EtapaProcesoId).FirstOrDefault().ToString());

                    if (ordenCerrada == Convert.ToInt32(Util.EtapaProceso.EntregaFranquiciaHaciaCliente) ||
                        ordenAnulada == Convert.ToInt32(Util.EtapaProceso.AnulacionOrdenTrabajo))
                    {
                        
                        _observacion.ReadOnly = true;
                        _btnAceptaAnulacionOrden.Enabled = false;
                        _btnAceptaAnulacionOrden.CssClass= "btn btn-primary";
                    }
                    else
                    {

                        _observacion.ReadOnly = false;
                        _btnAceptaAnulacionOrden.Enabled = true;
                        _detalleOrdenTrabajoId.Value = _datos.Rows[index].Cells[0].Text;
                    }

                    
                }
            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }

        }

        /// <summary>
        /// Anula la Orden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _anularOrden_Click(object sender, EventArgs e)
        {
            try
            {
                int ordenCerrada = Convert.ToInt32(_listaHistorialProcesoVistaModelos.Where(a => a.EtapaProceso.EtapaProcesoId.Equals(Convert.ToInt32(Util.EtapaProceso.EntregaFranquiciaHaciaCliente))).Select(b => b.EtapaProceso.EtapaProcesoId).FirstOrDefault().ToString());
                int ordenAnulada = Convert.ToInt32(_listaHistorialProcesoVistaModelos.Where(a => a.EtapaProceso.EtapaProcesoId.Equals(Convert.ToInt32(Util.EtapaProceso.AnulacionOrdenTrabajo))).Select(b => b.EtapaProceso.EtapaProcesoId).FirstOrDefault().ToString());
                _observacionAnularOrden.Text=String.Empty;
                if (ordenCerrada == Convert.ToInt32(Util.EtapaProceso.EntregaFranquiciaHaciaCliente) ||
                    ordenAnulada == Convert.ToInt32(Util.EtapaProceso.AnulacionOrdenTrabajo))
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Orden_Cerrada").ToString(), "_btnBuscar");
                else
                {

                    _btnAnularOrden_ModalPopupExtender.TargetControlID = "_btnBuscar";
                    _btnAnularOrden_ModalPopupExtender.Show();
                    _valorTotalAnularOrden.Text = String.Format("{0:0.00}",
                        _listaDetalleOrdenTrabajoVistaModelos.Sum(m => m.ValorTotal));

                    foreach (
                        ConsultaOrdenTrabajoVistaDTOs consultaOrdenTrabajoVista in _listaConsultaOrdenTrabajoVistaDtOses
                        )
                    {
                        _estadoPagoAnularOrden.Text = consultaOrdenTrabajoVista.EstadoPago;
                    }
                }


            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        /// <summary>
        /// Cierra la orden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _cerrarOrdenTrabajo_Click(object sender, EventArgs e)
        {
            try
            {
                int ordenCerrada = Convert.ToInt32(_listaHistorialProcesoVistaModelos.Where(a => a.EtapaProceso.EtapaProcesoId.Equals(Convert.ToInt32(Util.EtapaProceso.EntregaFranquiciaHaciaCliente))).Select(b => b.EtapaProceso.EtapaProcesoId).FirstOrDefault().ToString());
                int ordenAnulada = Convert.ToInt32(_listaHistorialProcesoVistaModelos.Where(a => a.EtapaProceso.EtapaProcesoId.Equals(Convert.ToInt32(Util.EtapaProceso.AnulacionOrdenTrabajo))).Select(b => b.EtapaProceso.EtapaProcesoId).FirstOrDefault().ToString());

                if (ordenCerrada == Convert.ToInt32(Util.EtapaProceso.EntregaFranquiciaHaciaCliente) || ordenAnulada== Convert.ToInt32(Util.EtapaProceso.AnulacionOrdenTrabajo))
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Orden_Cerrada").ToString(), "_btnBuscar");
                else
                {
                    //VDOCS.Where(a => a.NODOC.Equals(sNumeroDocumento)).Select(b => b.CLAVEACCESO).First().ToString();
                    _btnCerrarOrden_ModalPopupExtender.TargetControlID = "_btnBuscar";
                    _btnCerrarOrden_ModalPopupExtender.Show();
                    CargarDatos();
                }
                
              
            }
            catch (Exception ex)
            {

                throw;
            }

        }
       

        /// <summary>
        /// Retorna a la pagina  de inicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Inicio/Default.aspx");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Carga los datos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    _sucursal.DataSource =
                      _servicioDelegadoGeneral.ObtenerPuntosVentaPorSucursalId(Convert.ToInt32(Util.Sucursal.Quito));
                    _sucursal.DataBind();
                    if (User.NombrePerfil != "ADMINISTRADOR" )
                    {
                        _sucursal.SelectedIndex = _sucursal.Items.IndexOf(_sucursal.Items.FindByValue(User.PuntoVentaId.ToString()));
                        _sucursal.Enabled = false;
                    }
                    else
                    {

                        _sucursal.Enabled = true;
                    }
                    BloquearControles();
                }
                
            }
            catch (Exception ex)
            {
                
                throw;
            }

        }

        /// <summary>
        /// Buscar el numero de  orden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                _listaConsultaOrdenTrabajoVistaDtOses= _servicioDelegadoVenta.ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(_numeroOrden.Text,
                      Convert.ToInt32(_sucursal.SelectedItem.Value));


                if (_listaConsultaOrdenTrabajoVistaDtOses.Count() >0)
                {
                    _listaDetalleOrdenTrabajoVistaModelos = _servicioDelegadoVenta.ObtenerDetalleOrdenTrabajoPorNumeroOrdenYPuntoVenta(_numeroOrden.Text,Convert.ToInt32(_sucursal.SelectedItem.Value));

                    foreach (ConsultaOrdenTrabajoVistaDTOs consultaOrdenTrabajoVista in _listaConsultaOrdenTrabajoVistaDtOses)
                    {
                        _cliente.Text = consultaOrdenTrabajoVista.NombreCliente;
                        _fechaEntrega.Text = consultaOrdenTrabajoVista.FechaEntrega.ToString();
                        _fechaIngreso.Text = consultaOrdenTrabajoVista.FechaIngreso.ToString();
                        _tipoLavado.Text = consultaOrdenTrabajoVista.TipoLavado;
                        _estadoPago.Text = consultaOrdenTrabajoVista.EstadoPago;
                        _numeroOrdenResultado.Text = consultaOrdenTrabajoVista.NumeroOrden;

                    }
                    _datos.DataSource = _listaConsultaOrdenTrabajoVistaDtOses;
                    _datos.DataBind();
                    _listaHistorialProcesoVistaModelos = _servicioDelegadoFlujoProceso.ObtenerHIstorialProcesosPorNumeroOrden(_numeroOrden.Text);
                    _datosHistorial.DataSource = _listaHistorialProcesoVistaModelos;
                    _datosHistorial.DataBind();
                    _listaCuentaPorCobrarVistaDtOses= _servicioDelegadoContabilidad.ObtenerHistorialCuentaPorCobrarPorNumeroOrden(_numeroOrden.Text);
                    _datosPago.DataSource = _listaCuentaPorCobrarVistaDtOses;
                    _datosPago.DataBind();
                    _cuentaPorCobrarId.Value =_listaCuentaPorCobrarVistaDtOses.Select(m=>m.CuentaPorCobrar.CuentaPorCobrarId).FirstOrDefault().ToString();
                    DesbloquearControles();
                   
                }
                else
                {
                    BloquearControles();
                    LimpiarControles();
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Orden_Trabajo_No_Existe").ToString(), "_btnBuscar");
                }
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }
        #endregion


        #region Metodos
        /// <summary>
        /// Despliega  los mensajes    de las diferentes acciones de las  pantallas
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="boton"></param>
        private void Mensajes(string texto, string boton)
        {

            _labelMensaje.Text = texto;
            _btnMensaje_ModalPopupExtender.TargetControlID = boton;
            _btnMensaje_ModalPopupExtender.Show();
        }

        /// <summary>
        /// Limpia los controles de la busqueda
        /// </summary>
        private void LimpiarControles()
        {
            _datos.DataSource = null;
            _datos.DataBind();
            _numeroOrden.Focus();
            _cliente.Text = string.Empty;
            _fechaEntrega.Text = string.Empty;
            _fechaIngreso.Text = string.Empty;
            _tipoLavado.Text = string.Empty;
            _estadoPago.Text = string.Empty;
            _numeroOrdenResultado.Text = string.Empty;
            _fechaEntregaEfectiva.Text=String.Empty;
            _datosHistorial.DataSource = null;
            _datosHistorial.DataBind();
            _datosObservaciones.DataSource = null;
            _datosObservaciones.DataBind();
            _datosPago.DataSource=null;
            _datosPago.DataBind();
            _valorTotal.Text=String.Empty;
            _observacionAnularOrden.Text=String.Empty;
            _observacion.Text=String.Empty;
            _listaConsultaOrdenTrabajoVistaDtOses =  new List<ConsultaOrdenTrabajoVistaDTOs>();
            _listaHistorialProcesoVistaModelos = new List<HistorialProcesoVistaModelo>();
            _listaCuentaPorCobrarVistaDtOses = new List<CuentaPorCobrarVistaDTOs>();

        }

        /// <summary>
        /// Bloquea los controles
        /// </summary>
        private void BloquearControles()
        {
            _cerrarOrdenTrabajo.Enabled = false;
            _anularOrden.Enabled = false;
            _btnAceptarObservaciones.Enabled = false;
            _abonar.Enabled = false;
            _cerrarOrdenTrabajo.CssClass= "btn btn-primary";
            _anularOrden.CssClass= "btn btn-primary";
            _btnAceptarObservaciones.CssClass= "btn btn-primary";
            _abonar.CssClass= "btn btn-primary";
        }

        /// <summary>
        /// Desbloquea los controles
        /// </summary>

        private void DesbloquearControles()
        {
            _cerrarOrdenTrabajo.Enabled = true;
            _anularOrden.Enabled = true;
            _btnAceptarObservaciones.Enabled = true;
            _abonar.Enabled = true;
        }

        /// <summary>
        /// Carga la informaion
        /// </summary>
        private void CargarDatos()
        {
            try
            {
                _estadoPagoOrden.DataSource = _servicioDelegadoGeneral.ObtenerEstadosPago();
                _estadoPagoOrden.DataBind();
                _estadoPagoOrden.SelectedIndex=_estadoPagoOrden.Items.IndexOf(_estadoPagoOrden.Items.FindByValue("2"));
                _estadoPagoOrden.Enabled = false;
                if(_listaCuentaPorCobrarVistaDtOses.Count ==0)
                _valorTotal.Text = String.Format("{0:0.00}", _listaDetalleOrdenTrabajoVistaModelos.Sum(m => m.ValorTotal));
                else
                 _valorTotal.Text = String.Format("{0:0.00}", _listaDetalleOrdenTrabajoVistaModelos.Sum(m => m.ValorTotal)- _listaCuentaPorCobrarVistaDtOses.Sum(b=>b.HistorialCuentaPorCobrar.ValorCobro));
                _valorTotal.Enabled = false;
                _valorTotal.CssClass = "form-control";

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }






        #endregion

       
    }
}