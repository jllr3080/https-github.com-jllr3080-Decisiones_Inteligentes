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
using Web.ServicioDelegado;

#endregion
namespace Web.Contabilidad
{
    public partial class CuentasPorCobrar : PaginaBase
    {
        #region DECLARACIONES  E INSTANCIAS

        private  readonly  ServicioDelegadoContabilidad _servicioDelegadoContabilidad= new ServicioDelegadoContabilidad();
        private static List<CuentaPorCobrarVistaDTOs> _cuentaPorCobrarVistaDtOses = null;
        #endregion

        #region Eventos
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
                _cuentaPorCobrarVistaDtOses = _servicioDelegadoContabilidad.ObtenerHistorialCuentaPorCobrarPorNumeroidentificacion(_numeroDocumento.Text);

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


        private void LimpiarControles()
        {
            try
            {
                _datos.DataSource = null;
                _datos.DataBind();
                _numeroDocumento.Text = String.Empty;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        #endregion

        
    }
}