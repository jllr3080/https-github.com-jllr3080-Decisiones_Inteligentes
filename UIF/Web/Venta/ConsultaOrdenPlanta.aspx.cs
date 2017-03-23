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
using Web.Models.FlujoProceso;
using Web.Models.Venta.Negocio;
using Web.ServicioDelegado;

#endregion

namespace Web.Venta
{
    public partial class ConsultaOrdenPlanta : PaginaBase
    {

        #region DECLARACIONES  E INSTANCIAS
        private readonly ServicioDelegadoVenta _servicioDelegadoVenta = new ServicioDelegadoVenta();
        private readonly ServicioDelegadoGeneral _servicioDelegadoGeneral = new ServicioDelegadoGeneral();
        private static List<ConsultaOrdenTrabajoVistaDTOs> _listaConsultaOrdenTrabajoVistaDtOses = null;


        #endregion

        #region Eventos

        /// <summary>
        /// Agrega las  observaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnAceptarObservaciones_Click(object sender, EventArgs e)
        {
            try
            {
                DetalleOrdenTrabajoObservacionVistaModelo _detalleOrdenTrabajoObservacion = new DetalleOrdenTrabajoObservacionVistaModelo();
                _detalleOrdenTrabajoObservacion.UsuarioId = User.Id;
                _detalleOrdenTrabajoObservacion.DetalleOrdenTrabajoId = Convert.ToInt32(_detalleOrdenTrabajoId.Value);
                _detalleOrdenTrabajoObservacion.FechaCreacionObservacion = DateTime.Now;
                _detalleOrdenTrabajoObservacion.Observacion = _observacion.Text.ToUpper();
                _servicioDelegadoVenta.GrabarDetalleOrdenTrabajoObservacion(_detalleOrdenTrabajoObservacion);
                _observacion.Text = String.Empty;

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }


        /// <summary>
        /// Carga  los totales de las prendas  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private decimal _montoTotal = 0;
        private int _cantidadTotal = 0;
        protected void _datos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    _montoTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ValorTotal"));
                    _cantidadTotal += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Cantidad"));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Totales:";
                    e.Row.Cells[1].Text = _cantidadTotal.ToString();
                    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;

                    e.Row.Cells[6].Text = _montoTotal.ToString("C");
                    e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Font.Bold = true;
                }
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }
        

        /// <summary>
        /// Carga los datos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                _observacion.Text = String.Empty;
                _btnObservaciones_ModalPopupExtender.TargetControlID = "_btnBuscar";
                _btnObservaciones_ModalPopupExtender.Show();
                int index = Convert.ToInt32(e.CommandArgument);
                List<DetalleOrdenTrabajoObservacionVistaDTOs> _lisaDetalleOrdenTrabajoObservacion = _servicioDelegadoVenta.ObtenerDetalleOrdenTrabajoObservacionPorDetalleOrdenTrabajoId(Convert.ToInt32(_datos.Rows[index].Cells[0].Text));
                if (_lisaDetalleOrdenTrabajoObservacion.Count > 0)
                {
                    _detalleOrdenTrabajoId.Value = _datos.Rows[index].Cells[0].Text;
                    _datosObservaciones.DataSource = _lisaDetalleOrdenTrabajoObservacion;
                    _datosObservaciones.DataBind();
                }

                
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }

        /// <summary>
        /// Carga los  datos  de la pagina
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
                }
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }

        /// <summary>
        /// Busca la información de la orden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarControles();
                _listaConsultaOrdenTrabajoVistaDtOses = _servicioDelegadoVenta.ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(_numeroOrden.Text,Convert.ToInt32(_sucursal.SelectedItem.Value));


                if (_listaConsultaOrdenTrabajoVistaDtOses.Count() > 0)
                {
                    _datos.DataSource = _listaConsultaOrdenTrabajoVistaDtOses;
                    _datos.DataBind();
                   
                }
                else
                {
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
        /// Limpia  los controles  de la pantalla
        /// </summary>
        private void LimpiarControles()
        {
            _datos.DataSource = null;
            _datos.DataBind();
        }



        #endregion

        
    }
}