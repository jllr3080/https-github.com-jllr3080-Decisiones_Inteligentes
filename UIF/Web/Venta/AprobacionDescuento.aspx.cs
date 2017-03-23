using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Base;
using Web.DTOs.Venta;
using Web.Models.Venta.Negocio;
using Web.ServicioDelegado;

namespace Web.Venta
{
    public partial class AprobacionDescuento : PaginaBase
    {
        #region  DECLARACIONES  E INSTANCIAS
        private readonly  ServicioDelegadoVenta  _servicioDelegadoVenta= new ServicioDelegadoVenta();
        private static OrdenTrabajoDescuentoVistaModelo _ordenTrabajoDescuentoVista = null;
        private static List<OrdenTrabajoDescuentoVistaDTO> _listaOrdenTrabajoDescuentoVistaDtos = null; 
        #endregion

        #region  Eventos
        /// <summary>
        /// Caraga los  datos para la edición del descuento de la  orden de trabajo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Editar")

                {
                 
                    int index = Convert.ToInt32(e.CommandArgument);
                    _ordenTrabajoDescuentoVista =_listaOrdenTrabajoDescuentoVistaDtos.Where(a=>a.OrdenTrabajoDescuento.OrdenTrabajoDescuentoId.Equals(Convert.ToInt64(_datos.Rows[index].Cells[1].Text))).Select(m => m.OrdenTrabajoDescuento).FirstOrDefault();
                    _ordenTrabajoDescuentoId.Value = _datos.Rows[index].Cells[1].Text;
                    _puntoVenta.Text= _datos.Rows[index].Cells[2].Text;
                    _numeroOrden.Text= _datos.Rows[index].Cells[3].Text;
                    _valor.Text = _datos.Rows[index].Cells[4].Text;
                    _motivo.Text = _datos.Rows[index].Cells[5].Text;
                    _porcentajeFranquicia.Text= _datos.Rows[index].Cells[6].Text;
                    _porcentajeMatriz.Text = _datos.Rows[index].Cells[7].Text;

                }
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_aprobacionDescuento");
            }

        }
        /// <summary>
        /// Carga  la informacion de la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    
                   CargaDatos();
                

            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_aprobacionDescuento");
            }
        }

        /// <summary>
        /// Graba la aprobacion del  descuento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _aprobacionDescuento_Click(object sender, EventArgs e)
        {
            try
            {
                AprobacionDescuentoVistaModelo _aprobacionDescuentoVista= new AprobacionDescuentoVistaModelo();
                _aprobacionDescuentoVista.OrdenTrabajoDescuento = _ordenTrabajoDescuentoVista;
                _aprobacionDescuentoVista.OrdenTrabajo = _ordenTrabajoDescuentoVista.OrdenTrabajo;
                _aprobacionDescuentoVista.usuarioAprobacionId = User.Id;
                _aprobacionDescuentoVista.FechaAprobacion= DateTime.Now;
                _aprobacionDescuentoVista.ValorMatrizAprobacion =Convert.ToDecimal(_valorAprobadoMatriz.Text);
                _aprobacionDescuentoVista.ValorFranquiciaAprobacion = Convert.ToDecimal(_valorAprobadoFranquicia.Text);

                _servicioDelegadoVenta.GrabarAprobacionDescuento(_aprobacionDescuentoVista);
                _ordenTrabajoDescuentoVista.EstadoProceso = true;
                _servicioDelegadoVenta.ActualizarOrdenTrabajoDescuento(_ordenTrabajoDescuentoVista);
                CargaDatos();
                LimpiarControles();





            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_aprobacionDescuento");
            }
        }

        protected void _cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Inicio/Default.aspx");
            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_aprobacionDescuento");
            }
        }
        #endregion

        #region  Metodos

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
        /// Carga  los datos  
        /// </summary>

        public void CargaDatos()
        {
            try
            {
                _listaOrdenTrabajoDescuentoVistaDtos = _servicioDelegadoVenta.ObtenerOrdenesTrabajoDescuentoPorEstadoProceso();
                _datos.DataSource = _listaOrdenTrabajoDescuentoVistaDtos;
                _datos.DataBind();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Limpiar  controles
        /// </summary>
        public void LimpiarControles()
        {
            try
            {
                _ordenTrabajoDescuentoId.Value = String.Empty;
                _puntoVenta.Text = String.Empty;
                _numeroOrden.Text = String.Empty;
                _valor.Text = String.Empty;
                _motivo.Text = String.Empty;
                _porcentajeFranquicia.Text = String.Empty;
                _porcentajeMatriz.Text = String.Empty;
                _ordenTrabajoDescuentoVista = null;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        #endregion

       
    }
}