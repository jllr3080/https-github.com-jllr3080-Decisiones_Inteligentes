#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Web.ServicioDelegado;

#endregion

namespace Web.Reporte
{
    public partial class ReporteEstadoCuenta : System.Web.UI.Page
    {
        #region  DECLARACIONES  E INSTANCIAS
        private readonly   ServicioDelegadoGeneral _servicioDelegadoGeneral= new ServicioDelegadoGeneral();
        private readonly  ServicioDelegadoVenta _servicioDelegadoVenta= new ServicioDelegadoVenta();
        #endregion

        #region Eventos


        /// <summary>
        /// Genera el reporte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _generarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                _estadoCuenta.LocalReport.DataSources.Clear();
                string pathreport = Server.MapPath("~/Reporte/Venta/Rdlc/ReporteEstadoCuenta.rdlc");
                _estadoCuenta.LocalReport.ReportPath = pathreport;
                _estadoCuenta.LocalReport.DataSources.Add(new ReportDataSource("EstadoCuenta", _servicioDelegadoVenta.ObtenerEstadoCuentaPorVariosParametros(Convert.ToInt32(_sucursal.SelectedItem.Value), _fechaDesde.Text,_fechaHasta.Text)));

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_generarReporte");
            }

        }
        /// <summary>
        /// carga la  informacion inicial de la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    _sucursal.DataSource =
                        _servicioDelegadoGeneral.ObtenerPuntosVentaPorSucursalId(Convert.ToInt32(Util.Sucursal.Quito));
                    _sucursal.DataBind();
                }
            }
            catch (Exception)
            {
                
                throw;
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