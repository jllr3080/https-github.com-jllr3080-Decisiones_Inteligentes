#region  using
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Base;
using Web.Models.General;
using Web.ServicioDelegado;

#endregion
namespace Web.Parametrizacion
{
    public partial class Color : PaginaBase
    {

        #region Declaraciones e Instancias
        private readonly  ServicioDelegadoGeneral _servicioDelegadoGeneral= new ServicioDelegadoGeneral();
        private static  bool actualizar = false;
        #endregion
        #region Eventos

        /// <summary>
        /// Seleccion los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void _datos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "Editar")
                {
                    _codigoInterno.Text = _datos.Rows[index].Cells[0].Text;
                    _color.Text = _datos.Rows[index].Cells[1].Text;
                    if (_datos.Rows[index].Cells[2].Text ==
                        GetGlobalResourceObject("Web_es_Ec", "Label_Habilitado").ToString())
                        _estaHabilitado.Checked = true;
                    else
                        _estaHabilitado.Checked = false;
                }
                actualizar = true;


            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }

        /// <summary>
        /// Carga la informacion de  verdadero o falso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (Convert.ToBoolean(e.Row.Cells[2].Text)==true)
                    e.Row.Cells[2].Text = GetGlobalResourceObject("Web_es_Ec", "Label_Habilitado").ToString();
                    else if (Convert.ToBoolean(e.Row.Cells[2].Text) == false)
                        e.Row.Cells[2].Text = GetGlobalResourceObject("Web_es_Ec", "Label_Inhabilitado").ToString();

                }
                
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }
        /// <summary>
        /// Carga  la informacion  de la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
               CargarDatos();
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }

        /// <summary>
        /// Actualiza  o inserta la informacion del color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _ingresarInformacion_Click(object sender, EventArgs e)
        {
            try
            {
                ColorVistaModelo _colorVista= new ColorVistaModelo();
                _colorVista.ColorId =Convert.ToInt32(_codigoInterno.Text);
                _colorVista.Descripcion = _color.Text.ToUpper();
                _colorVista.EstaHabilitado = _estaHabilitado.Checked;

                if (actualizar == true)
                {
                    _servicioDelegadoGeneral.ActualizaColor(_colorVista);
                }
                else
                {
                  _servicioDelegadoGeneral.GrabarColor(_colorVista);  
                    
                }
                CargarDatos();
                LimpiarControles();
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }

        /// <summary>
        /// CAncela  y regresa  a la pagina principal
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

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }

        }
        #endregion
        #region Metodos

        /// <summary>
        /// Cargar Datos
        /// </summary>
        private void CargarDatos()
        {
            _datos.DataSource = _servicioDelegadoGeneral.ObetenerTodosColores();
            _datos.DataBind();
            actualizar = false;
            _codigoInterno.Text = "0";
        }


        /// <summary>
        /// Encera los  controles
        /// </summary>
        private void LimpiarControles()
        {
            _color.Text=String.Empty;
            _estaHabilitado.Checked = false;
            
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