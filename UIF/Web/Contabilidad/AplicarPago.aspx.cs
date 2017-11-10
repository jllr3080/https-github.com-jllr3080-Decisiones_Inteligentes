#region  using
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Contabilidad;
using Web.Base;

#endregion

namespace Web.Contabilidad
{
    public partial class AplicarPago : PaginaBase
    {

        #region DECLARACIONES  E INSTANCIAS
        private readonly JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado.ServicioDelegadoGeneral _servicioDelegadoGeneral = new JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado.ServicioDelegadoGeneral();
        private readonly JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado.ServicioDelegadoContabilidad _servicioDelegadoContabilidad = new JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado.ServicioDelegadoContabilidad();
        #endregion
        #region EVENTOS

        /// <summary>
        /// 
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
                    _cierreMesId.Value = _datos.Rows[index].Cells[0].Text;
                    _valor.Text = _datos.Rows[index].Cells[2].Text;

                 }
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }
        /// <summary>
        /// Graba la aplicacion del pago
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void _aplicarPago_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (_documento.FileBytes.Length <= 1048576)
                {
                    if (_documento.HasFile)

                    {
                        bool extensionValida = false;
                        string extension = System.IO.Path.GetExtension(_documento.FileName).ToLower();
                        String[] allowedExtensions = { ".png", ".jpeg", ".jpg" };
                        for (int i = 0; i < allowedExtensions.Length; i++)
                        {
                            if (extension == allowedExtensions[i])
                            {
                                extensionValida = true;
                            }
                        }

                        if (extensionValida)
                        {
                            using (BinaryReader reader = new BinaryReader(_documento.PostedFile.InputStream))
                            {
                                byte[] documento = reader.ReadBytes(_documento.PostedFile.ContentLength);
                                AplicacionPagoVistaModelo aplicacionPago = new AplicacionPagoVistaModelo();
                                aplicacionPago.UsuarioAplicaId = User.Id;
                                CierreMesVistaModelo cierreMes= new CierreMesVistaModelo();
                                cierreMes.CierreMesId = Convert.ToInt32(_cierreMesId.Value);
                                aplicacionPago.CierreMes = cierreMes;
                                aplicacionPago.FechaCreacion = Convert.ToDateTime(_fechaCreacion.Text);
                                aplicacionPago.FechaDeposito = Convert.ToDateTime(_fechaDeposito.Text);
                                aplicacionPago.Valor = Convert.ToDecimal(_valor.Text);
                                aplicacionPago.NumeroDocumento = _numeroDocumento.Text;
                                aplicacionPago.Documento = documento;
                                _servicioDelegadoContabilidad.GrabaAplicacionPago(aplicacionPago);
                                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Exitoso").ToString(), "_btnBuscar");
                                LimpiarControles();


                            }
                        }
                        else
                        {
                            Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Formato_No_Valido").ToString(), "_btnBuscar");
                        }



                    }
                    else
                    {
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Imagen_No_Cargada").ToString(), "_btnBuscar");
                    }

                }
                else
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Tamano_No_Valido").ToString(), "_btnBuscar");
              
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }

        /// <summary>
        /// Cancela  y retorna al inicio
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

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }
        /// <summary>
        /// Carga  la informacion importante  de la pagina
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
                    _fechaCreacion.Text = DateTime.Now.ToShortDateString();

                }
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }

        }

        /// <summary>
        /// Busca  la informacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnBuscar_OnClick(object sender, EventArgs e)
        {
            try
            {
                _datos.DataSource =
                    _servicioDelegadoContabilidad.ObtenerCierresMesPorAplicacionPendiente(
                        Convert.ToInt32(_mes.SelectedItem.Value), Convert.ToInt32(_sucursal.SelectedItem.Value));
                _datos.DataBind();
                if (_datos.Rows.Count ==0)
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Informacion_No_existe").ToString(), "_btnBuscar");
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }
        #endregion

        #region  METODOS
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
        /// Limpia  los ocntroles
        /// </summary>
        private void LimpiarControles()
        {
            _numeroDocumento.Text=String.Empty;
            _fechaCreacion.Text=DateTime.Now.ToShortDateString();
            _fechaDeposito.Text=String.Empty;
            _valor.Text=String.Empty;
        }

        #endregion

       
    }
}