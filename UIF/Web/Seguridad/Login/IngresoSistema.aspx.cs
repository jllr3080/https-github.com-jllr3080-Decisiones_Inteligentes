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
                UsuarioVistaDTOs _usuarioVistaDtOs= servicioDelegadoSeguridad.IngresoSistema(_usuario.Text, _contrasena.Text, 1, 1);
                BaseSeguridad baseSeguridad=new BaseSeguridad();
                baseSeguridad.NombreUsuario = _usuarioVistaDtOs.NombreUsuario;
                baseSeguridad.NombreSucursal = _usuarioVistaDtOs.NombreSucursal;
                baseSeguridad.Id = _usuarioVistaDtOs.UsuarioId;
                baseSeguridad.SucursalId = _usuarioVistaDtOs.SucursalId;
                baseSeguridad.PuntoVentaId = _usuarioVistaDtOs.PuntoVentaId;
                baseSeguridad.NombrePuntoVenta = _usuarioVistaDtOs.NombrePuntoVenta;
                Session["Contexto"] = baseSeguridad;
                HttpContext.Current.User = baseSeguridad;
                Response.Redirect("~/Inicio/Default.aspx");
            }
            catch (Exception ex)
            {
                
            }

        }
        #endregion


    }
}