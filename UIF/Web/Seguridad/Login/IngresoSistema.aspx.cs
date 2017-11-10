#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Base;
using Web.DTOs.Seguridad;
using Web.ServicioDelegado;

#endregion  

namespace Web.Seguridad.Login
{
    public partial class IngresoSistema : System.Web.UI.Page
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly ServicioDelegadoSeguridad servicioDelegadoSeguridad= new ServicioDelegadoSeguridad();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                _usuario.Focus();
        }
        /// <summary>
        /// Ingreso al sistema 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _ingresoSistema_Click(object sender, EventArgs e)
        {
            try
            {

                UsuarioVistaDTOs _usuarioVistaDtOs= servicioDelegadoSeguridad.IngresoSistema(_usuario.Text.Trim(), _contrasena.Text.Trim(),1, 1);

                if (_usuarioVistaDtOs != null)
                {
                    BaseSeguridad baseSeguridad = new BaseSeguridad();
                    baseSeguridad.NombreUsuario = _usuarioVistaDtOs.NombreUsuario;
                    baseSeguridad.NombreSucursal = _usuarioVistaDtOs.NombreSucursal;
                    baseSeguridad.Id = _usuarioVistaDtOs.UsuarioId;
                    baseSeguridad.SucursalId = _usuarioVistaDtOs.SucursalId;
                    baseSeguridad.PuntoVentaId = _usuarioVistaDtOs.PuntoVentaId;
                    baseSeguridad.NombrePuntoVenta = _usuarioVistaDtOs.NombrePuntoVenta;
                    baseSeguridad.PerfilId = _usuarioVistaDtOs.PerfilId;
                    baseSeguridad.NombrePerfil = _usuarioVistaDtOs.NombrePerfil;
                    Session["Contexto"] = baseSeguridad;
                    HttpContext.Current.User = baseSeguridad;
                    Response.Redirect("~/Inicio/Default.aspx");
                }
                else
                {
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Informacion_No_existe").ToString(), "_ingresoSistema");
                }
                
            }
            catch (Exception ex)
            {
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_ingresoSistema");
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
        #endregion


    }
}