#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Web.Base;
using Web.DTOs.Venta;
using Web.Models.Venta.Negocio;
using Web.ServicioDelegado;

#endregion

namespace Web.Reporte
{
    public partial class ReporteImpresionOrdenPlanta : PaginaBase
    {

        #region Declaraciones  e instancias
        private readonly ServicioDelegadoVenta _servicioDelegadoVenta = new ServicioDelegadoVenta();
        private readonly ServicioDelegadoGeneral _servicioDelegadoGeneral = new ServicioDelegadoGeneral();
        #endregion

        #region Eventos

        /// <summary>
        /// Carga los  datos  iniciales
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
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_generarReporte");
            }
        }

        /// <summary>
        /// Carga la informacion del reporte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _generarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                 List<ConsultaOrdenTrabajoVistaDTOs> _listaConsultaOrdenTrabajoVistaDtOses = _servicioDelegadoVenta.ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(_numeroOrden.Text,
                    Convert.ToInt32(_sucursal.SelectedItem.Value));
                List<DetalleOrdenTrabajoVistaModelo> _lisaDetalleOrdenTrabajoVistaModelos =
                    _servicioDelegadoVenta.ObtenerDetalleOrdenTrabajoPorNumeroOrdenYPuntoVenta(_numeroOrden.Text,
                        Convert.ToInt32(_sucursal.SelectedItem.Value));

                if (_listaConsultaOrdenTrabajoVistaDtOses.Count > 0 && _lisaDetalleOrdenTrabajoVistaModelos.Count>0)
                    CargaInformacionReporte(_listaConsultaOrdenTrabajoVistaDtOses, _lisaDetalleOrdenTrabajoVistaModelos);
                else
                {
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Informacion_No_existe").ToString(), "_generarReporte");
                    _reporteImpresionOrdenPlanta.LocalReport.DataSources.Clear();
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
        /// Carga la informacion  del reporte
        /// </summary>
        private void CargaInformacionReporte(List<ConsultaOrdenTrabajoVistaDTOs> _listaConsultaOrdenTrabajoVistaDtOses, List<DetalleOrdenTrabajoVistaModelo> detalleOrdenTrabajoVista )
        {
            try
            {
                _reporteImpresionOrdenPlanta.LocalReport.DataSources.Clear();
                string pathreport = Server.MapPath("~/Reporte/Venta/Rdlc/ReporteImpresionOrdenPlanta.rdlc");
                _reporteImpresionOrdenPlanta.LocalReport.ReportPath = pathreport;
                _reporteImpresionOrdenPlanta.LocalReport.DataSources.Add(new ReportDataSource("DetalleOrden", _listaConsultaOrdenTrabajoVistaDtOses));
                _reporteImpresionOrdenPlanta.LocalReport.DataSources.Add(new ReportDataSource("DetalleValores", detalleOrdenTrabajoVista));
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        #endregion
    }
}