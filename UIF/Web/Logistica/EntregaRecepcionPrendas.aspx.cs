#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Base;
using Web.DTOs.Seguridad;
using Web.DTOs.Venta;
using Web.ServicioDelegado;

#endregion

namespace Web.Logistica
{
    public partial class EntregaRecepcionPrendas : PaginaBase
    {

        #region  Declaraciones  e Instancias

        private readonly  ServicioDelegadoVenta _servicioDelegadoVenta= new ServicioDelegadoVenta();
        private readonly  ServicioDelegadoSeguridad _servicioDelegadoSeguridad= new ServicioDelegadoSeguridad();
        private static List<OrdenTrabajoVistaDTOs> _listaOrdenTrabajoVistaDtOses = null;
        #endregion

        #region  Eventos

        /// <summary>
        /// Guardar la informacion del transporte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnGuardarinformacion_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioVistaDTOs _usuarioVistaDtOs = _servicioDelegadoSeguridad.IngresoSistema(_usuario.Text, _contrasena.Text, 1, 1);
                if (_usuarioVistaDtOs != null)
                {

                }
                else
                {
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Informacion_No_existe").ToString(), "_grabarEntregaRecepcionPrenda");
                }

            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarEntregaRecepcionPrenda");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DetalleOrden")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    _btnDetalleOrden_ModalPopupExtender.TargetControlID = "_btnGuardarinformacion";
                    _btnDetalleOrden_ModalPopupExtender.Show();
                    //List<DetalleOrdenTrabajoObservacionVistaModelo> _lisaDetalleOrdenTrabajoObservacion = _servicioDelegadoVenta.ObtenerDetalleOrdenTrabajoObservaciones(Convert.ToInt32(_datos.Rows[index].Cells[0].Text));
                    _datosDetalleOrden.DataSource=_listaOrdenTrabajoVistaDtOses.Where(m=>m.OrdenTrabajo.OrdenTrabajoId.Equals(Convert.ToInt64(_datos.Rows[index].Cells[0].Text))).Select(a=>a.DetalleOrdenTrabajo);
                    _datosDetalleOrden.DataBind();
                }
            }
            catch (Exception ex)
            {

            }


        }

        /// <summary>
        /// Graba la entrega de prendas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _grabarEntregaRecepcionPrenda_Click(object sender, EventArgs e)
        {
            try
            {
                _btnSeguridad_ModalPopupExtender.TargetControlID = "_grabarEntregaRecepcionPrenda";
                _btnSeguridad_ModalPopupExtender.Show();
                _usuario.Text= string.Empty;
                _contrasena.Text= string.Empty;
            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarEntregaRecepcionPrenda");
            }
        }

        /// <summary>
        /// Cancela  y regresa  al inicio
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
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarEntregaRecepcionPrenda");
            }
        }

        /// <summary>
        ///  Carga la informacion incial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                if (!IsPostBack)
                {
                    _listaOrdenTrabajoVistaDtOses = _servicioDelegadoVenta.ObtenerOrdenTrabajoPorEnvioMatriz();


                    if (_listaOrdenTrabajoVistaDtOses.Count > 0)
                    {

                        List<HerenciaOrdenTrabajoVistaDTOs> _listaHerenciaOrdenTrabajoVistaDtOses= new List<HerenciaOrdenTrabajoVistaDTOs>();
                        foreach (var objetoOrdenTrabajoDtos in _listaOrdenTrabajoVistaDtOses)
                        {
                            HerenciaOrdenTrabajoVistaDTOs _herenciaOrdenTrabajoVista= new HerenciaOrdenTrabajoVistaDTOs();
                            _herenciaOrdenTrabajoVista.OrdenTrabajo = objetoOrdenTrabajoDtos.OrdenTrabajo;
                            _herenciaOrdenTrabajoVista.DetalleOrdenTrabajo = objetoOrdenTrabajoDtos.DetalleOrdenTrabajo;
                            _herenciaOrdenTrabajoVista.NumeroPrenda =Convert.ToInt32(
                                objetoOrdenTrabajoDtos.DetalleOrdenTrabajo.Sum(m => m.Cantidad));

                            _listaHerenciaOrdenTrabajoVistaDtOses.Add(_herenciaOrdenTrabajoVista);


                        }
                        _datos.DataSource = _listaHerenciaOrdenTrabajoVistaDtOses;
                        _datos.DataBind();
                    }
                    else
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Informacion_No_existe").ToString(), "_grabarEntregaRecepcionPrenda");

                }
                
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarEntregaRecepcionPrenda");
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



        #endregion

        
    }
}