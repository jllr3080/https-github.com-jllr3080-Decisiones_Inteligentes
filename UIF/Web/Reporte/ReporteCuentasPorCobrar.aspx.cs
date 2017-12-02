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

namespace Web.Reporte
{
    public partial class ReporteCuentasPorCobrar : PaginaBase
    {
        #region   Declaraciones e Instancias
        private readonly ServicioDelegadoContabilidad _servicioDelegadoContabilidad = new ServicioDelegadoContabilidad();
        private readonly ServicioDelegadoGeneral _servicioDelegadoGeneral = new ServicioDelegadoGeneral();
        #endregion

        #region  Eventos

        /// <summary>
        /// Carga la informacion  basica de l;a pagina
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
                    if (User.NombrePerfil != "ADMINISTRADOR")
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
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Genera el reporte 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void _btnBusqueda_Click(object sender, EventArgs e)
        {
            try
            {
                _reporte.LocalReport.DataSources.Clear();
                string pathreport = Server.MapPath("~/Reporte/Contabilidad/ReporteCuentaPorCobrar.rdlc");
                _reporte.LocalReport.ReportPath = pathreport;
                _reporte.LocalReport.DataSources.Add(new ReportDataSource("CuentaPorCobrar", _servicioDelegadoContabilidad.ObtenerCuentasPorCobrarPorFechas(Convert.ToInt32(User.SucursalId), _fechaDesde.Text, _fechaHasta.Text,Convert.ToInt32(User.PuntoVentaId) )));
            }
            catch (Exception ex)
            {

                throw;
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