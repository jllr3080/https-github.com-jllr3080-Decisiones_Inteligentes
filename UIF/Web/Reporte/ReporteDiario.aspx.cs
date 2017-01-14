#region using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Web.Base;
using Web.ServicioDelegado;

#endregion


namespace Web.Reporte.Venta.Reporte
{
    public partial class ReporteDiario : PaginaBase
    {
        #region Declaraciones e Instancias
        private readonly  ServicioDelegadoVenta _servicioDelegadoVenta = new ServicioDelegadoVenta();
        #endregion

        #region Eventos

        /// <summary>
        /// Carga la informacion 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Generar el reporte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _generarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                _reporteDiario.LocalReport.DataSources.Clear();
                string pathreport = Server.MapPath("~/Reporte/Venta/Rdlc/ReporteDiario.rdlc");
                _reporteDiario.LocalReport.ReportPath = pathreport;
                _reporteDiario.LocalReport.DataSources.Add(new ReportDataSource("ObjetoReporteDiario", _servicioDelegadoVenta.ObtenerOrdenTrabajoPorFechaIngresoYPorSucursal(_fecha.Text,Convert.ToInt32(User.PuntoVentaId))));

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion

        #region Metodos

        #endregion
    }
}