#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Base;
using Web.ServicioDelegado;

#endregion
namespace Web.Individuo
{
    public partial class Proveedor : PaginaBase
    {
        #region Declaraciones e Instancias
        private readonly ServicioDelegadoGeneral _servicioDelegadoGeneral = new ServicioDelegadoGeneral();
        private readonly ServicioDelegadoIndividuo _servicioDelegadoIndividuo = new ServicioDelegadoIndividuo();
        #endregion

        #region Eventos

        /// <summary>
        /// Carga los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                    CargaDatos();
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBusqueda");
            }

        }

        /// <summary>
        /// Graba el proveedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _grabarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBusqueda");
            }

        }

        /// <summary>
        /// Cancela  la accion  de esta pagina y regresa al inicio
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

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBusqueda");
            }
        }

        /// <summary>
        /// Busca el cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnBusqueda_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBusqueda");
            }
        }

        /// <summary>
        /// Carga las ciudades por el pais y la provincia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _ciudad.DataSource =
                    _servicioDelegadoGeneral.ObtenerCiudadPorPaisIdYEstadoId(Convert.ToInt32(_pais.SelectedItem.Value),
                        Convert.ToInt32(_provincia.SelectedItem.Value));
                _ciudad.DataBind();
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarCliente");
            }
        }

        /// <summary>
        ///  Valida si el numero de documento existe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _numeroDocumento_TextChanged(object sender, EventArgs e)
        {
            try
            {
               

            }
            catch (Exception)
            {

                throw;
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



        private void CargaDatos()
        {
            try
            {
                _formaPago.DataSource = _servicioDelegadoGeneral.ObtenerFormaPagos();
                _formaPago.DataBind();
                _tipoDocumento.DataSource = _servicioDelegadoGeneral.ObtenerTipoIdentificaciones();
                _tipoDocumento.DataBind();
                _pais.DataSource = _servicioDelegadoGeneral.ObtenerPaises();
                _pais.DataBind();
                _provincia.DataSource =
                    _servicioDelegadoGeneral.ObtenerEstadoPorPaisId(Convert.ToInt32(_pais.SelectedItem.Value));
                _provincia.DataBind();
                _ciudad.DataSource =
                    _servicioDelegadoGeneral.ObtenerCiudadPorPaisIdYEstadoId(Convert.ToInt32(_pais.SelectedItem.Value),
                        Convert.ToInt32(_provincia.SelectedItem.Value));
                _ciudad.DataBind();
                _tipoDireccion.DataSource = _servicioDelegadoGeneral.ObtenerTipoDirecciones();
                _tipoDireccion.DataBind();
                _tipoCorreo.DataSource = _servicioDelegadoGeneral.ObtenerTiposCorreoElectronico();
                _tipoCorreo.DataBind();
                _tipoTelefono.DataSource = _servicioDelegadoGeneral.ObtenerTiposTelefonos();
                _tipoTelefono.DataBind();
                _numeroDocumento.Enabled = true;
                _tipoDocumento.Enabled = true;
            }
            catch (Exception)
            {
                
                throw;
            }
             
            
            
        }

        #endregion

      
    }
}