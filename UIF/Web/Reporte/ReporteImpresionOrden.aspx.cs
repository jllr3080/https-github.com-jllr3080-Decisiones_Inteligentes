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
using Web.Models.Venta.Negocio;
using Web.ServicioDelegado;

#endregion
namespace Web.Reporte
{

    
    public partial class ReporteImpresionOrden : PaginaBase
    {

        #region Declaraciones e Instancias
        private readonly ServicioDelegadoVenta _servicioDelegadoVenta = new ServicioDelegadoVenta();
        #endregion

        #region Eventos

        /// <summary>
        /// Carga la informacion del reporte
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
                
                throw;
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
                List<ConsultaOrdenTrabajoVistaDTOs> _listaConsultaOrdenTrabajoVistaDtOses = _servicioDelegadoVenta.ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(_numeroOrden.Text,
                    Convert.ToInt32(User.PuntoVentaId));
                List<DetalleOrdenTrabajoVistaModelo> _listaDetalleOrdenTrabajoVistaModelos =
                    _servicioDelegadoVenta.ObtenerDetalleOrdenTrabajoPorNumeroOrdenYPuntoVenta(_numeroOrden.Text,
                        Convert.ToInt32(User.PuntoVentaId));

                if (_listaConsultaOrdenTrabajoVistaDtOses.Count > 0 && _listaDetalleOrdenTrabajoVistaModelos.Count>0)
                {
                    CargaInformacion(_listaConsultaOrdenTrabajoVistaDtOses, _listaDetalleOrdenTrabajoVistaModelos);
                }
                else
                {
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Informacion_No_existe").ToString(), "_generarReporte");
                    _impresion.LocalReport.DataSources.Clear();
                }
                


            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
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


        private void CargaInformacion( List<ConsultaOrdenTrabajoVistaDTOs>  consultaOrdenTrababajo, List<DetalleOrdenTrabajoVistaModelo> detalleOrdenTrabajoVista )
        {
            try
            {
                _impresion.LocalReport.DataSources.Clear();
                string pathreport = Server.MapPath("~/Reporte/Venta/Rdlc/ReporteOrdenTrabajo.rdlc");
                _impresion.LocalReport.ReportPath = pathreport;
                _impresion.LocalReport.DataSources.Add(new ReportDataSource("DetalleOrden", consultaOrdenTrababajo));
                _impresion.LocalReport.DataSources.Add(new ReportDataSource("DetalleValores", detalleOrdenTrabajoVista));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        #endregion
    }
}