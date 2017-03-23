#region  using
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

    public partial class ReporteEstadisticaGeneralPrendas : System.Web.UI.Page
    {

        #region  DECLARACIONES E INSTANCIAS
        private readonly ServicioDelegadoVenta _servicioDelegadoVenta = new ServicioDelegadoVenta();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_generarReporte");
            }
        }

        protected void _generarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                _numeroPrendas.LocalReport.DataSources.Clear();
                string pathreport = Server.MapPath("~/Reporte/Venta/Rdlc/ReporteEstadisticaGeneralPrendas.rdlc");
                _numeroPrendas.LocalReport.ReportPath = pathreport;
                _numeroPrendas.LocalReport.DataSources.Add(new ReportDataSource("NumeroPrenda", _servicioDelegadoVenta.ObtenerNumeroPrendasPorFecha(_fechaDesde.Text, _fechaHasta.Text)));

            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_generarReporte");
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