﻿#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Base;
using Web.Models.General;
using Web.Models.Venta.Parametrizacion;
using Web.ServicioDelegado;

#endregion

namespace Web.Parametrizacion
{
    public partial class Comision : PaginaBase
    {

        #region Declaraciones e Instancias
        private readonly  ServicioDelegadoVenta     _servicioDelegadoVenta= new ServicioDelegadoVenta();
        private readonly ServicioDelegadoGeneral _servicioDelegadoGeneral = new ServicioDelegadoGeneral();
        private static  List<VentaComisionVistaModelo>  _listaComisionVistaModelos= new List<VentaComisionVistaModelo>();
        #endregion

        #region eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                    CargarInformacionInicial();
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }


        /// <summary>
        /// Obtiene la informacion de copmisiones pr  sucursal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _sucursal_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _listaComisionVistaModelos =
                    _servicioDelegadoVenta.ObtenerVentaComisiones(Convert.ToInt32(_sucursal.SelectedItem.Value));
                _datos.DataSource = _listaComisionVistaModelos;
                _datos.DataBind();

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }


        /// <summary>
        /// cancela  y se va a la pagina de inciio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        protected void _datos_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }

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

        protected void _datos_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                _datos.PageIndex = e.NewPageIndex;
                _datos.DataSource = _listaComisionVistaModelos;
                _datos.DataBind();

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }
        #endregion
        #region Metodos


        /// <summary>
        /// Carga informacion inicial
        /// </summary>
        private void CargarInformacionInicial()
        {

            List<PuntoVentaVistaModelo> _listaPuntoVentaVistaModelos = _servicioDelegadoGeneral.ObtenerPuntosVentaPorSucursalId(Convert.ToInt32(User.SucursalId));
            PuntoVentaVistaModelo _puntoVentaVista = new PuntoVentaVistaModelo();
            _puntoVentaVista.PuntoVentaId = -1;
            _puntoVentaVista.Descripcion = GetGlobalResourceObject("Web_es_Ec", "Texto_Seleccion").ToString();
            _listaPuntoVentaVistaModelos.Add(_puntoVentaVista);
            _sucursal.DataSource = _listaPuntoVentaVistaModelos;
            _sucursal.DataBind();
            _sucursal.SelectedIndex = _sucursal.Items.IndexOf(_sucursal.Items.FindByValue("-1"));


        }

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
        #endregion
    }
}