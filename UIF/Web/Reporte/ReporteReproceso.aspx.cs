using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Web.Base;
using Web.ServicioDelegado;

namespace Web.Reporte
{
    public partial class ReporteReproceso : PaginaBase
    {

        #region Declaraciones e Instancias
        private readonly  ServicioDelegadoGeneral _servicioDelegadoGeneral= new ServicioDelegadoGeneral();
        private readonly  ServicioDelegadoFlujoProceso _servicioDelegadoFlujoProceso= new ServicioDelegadoFlujoProceso();
        #endregion

        #region Eventos

        /// <summary>
        /// Carga  de  informacion inicial de la pagina
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
                    if (User.NombrePerfil != "ADMINISTRADOR" && User.NombrePerfil != "PLANTA")
                    {
                        _sucursal.SelectedIndex = _sucursal.Items.IndexOf(_sucursal.Items.FindByValue(User.PuntoVentaId.ToString()));
                        _sucursal.Enabled = false;
                    }
                    else
                    {

                        _sucursal.Enabled = true;
                    }

                }
            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_generarReporte");
            }
            
        }

        /// <summary>
        /// GEnera el reporte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _generarReporte_OnClick(object sender, EventArgs e)
        {
            try
            {
                _reproceso.LocalReport.DataSources.Clear();
                string pathreport = Server.MapPath("~/Reporte/FlujoProceso/ReporteReproceso.rdlc");
                _reproceso.LocalReport.ReportPath = pathreport;
                _reproceso.LocalReport.DataSources.Add(new ReportDataSource("ReprocesoDTO", _servicioDelegadoFlujoProceso.ObtenerReprocesoPorVariosParametros(Convert.ToInt32(_sucursal.SelectedItem.Value), _fechaDesde.Text, _fechaHasta.Text)));

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