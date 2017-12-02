#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.General;
using Web.Base;
#endregion
namespace Web.Parametrizacion
{
    public partial class Feriado : PaginaBase
    {
        #region Declaraciones e Instancias
        private readonly  ServicioDelegadoGeneral _servicioDelegadoGeneral= new ServicioDelegadoGeneral();
        private static ParametroVistaModelo _parametroVista=new ParametroVistaModelo();
        #endregion

        #region Eventos
        /// <summary>
        /// Ingresa la  informacion de la habilitacion  de  feriados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _ingresarInformacion_OnClick(object sender, EventArgs e)
        {
            try
            {
                
                _parametroVista.Boolenao = _habilitarFeriado.Checked;
                _servicioDelegadoGeneral.ActualizarParametro(_parametroVista);
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Exitoso").ToString(), "_cancelar");
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }

        }

        /// <summary>
        /// Redirecciona a la pagina de  inicio
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
        /// <summary>
        /// Carga Inicial  de la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                 _parametroVista=_servicioDelegadoGeneral.ObtenerParametroPorDescripcion("BLOQUEAR_FECHA_ENTREGA");
                    _habilitarFeriado.Checked =Convert.ToBoolean(_parametroVista.Boolenao);
                }
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
        #endregion


       
    }
}