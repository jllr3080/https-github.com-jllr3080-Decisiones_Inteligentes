#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JLLR.Core.ServicioDelegado.Proveedor.VistaDTOs.Contabilidad;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Contabilidad;
using Web.Base;

#endregion
namespace Web.Contabilidad
{
    public partial class AprobarPago : PaginaBase
    {

        #region DECLARACIONES  E  INSTANCIAS
        private readonly JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado.ServicioDelegadoGeneral _servicioDelegadoGeneral = new JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado.ServicioDelegadoGeneral();
        private readonly JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado.ServicioDelegadoContabilidad _servicioDelegadoContabilidad = new JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado.ServicioDelegadoContabilidad();
        private static List<AplicacionPagoVistaDTOs> _aplicacionPagoVistaDtOses= new List<AplicacionPagoVistaDTOs>();
        private  static  AplicacionPagoVistaModelo _aplicacionPago= new AplicacionPagoVistaModelo();
        #endregion

        #region EVENTOS

        /// <summary>
        /// Aplica  el pago 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _aplicarPago_OnClick(object sender, EventArgs e)
        {
            try
            {
                _aplicacionPago.NumeroDocumento = _numeroDocumento.Text.ToUpper().TrimEnd();
                _aplicacionPago.FechaDeposito =Convert.ToDateTime(_fechaDeposito.Text);
                _aplicacionPago.FechaValidacion=DateTime.Now;
                _aplicacionPago.EstaValidado = _estaValidado.Checked;
                _servicioDelegadoContabilidad.ActualizaAplicacionPago(_aplicacionPago);
                _aplicacionPagoVistaDtOses = _servicioDelegadoContabilidad.ObtenerAplicacionPagosPorPuntoVentaIdYMesId(
                       Convert.ToInt32(_sucursal.SelectedItem.Value), Convert.ToInt32(_mes.SelectedItem.Value));
                _datos.DataSource = _aplicacionPagoVistaDtOses;
                    _datos.DataBind();
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Exitoso").ToString(), "_btnBuscar");
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Cancela 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void _cancelar_OnClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Inicio/Default.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Seleccionar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "Seleccionar")
                {
                    _aplicacionPago =_aplicacionPagoVistaDtOses.Where(a =>a.AplicacionPago.AplicacionPagoId.Equals(Convert.ToInt32(_datos.Rows[index].Cells[0].Text))).Select(b => b.AplicacionPago).FirstOrDefault();
                    _numeroDocumento.Text = _aplicacionPago.NumeroDocumento;
                    _fechaCreacion.Text = _aplicacionPago.FechaCreacion.ToString();
                    _fechaDeposito.Text = _aplicacionPago.FechaDeposito.ToString();
                    _valor.Text = String.Format("{0:0.00}", _aplicacionPago.Valor); 




                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// Carga  la  informacion inicial de la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    _sucursal.DataSource = _servicioDelegadoGeneral.ObtenerPuntosVentaPorSucursalId(Convert.ToInt32(Util.Sucursal.Quito));
                    _sucursal.DataBind();
                    if (User.NombrePerfil != "ADMINISTRADOR")
                    {
                        _sucursal.SelectedIndex = _sucursal.Items.IndexOf(_sucursal.Items.FindByValue(User.PuntoVentaId.ToString()));
                        _sucursal.Enabled = false;
                    }
                    else
                    {

                        _sucursal.Enabled = true;
                    }

                    _mes.DataSource = _servicioDelegadoGeneral.ObtenerMeses(); ;
                    _mes.DataBind();
                  

                }
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }

        /// <summary>
        /// Busca  todas las aplicaciones por mes  y sucurisa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnBuscar_OnClick(object sender, EventArgs e)
        {
            try
            {
                _aplicacionPagoVistaDtOses= _servicioDelegadoContabilidad.ObtenerAplicacionPagosPorPuntoVentaIdYMesId(
                        Convert.ToInt32(_sucursal.SelectedItem.Value), Convert.ToInt32(_mes.SelectedItem.Value));
                if (_aplicacionPagoVistaDtOses.Count > 0)
                {
                    _datos.DataSource = _aplicacionPagoVistaDtOses;
                    _datos.DataBind();
                }
                else
                {
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Informacion_No_existe").ToString(), "_btnBuscar");
                    _datos.DataSource =null;
                    _datos.DataBind();
                }
                
                


            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }
        #endregion

        #region METODOS
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