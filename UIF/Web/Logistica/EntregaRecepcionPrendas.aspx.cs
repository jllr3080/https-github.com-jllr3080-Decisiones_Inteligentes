﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Base;
using Web.DTOs.Logistica;
using Web.DTOs.Seguridad;
using Web.DTOs.Venta;
using Web.Models.FlujoProceso;
using Web.Models.General;

using Web.Models.Venta.Negocio;
using Web.ServicioDelegado;

#endregion

namespace Web.Logistica
{
    public partial class EntregaRecepcionPrendas : PaginaBase
    {

        #region  Declaraciones  e Instancias

        private readonly  ServicioDelegadoVenta _servicioDelegadoVenta= new ServicioDelegadoVenta();
        private readonly  ServicioDelegadoSeguridad _servicioDelegadoSeguridad= new ServicioDelegadoSeguridad();
        private readonly  ServicioDelegadoLogistica _servicioDelegadoLogistica= new ServicioDelegadoLogistica();
        private readonly  ServicioDelegadoFlujoProceso _servicioDelegadoFlujoProceso= new ServicioDelegadoFlujoProceso();
        private readonly  ServicioDelegadoGeneral _servicioDelegadoGeneral= new ServicioDelegadoGeneral();
        private static List<OrdenTrabajoVistaDTOs> _listaOrdenTrabajoVistaDtOses = null;
        private static List<HistorialProcesoVistaModelo> _listaHistorialProcesoVistaModelos = null;

        #endregion

        #region  Eventos
        /// <summary>
        /// Carga  todos los  items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _todos_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {

                foreach (GridViewRow row in _datos.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox _todos = (row.Cells[0].FindControl("_todos") as CheckBox);
                        CheckBox _aceptarEntrega = (row.Cells[0].FindControl("_aceptarEntrega") as CheckBox);
                        if (_todos.Checked == true)
                            _aceptarEntrega.Checked = true;
                        else
                            _aceptarEntrega.Checked = false;



                    }
                }
            }
            catch
                (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Carga la informacion de las prendas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _etapaProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                _listaOrdenTrabajoVistaDtOses = CargarInformacion();


                if (_listaOrdenTrabajoVistaDtOses.Count > 0)
                {

                    List<HerenciaOrdenTrabajoVistaDTOs> _listaHerenciaOrdenTrabajoVistaDtOses =
                        new List<HerenciaOrdenTrabajoVistaDTOs>();
                    foreach (var objetoOrdenTrabajoDtos in _listaOrdenTrabajoVistaDtOses)
                    {
                        HerenciaOrdenTrabajoVistaDTOs _herenciaOrdenTrabajoVista =
                            new HerenciaOrdenTrabajoVistaDTOs();
                        _herenciaOrdenTrabajoVista.OrdenTrabajo = objetoOrdenTrabajoDtos.OrdenTrabajo;
                        _herenciaOrdenTrabajoVista.DetalleOrdenTrabajo = objetoOrdenTrabajoDtos.DetalleOrdenTrabajo;
                        _herenciaOrdenTrabajoVista.NumeroPrenda = Convert.ToInt32(
                            objetoOrdenTrabajoDtos.DetalleOrdenTrabajo.Sum(m => m.Cantidad));
                        _listaHerenciaOrdenTrabajoVistaDtOses.Add(_herenciaOrdenTrabajoVista);

                    }
                    _datos.DataSource = _listaHerenciaOrdenTrabajoVistaDtOses;
                    _datos.DataBind();
                }
                else
                {
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Informacion_No_existe").ToString(), "_grabarEntregaRecepcionPrenda");
                    _grabarEntregaRecepcionPrenda.Enabled = false;
                    _grabarEntregaRecepcionPrenda.CssClass = "btn btn-primary";
                    _listaOrdenTrabajoVistaDtOses = null;
                    _datos.DataSource = null;
                    _datos.DataBind();

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        

        /// <summary>
        /// Guardar la informacion del transporte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnGuardarinformacion_Click(object sender, EventArgs e)
        {
            try
            {

                //DataTable dt = new DataTable();
                //dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Name"), new DataColumn("Country") });
                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    if (row.RowType == DataControlRowType.DataRow)
                //    {
                //        CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                //        if (chkRow.Checked)
                //        {
                //            string name = row.Cells[1].Text;
                //            string country = (row.Cells[2].FindControl("lblCountry") as Label).Text;
                //            dt.Rows.Add(name, country);
                //        }
                //    }
                //}
                //gvSelected.DataSource = dt;
                //gvSelected.DataBind();

                UsuarioVistaDTOs _usuarioVistaDtOs = _servicioDelegadoSeguridad.IngresoSistema(_usuario.Text, _contrasena.Text, 1, 1);
                foreach (GridViewRow row in _datos.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox _aceptarEntrega = (row.Cells[0].FindControl("_aceptarEntrega") as CheckBox);
                        if (_aceptarEntrega.Checked==true)
                        {
                           
                            if (_usuarioVistaDtOs != null)
                            {
                                foreach (var objetoHistorialProceso in _listaHistorialProcesoVistaModelos)
                                {

                                    objetoHistorialProceso.PasoPorEstaEtapa = true;
                                    _servicioDelegadoFlujoProceso.ActualizarHistorialProceso(objetoHistorialProceso);


                                    //Graba en el Historial de Proceso
                                    //GUarda el proceso inicial que es la entrega del cliente hacia  la franquicia
                                    HistorialProcesoVistaModelo _historialProcesoVista = new HistorialProcesoVistaModelo();
                                    _historialProcesoVista.OrdenTrabajoId = objetoHistorialProceso.OrdenTrabajoId;
                                    EtapaProcesoVistaModelo _etapaProcesoVistaModelo = new EtapaProcesoVistaModelo();
                                    _etapaProcesoVistaModelo.EtapaProcesoId = Convert.ToInt32(_etapaProcesoDestino.SelectedItem.Value);
                                    _historialProcesoVista.EtapaProceso = _etapaProcesoVistaModelo;
                                    _historialProcesoVista.OrdenTrabajoId = objetoHistorialProceso.OrdenTrabajoId;
                                    _historialProcesoVista.FechaRegistro = DateTime.Now;
                                    _historialProcesoVista.FechaInicio = DateTime.Now;
                                    _historialProcesoVista.FechaFin = DateTime.Now;
                                    _historialProcesoVista.NumeroOrden = objetoHistorialProceso.NumeroOrden;
                                    _historialProcesoVista.PasoPorEstaEtapa = false;
                                    _historialProcesoVista.SucursalId = User.SucursalId;
                                    _historialProcesoVista.PuntoVentaId = User.PuntoVentaId;
                                    _historialProcesoVista.UsuarioEntregaId = _usuarioVistaDtOs.UsuarioId;
                                    _historialProcesoVista.UsuarioRecibeId = User.Id;
                                    _historialProcesoVista.PerfilId = User.PerfilId;
                                    _servicioDelegadoFlujoProceso.GrabarHistorialProceso(_historialProcesoVista);

                                    ////Actualiza  la orden  de trabajo
                                    //OrdenTrabajoVistaModelo _ordenTrabajoVistaModelo = objetoOrdenTrabajoVista.OrdenTrabajo;
                                    //_ordenTrabajoVistaModelo.SeEnvio = true;
                                    //_servicioDelegadoVenta.ActualizarOrdenTrabajo(_ordenTrabajoVistaModelo);


                                    _datos.DataSource = null;
                                    _datos.DataBind();

                                }



                            }
                            else
                            {
                                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Informacion_No_existe").ToString(), "_grabarEntregaRecepcionPrenda");
                            }

                        }
                    }
                }
               

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarEntregaRecepcionPrenda");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DetalleOrden")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    _btnDetalleOrden_ModalPopupExtender.TargetControlID = "_cancelar";
                    _btnDetalleOrden_ModalPopupExtender.Show();
                    //List<DetalleOrdenTrabajoObservacionVistaModelo> _lisaDetalleOrdenTrabajoObservacion = _servicioDelegadoVenta.ObtenerDetalleOrdenTrabajoObservaciones(Convert.ToInt32(_datos.Rows[index].Cells[0].Text));
                    _datosDetalleOrden.DataSource =
                        _servicioDelegadoVenta.ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(
                            _datos.Rows[index].Cells[1].Text, Convert.ToInt32(User.PuntoVentaId));
                    _datosDetalleOrden.DataBind();
                }
            }
            catch (Exception ex)
            {

            }


        }

        /// <summary>
        /// Graba la entrega de prendas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _grabarEntregaRecepcionPrenda_Click(object sender, EventArgs e)
        {
            try
            {
                _btnSeguridad_ModalPopupExtender.TargetControlID = "_cancelar";
                _btnSeguridad_ModalPopupExtender.Show();
                _usuario.Text= string.Empty;
                _contrasena.Text= string.Empty;
            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarEntregaRecepcionPrenda");
            }
        }

        /// <summary>
        /// Cancela  y regresa  al inicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Inicio/Default.aspx");
            }
            catch (Exception ex)
            {
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarEntregaRecepcionPrenda");
            }
        }

        /// <summary>
        ///  Carga la informacion incial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                if (!IsPostBack)
                {

                    CargarInformacionInicial();
                        _listaOrdenTrabajoVistaDtOses =CargarInformacion();

                }
                
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarEntregaRecepcionPrenda");
            }

        }
        #endregion

        #region Metodos

        private void CargarInformacionInicial()
        {
            try
            {
                _nombrePerfil.Text = User.NombrePerfil;
                EtapaProcesoVistaModelo  etapaProcesoVista= new EtapaProcesoVistaModelo();
                etapaProcesoVista.EtapaProcesoId = -1;
                etapaProcesoVista.Descripcion = "SELECCIONE UNA OPCION";
                List<EtapaProcesoVistaModelo> _listaEtapaProcesoVistaModelos = _servicioDelegadoGeneral.ObtenerEtapasProceso();
                _listaEtapaProcesoVistaModelos.Add(etapaProcesoVista);
                
                _etapaProceso.DataSource = _listaEtapaProcesoVistaModelos;
                _etapaProceso.DataBind();
                _etapaProceso.SelectedIndex = _etapaProceso.Items.IndexOf(_etapaProceso.Items.FindByValue("-1"));
                
                _etapaProcesoDestino.DataSource = _listaEtapaProcesoVistaModelos;
                _etapaProcesoDestino.DataBind();
                _etapaProcesoDestino.SelectedIndex = _etapaProcesoDestino.Items.IndexOf(_etapaProcesoDestino.Items.FindByValue("-1"));
            }
            catch (Exception ex)
            {
            }
        }


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


        private List<OrdenTrabajoVistaDTOs> CargarInformacion()
        {
            try
            {
                 _listaHistorialProcesoVistaModelos =
                    _servicioDelegadoFlujoProceso.ObtenerHistorialProcesoPorFlujoProceso(
                        Convert.ToInt32(_etapaProceso.SelectedItem.Value), Convert.ToInt32(User.SucursalId),
                        Convert.ToInt32(User.PuntoVentaId));

                 _listaOrdenTrabajoVistaDtOses=new List<OrdenTrabajoVistaDTOs>();

                foreach (var objetoHistoriaProceso in _listaHistorialProcesoVistaModelos)
                {
                    OrdenTrabajoVistaDTOs _ordenTrabajoVistaDtOs =
                        _servicioDelegadoVenta.ObtenerOrdenTrabajoPorOrdenTrabajoId(
                            Convert.ToInt32(objetoHistoriaProceso.OrdenTrabajoId));

                    _listaOrdenTrabajoVistaDtOses.Add(_ordenTrabajoVistaDtOs);
                }
                return _listaOrdenTrabajoVistaDtOses; 
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }



        #endregion


       
    }
}