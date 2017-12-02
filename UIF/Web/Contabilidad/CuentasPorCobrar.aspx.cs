#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Base;
using Web.DTOs.Contabilidad;
using Web.DTOs.Individuo;
using Web.ServicioDelegado;
using Web.Util;

#endregion
namespace Web.Contabilidad
{
    public partial class CuentasPorCobrar : PaginaBase
    {
        #region DECLARACIONES  E INSTANCIAS

        private  readonly  ServicioDelegadoContabilidad _servicioDelegadoContabilidad= new ServicioDelegadoContabilidad();
        private static List<CuentaPorCobrarVistaDTOs> _cuentaPorCobrarVistaDtOses = null;
        private readonly Util.Colecciones _colecciones = new Colecciones();
        private static List<ClienteGeneralVistaDTOs> listaClienteVistaDtOses = new List<ClienteGeneralVistaDTOs>();
        private  readonly  ServicioDelegadoIndividuo _servicioDelegadoIndividuo= new ServicioDelegadoIndividuo();
        #endregion

        #region Eventos


        /// <summary>
        /// Carga la informacion y pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                _datos.PageIndex = e.NewPageIndex;
                _datos.DataSource = _cuentaPorCobrarVistaDtOses;
                _datos.DataBind();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// Obtiene los tipos de  busqueda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void _tipoBusqueda_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_tipoBusqueda.SelectedItem.Value.ToString() == "1")
                {
                    _numeroDocumentoBusqueda.Text = String.Empty;
                    _numeroDocumentoBusqueda.ReadOnly = false;
                    _parametroDos.Text = String.Empty;
                    _parametroDos.ReadOnly = true;
                    _labelNumeroDocumentoBusqueda.Text = GetGlobalResourceObject("Web_es_Ec", "Label_Numero_Documento").ToString();
                    _labelParametroDos.Text = String.Empty;


                }
                else if (_tipoBusqueda.SelectedItem.Value.ToString() == "-1")
                {

                    _labelNumeroDocumentoBusqueda.Text = String.Empty;
                    _labelParametroDos.Text = String.Empty;
                    _numeroDocumentoBusqueda.Text = String.Empty;
                    _numeroDocumentoBusqueda.ReadOnly = true;

                    _parametroDos.Text = String.Empty;
                    _parametroDos.ReadOnly = true;
                }
                else if (_tipoBusqueda.SelectedItem.Value.ToString() == "2")
                {
                    _numeroDocumentoBusqueda.Text = String.Empty;
                    _numeroDocumentoBusqueda.ReadOnly = false;
                    _parametroDos.Text = String.Empty;
                    _parametroDos.ReadOnly = false;
                    _labelNumeroDocumentoBusqueda.Text = GetGlobalResourceObject("Web_es_Ec", "Label_Apellido_Paterno").ToString();
                    _labelParametroDos.Text = GetGlobalResourceObject("Web_es_Ec", "Label_Busqueda_Apellido_Materno").ToString();

                }
                if (_tipoBusqueda.SelectedItem.Value.ToString() == "3")
                {
                    _numeroDocumentoBusqueda.Text = String.Empty;
                    _numeroDocumentoBusqueda.ReadOnly = false;
                    _parametroDos.Text = String.Empty;
                    _parametroDos.ReadOnly = true;
                    _labelNumeroDocumentoBusqueda.Text = GetGlobalResourceObject("Web_es_Ec", "Label_Razon_Social").ToString();
                    _labelParametroDos.Text = String.Empty;



                }
            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBusquedaCliente");
            }
        }

        protected void _clientes_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {


                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "Seleccionar")
                {

                    _cuentaPorCobrarVistaDtOses = _servicioDelegadoContabilidad.ObtenerCuentasPorCobrarCompleto(_clientes.Rows[index].Cells[0].Text, Convert.ToInt32(User.PuntoVentaId), Convert.ToInt32(User.SucursalId));
                    _datos.DataSource = _cuentaPorCobrarVistaDtOses;
                    _datos.DataBind();

                }
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBusquedaCliente");
            }
        }
        /// <summary>
        /// carga el  historial de pagos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Historial")

                {
                 
                   _btnHistorialPago_ModalPopupExtender.TargetControlID = "_btnBusquedaCliente";
                    _btnHistorialPago_ModalPopupExtender.Show();
                    int index = Convert.ToInt32(e.CommandArgument);
                    _datosPago.DataSource =
                        _cuentaPorCobrarVistaDtOses.Where(
                            a =>
                                a.CuentaPorCobrar.CuentaPorCobrarId.Equals(
                                    Convert.ToInt32(_datos.Rows[index].Cells[0].Text)))
                            .Select(b => b.HistorialCuentaPorCobrar);
                    _datosPago.DataBind();
                }
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBusquedaCliente");
            }

        }

        /// <summary>
        /// Carga  la informacion
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

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBusquedaCliente");
            }

        }

        /// <summary>
        /// Busca las cuentas por  cobrar por cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnBusquedaCliente_Click(object sender, EventArgs e)
        {
            try
            {

                if (_tipoBusqueda.SelectedItem.Value.ToString() == "1")
                {
                    _cuentaPorCobrarVistaDtOses = _servicioDelegadoContabilidad.ObtenerCuentasPorCobrarCompleto(_numeroDocumentoBusqueda.Text, Convert.ToInt32(User.PuntoVentaId), Convert.ToInt32(User.SucursalId));
                    if (_cuentaPorCobrarVistaDtOses.Count > 0)
                    {
                        _datos.DataSource = _cuentaPorCobrarVistaDtOses;
                        _datos.DataBind();
                    }
                    else
                    {
                        LimpiarControles();
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Informacion_No_existe").ToString(), "_btnBusquedaCliente");
                    }
                }
                
                else
                {
                    listaClienteVistaDtOses = _servicioDelegadoIndividuo.ObtenerClientePorApellidos(_numeroDocumentoBusqueda.Text.ToUpper(), _parametroDos.Text.ToUpper());

                    if (listaClienteVistaDtOses.Count > 0)
                    {
                        _clientes.DataSource = listaClienteVistaDtOses;
                        _clientes.DataBind();
                        _btnCliente_ModalPopupExtender.TargetControlID = "_btnBusquedaCliente";
                        _btnCliente_ModalPopupExtender.Show();
                    }
                    else
                    {
                        LimpiarControles();
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Informacion_No_existe").ToString(), "_grabarCliente");
                    }
                }


                

               





            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBusquedaCliente");
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


        private void CargarDatos()
        {
            try
            {
                _tipoBusqueda.DataSource = _colecciones.ObtenerTipoDocumentos();
                _tipoBusqueda.DataBind();
                _tipoBusqueda.SelectedIndex = _tipoBusqueda.Items.IndexOf(_tipoBusqueda.Items.FindByValue("-1"));
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        private void LimpiarControles()
        {
            try
            {
                _datos.DataSource = null;
                _datos.DataBind();
                _numeroDocumentoBusqueda.Text = String.Empty;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        #endregion

        
    }
}