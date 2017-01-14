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
        private static List<HistorialProcesoVistaModelo> _listaHistorialProcesoVistaModelos = null;
        private static  List<CuentaPorCobrarVistaDTOs>  _listaCuentaPorCobrarVistaDtOses = null; 
        #endregion

        #region Eventos

        /// <summary>
        /// Abonar valor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _abonarValor_Click(object sender, EventArgs e)
        {
            try
            {

                if (_listaCuentaPorCobrarVistaDtOses.Count > 0)
                {
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



            }
            catch (Exception ex)
            {

                throw;
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
                _btnAbonar_ModalPopupExtender.TargetControlID = "_btnBuscar";
                _btnAbonar_ModalPopupExtender.Show();

            }
            catch (Exception)
            {

                throw;
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

                throw;
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
                _historialProcesoVista.NumeroOrden = _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NumeroOrden).First().ToString();
                _servicioDelegadoFlujoProceso.GrabarHistorialProceso(_historialProcesoVista);
                _listaHistorialProcesoVistaModelos = _servicioDelegadoFlujoProceso.ObtenerHIstorialProcesosPorNumeroOrden(_numeroOrden.Text);
                _datosHistorial.DataSource = _listaHistorialProcesoVistaModelos;
                _datosHistorial.DataBind();
            }
            catch (Exception ex)
            {

                throw;
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
                HistorialProcesoVistaModelo _historialProcesoVista = new HistorialProcesoVistaModelo();
                _historialProcesoVista.OrdenTrabajoId = _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.OrdenTrabajoId).First(); ;
                EtapaProcesoVistaModelo _etapaProcesoVistaModelo = new EtapaProcesoVistaModelo();
                _etapaProcesoVistaModelo.EtapaProcesoId = Convert.ToInt32(Util.EtapaProceso.AnulacionOrdenTrabajo);
                _historialProcesoVista.EtapaProceso = _etapaProcesoVistaModelo;
                _historialProcesoVista.FechaRegistro = DateTime.Now;
                _historialProcesoVista.FechaInicio = DateTime.Now;
                _historialProcesoVista.FechaFin = DateTime.Now;
                _historialProcesoVista.NumeroOrden = _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NumeroOrden).First().ToString();
                _historialProcesoVista.Texto = _observacionAnularOrden.Text;
                _servicioDelegadoFlujoProceso.GrabarHistorialProceso(_historialProcesoVista);
                _listaHistorialProcesoVistaModelos = _servicioDelegadoFlujoProceso.ObtenerHIstorialProcesosPorNumeroOrden(_numeroOrden.Text);
                _datosHistorial.DataSource = _listaHistorialProcesoVistaModelos;
                _datosHistorial.DataBind();
            }
            catch (Exception ex)
            {
                
                throw;
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
                    List<DetalleOrdenTrabajoObservacionVistaModelo> _lisaDetalleOrdenTrabajoObservacion= _servicioDelegadoVenta.ObtenerDetalleOrdenTrabajoObservaciones(Convert.ToInt32(_datos.Rows[index].Cells[0].Text));
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

                throw;
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
                        _listaConsultaOrdenTrabajoVistaDtOses.Sum(m => m.ValorTotal));

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
                BloquearControles();
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
                      Convert.ToInt32(User.PuntoVentaId));


                if (_listaConsultaOrdenTrabajoVistaDtOses.Count() >0)
                {
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
                    _listaHistorialProcesoVistaModelos= _servicioDelegadoFlujoProceso.ObtenerHIstorialProcesosPorNumeroOrden(_numeroOrden.Text);
                    _datosHistorial.DataSource = _listaHistorialProcesoVistaModelos;
                    _datosHistorial.DataBind();
                    _listaCuentaPorCobrarVistaDtOses= _servicioDelegadoContabilidad.ObtenerHistorialCuentaPorCobrarPorNumeroOrden(_numeroOrden.Text);
                    _datosPago.DataSource = _listaCuentaPorCobrarVistaDtOses;
                    _datosPago.DataBind();
                    _valorTotal.Text =String.Format("{0:0.00}", _listaConsultaOrdenTrabajoVistaDtOses.Sum(m => m.ValorTotal));
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
        }

        /// <summary>
        /// Desbloquea los controles
        /// </summary>

        private void DesbloquearControles()
        {
            _cerrarOrdenTrabajo.Enabled = true;
            _anularOrden.Enabled = true;
            _btnAceptarObservaciones.Enabled = true;
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

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }




        #endregion

        
    }
}