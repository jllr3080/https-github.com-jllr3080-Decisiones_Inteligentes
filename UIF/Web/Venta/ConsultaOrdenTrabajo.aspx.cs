#region using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Base;
using Web.DTOs.Venta;
using Web.Models.FlujoProceso;
using Web.Models.General;
using Web.ServicioDelegado;

#endregion

namespace Web.Venta
{
    public partial class ConsultaOrdenTrabajo :PaginaBase
    {
        #region Declaraciones  e Instancias
        private readonly ServicioDelegadoVenta _servicioDelegadoVenta= new ServicioDelegadoVenta();
        private readonly  ServicioDelegadoFlujoProceso _servicioDelegadoFlujoProceso= new ServicioDelegadoFlujoProceso();
        private readonly ServicioDelegadoGeneral _servicioDelegadoGeneral = new  ServicioDelegadoGeneral();
        private static List<ConsultaOrdenTrabajoVistaDTOs> _listaConsultaOrdenTrabajoVistaDtOses =null;
        #endregion

        #region Eventos

        /// <summary>
        /// Agrega Observaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnAceptarObservaciones_Click(object sender, EventArgs e)
        {
            try
            {
                

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
                string ups = "asdasda";
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
                    _btnObservaciones_ModalPopupExtender.TargetControlID = "_btnBuscar";
                    _btnObservaciones_ModalPopupExtender.Show();
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
                _btnAnularOrden_ModalPopupExtender.TargetControlID = "_btnBuscar";
                _btnAnularOrden_ModalPopupExtender.Show();
                _valorTotalAnularOrden.Text = String.Format("{0:0.00}", _listaConsultaOrdenTrabajoVistaDtOses.Sum(m => m.ValorTotal));

                foreach (ConsultaOrdenTrabajoVistaDTOs consultaOrdenTrabajoVista in _listaConsultaOrdenTrabajoVistaDtOses)
                {
                    _estadoPagoAnularOrden.Text = consultaOrdenTrabajoVista.EstadoPago;
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
                //VDOCS.Where(a => a.NODOC.Equals(sNumeroDocumento)).Select(b => b.CLAVEACCESO).First().ToString();
                _btnCerrarOrden_ModalPopupExtender.TargetControlID = "_btnBuscar";
                _btnCerrarOrden_ModalPopupExtender.Show();
                CargarDatos();
                //GUarda el proceso inicial que es la entrega del cliente hacia  la franquicia
                HistorialProcesoVistaModelo _historialProcesoVista = new HistorialProcesoVistaModelo();
                _historialProcesoVista.OrdenTrabajoId = 123;
                EtapaProcesoVistaModelo _etapaProcesoVistaModelo = new EtapaProcesoVistaModelo();
                _etapaProcesoVistaModelo.EtapaProcesoId =Convert.ToInt32(Util.EtapaProceso.EntregaFranquiciaHaciaCliente);
                _historialProcesoVista.EtapaProceso = _etapaProcesoVistaModelo;
                _historialProcesoVista.FechaRegistro = DateTime.Now;
                _historialProcesoVista.FechaInicio = DateTime.Now;
                _historialProcesoVista.FechaFin = DateTime.Now;
                _historialProcesoVista.NumeroOrden = _listaConsultaOrdenTrabajoVistaDtOses.Select(m=>m.NumeroOrden).First().ToString();
                _servicioDelegadoFlujoProceso.GrabarHistorialProceso(_historialProcesoVista);
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
                    
                    _datosHistorial.DataSource =_servicioDelegadoFlujoProceso.ObtenerHIstorialProcesosPorNumeroOrden(_numeroOrden.Text);
                    _datosHistorial.DataBind();
                    // String.Format("{0:0.00}", productoPrecioVistaModelo.Precio);
                    
                    _valorTotal.Text =String.Format("{0:0.00}", _listaConsultaOrdenTrabajoVistaDtOses.Sum(m => m.ValorTotal));
                   
                }
                else
                {
                   
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
            _listaConsultaOrdenTrabajoVistaDtOses = null;
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