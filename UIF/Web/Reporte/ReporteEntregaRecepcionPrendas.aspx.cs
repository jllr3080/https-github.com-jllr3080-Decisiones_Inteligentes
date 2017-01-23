#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Web.DTOs.FlujoProceso;
using Web.ServicioDelegado;

#endregion
namespace Web.Reporte
{
    public partial class ReporteEntregaRecepcionPrendas : System.Web.UI.Page
    {
        #region Declaraciones e Intancias
        private readonly  ServicioDelegadoGeneral _servicioDelegadoGeneral= new ServicioDelegadoGeneral();
        private readonly  ServicioDelegadoFlujoProceso _servicioDelegadoFlujoProceso= new ServicioDelegadoFlujoProceso();

        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                _etapaProceso.DataSource = _servicioDelegadoGeneral.ObtenerEtapasProceso();
                _etapaProceso.DataBind();
                _sucursal.DataSource = _servicioDelegadoGeneral.ObtenerPuntosVentaPorSucursalId(Convert.ToInt32(Util.Sucursal.Quito));
                _sucursal.DataBind();
            }
        }

        protected void _generarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                List<HistorialProcesoVistaDTOs> _listahiHistorialProcesoVistaDtOses =
                    _servicioDelegadoFlujoProceso.ObtenerHistorialProcesoPrendasPorVariosParametros(
                        Convert.ToInt32(Util.Sucursal.Quito), Convert.ToInt32(_sucursal.SelectedItem.Value),
                        _fecha.Text, Convert.ToInt32(_etapaProceso.SelectedItem.Value));
                if (_listahiHistorialProcesoVistaDtOses.Count > 0)
                {
                    _reporteEntregaRecepcionPrendas.LocalReport.DataSources.Clear();
                    string pathreport = Server.MapPath("~/Reporte/FlujoProceso/ReporteEntregaRecepcioPrendas.rdlc");
                    _reporteEntregaRecepcionPrendas.LocalReport.ReportPath = pathreport;
                    _reporteEntregaRecepcionPrendas.LocalReport.DataSources.Add(new ReportDataSource("ObjetoEntregaRecepcionPrendas", _listahiHistorialProcesoVistaDtOses));

                }
                else
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Informacion_No_existe").ToString(),
                        "_generarReporte");
            }
            catch (Exception ex)
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