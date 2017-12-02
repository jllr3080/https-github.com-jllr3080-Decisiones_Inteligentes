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
using Web.Util;

#endregion

namespace Web.Parametrizacion
{
    public partial class Sucursal : PaginaBase
    {

        #region Declaraciones  e Instancias

        private readonly  ServicioDelegadoVenta _servicioDelegadoVenta= new ServicioDelegadoVenta();
        private static bool actualizar = false;
        private static List<NumeracionOrdenVistaDTOs> _listaNumeracionOrdenVistaDtOses= new List<NumeracionOrdenVistaDTOs>(); 
        #endregion

        #region Eventos

        /// <summary>
        /// carga inicial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                    CargarInformacionInicial();

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }

        protected void _ingresarInformacion_OnClick(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }

        protected void _cancelar_OnClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Inicio/Default.aspx");
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }


        /// <summary>
        /// Obtiene los  valores para editar    
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "Editar")
                {
                    var _lista=_listaNumeracionOrdenVistaDtOses.Select(a => a.NumeracionOrden)
                        .Where(a => a.PuntoVentaId.Equals(Convert.ToInt32(_datos.Rows[index].Cells[0].Text)));

                    _codigoInterno.Text = _datos.Rows[index].Cells[0].Text;
                    _nombreSucursal.Text = _datos.Rows[index].Cells[1].Text;
                    foreach (var numeroOrden in _lista)
                    {
                        if (numeroOrden.NumeroOden.ToString() == _datos.Rows[index].Cells[2].Text)
                            _numeroInicioSeco.Text = numeroOrden.Numero.ToString();
                        else
                            _numeroInicioAgua.Text = numeroOrden.Numero.ToString();

                    }

                  
                }
                actualizar = true;
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }


        /// <summary>
        /// Edita la informacion  que se genera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }


        /// <summary>
        /// Pagina  el grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                _datos.PageIndex = e.NewPageIndex;
                CargarInformacionInicial();
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
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
        /// Carga la informacion inicial
        /// </summary>
        private void CargarInformacionInicial()
        {
            try
            {
                _listaNumeracionOrdenVistaDtOses= _servicioDelegadoVenta.ObtenerPuntosVentaCompleto();
                _datos.DataSource = _listaNumeracionOrdenVistaDtOses;
                _datos.DataBind();
            }
            catch (Exception ex)
            {
                    
                throw;
            }
        }

        #endregion
    }
}