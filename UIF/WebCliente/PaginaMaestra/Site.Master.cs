﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebCliente.Base;
using WebCliente.ServicioDelegado;

namespace WebCliente
{
    public partial class SiteMaster : PaginaBaseMaestra
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly ServicioDelegadoSeguridad servicioDelegadoSeguridad = new ServicioDelegadoSeguridad();
        #endregion
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User == null)

                    Response.Redirect("~/Seguridad/IngresoSistema.aspx");
                else
                    CargarMenu();
            }
            // El código siguiente ayuda a proteger frente a ataques XSRF
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Utilizar el token Anti-XSRF de la cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generar un nuevo token Anti-XSRF y guardarlo en la cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Establecer token Anti-XSRF
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validar el token Anti-XSRF
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Error de validación del token Anti-XSRF.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        /// <summary>
        /// Crea el menu dinamicamente
        /// </summary>
        private void CargarMenu()
        {
            try
            {

                _menu.Items.Clear();
                _menu.Font.Size = 8;


                List<DTOs.Seguridad.AccesoVistaDTOs> lista = servicioDelegadoSeguridad.GenerarMenu(Convert.ToInt32(User.Id));



                var emision = new MenuItem("VENTA") { Selectable = false };
                 var fe = new MenuItem("FE") { Selectable = false };
                var usuario = new MenuItem("Usuario : " + User.NombreUsuario) { Selectable = true };
                var cerrarSesion = new MenuItem("Cerrar Sesión") { NavigateUrl = "~/Seguridad/IngresoSistema.aspx" };
                foreach (var usuarioAccesoDTO in lista)
                {
                    if (usuarioAccesoDTO.Modulo == "VENTA")
                        emision.ChildItems.Add(new MenuItem(usuarioAccesoDTO.SubModulo, usuarioAccesoDTO.SubModulo) { NavigateUrl = usuarioAccesoDTO.Url });
                   else if (usuarioAccesoDTO.Modulo == "FE")
                        fe.ChildItems.Add(new MenuItem(usuarioAccesoDTO.SubModulo, usuarioAccesoDTO.SubModulo) { NavigateUrl = usuarioAccesoDTO.Url });



                }

                _menu.Items.Add(emision);
                _menu.Items.Add(fe);
                _menu.Items.Add(usuario);
                _menu.Items.Add(cerrarSesion);


            }
            catch (Exception ex)
            {



            }
        }
    }

}