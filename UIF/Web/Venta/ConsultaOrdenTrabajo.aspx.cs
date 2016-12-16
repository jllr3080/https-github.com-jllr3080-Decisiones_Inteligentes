#region using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Base;
using Web.DTOs.Venta;
using Web.ServicioDelegado;

#endregion

namespace Web.Venta
{
    public partial class ConsultaOrdenTrabajo :PaginaBase
    {
        #region Declaraciones  e Instancias
        private readonly ServicioDelegadoVenta _servicioDelegadoVenta= new ServicioDelegadoVenta();
        #endregion

        #region Eventos

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
                
                List<ConsultaOrdenTrabajoVistaDTOs> _listaConsultaOrdenTrabajoVistaDtOses =
                    _servicioDelegadoVenta.ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(_numeroOrden.Text,
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

        }


        #endregion
    }
}