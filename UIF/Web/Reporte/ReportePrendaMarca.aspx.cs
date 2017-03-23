#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Web.Base;
using Web.DTOs.Venta;
using Web.ServicioDelegado;

#endregion

namespace Web.Reporte
{
    public partial class ReportePrendaMarca : PaginaBase
    {

        #region Declaracion e instancias
        private readonly ServicioDelegadoVenta _servicioDelegadoVenta = new ServicioDelegadoVenta();
        private readonly ServicioDelegadoGeneral _servicioDelegadoGeneral = new ServicioDelegadoGeneral();
        private readonly ServicioDelegadoInventario  _servicioDelegadoInventario = new ServicioDelegadoInventario();
        #endregion

        #region Eventos

        /// <summary>
        /// Carga los  datos iniciales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    CargaDatos();
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_generarReporte");
            }

        }
        /// <summary>
        /// Genera el reporte 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _generarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                List<PrendaMarcaVistaDTOs> _lista = _servicioDelegadoVenta.ObtenerPrendayMarcaPorVariosParametros(Convert.ToInt32(_prenda.SelectedItem.Value),Convert.ToInt32(_marca.SelectedItem.Value),_fechaDesde.Text);

                if (_lista.Count > 0)
                    CargaInformacionReporte(_lista);
                else
                {
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Informacion_No_existe").ToString(), "_generarReporte");
                    _reportePrendaMarca.LocalReport.DataSources.Clear();
                }
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


        /// <summary>
        /// Carga  los datos inciiales
        /// </summary>
        private void CargaDatos()
        {
            try
            {
                _prenda.DataSource =
                    _servicioDelegadoInventario.ObtenerProductoPorTipoProductoId(
                        Convert.ToInt32(Util.TipoProducto.Servicio));
                _prenda.DataBind();
                _marca.DataSource = _servicioDelegadoGeneral.ObtenerMarcas();
                _marca.DataBind();
                _fechaDesde.Text = DateTime.Now.ToShortDateString();
                
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_generarReporte");
            }
        }
        /// <summary>
        /// Carga la informacion  del reporte
        /// </summary>
        private void CargaInformacionReporte(List<PrendaMarcaVistaDTOs>  prendaMarcaVista)
        {
            try
            {
                _reportePrendaMarca.LocalReport.DataSources.Clear();
                string pathreport = Server.MapPath("~/Reporte/Venta/Rdlc/ReportePrendaMarca.rdlc");
                _reportePrendaMarca.LocalReport.ReportPath = pathreport;
                _reportePrendaMarca.LocalReport.DataSources.Add(new ReportDataSource("PrendaMarca", prendaMarcaVista));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


    }
}