#region using
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Base;
using Web.DTOs.Contabilidad;
using Web.DTOs.FlujoProceso;
using Web.DTOs.Venta;
using Web.Models.FlujoProceso;
using Web.Models.General;
using Web.Models.Venta.Negocio;
using Web.ServicioDelegado;

#endregion

namespace Web.Venta
{
    public partial class ConsultaOrdenPlanta : PaginaBase
    {

        #region DECLARACIONES  E INSTANCIAS
        private readonly ServicioDelegadoVenta _servicioDelegadoVenta = new ServicioDelegadoVenta();
        private readonly ServicioDelegadoGeneral _servicioDelegadoGeneral = new ServicioDelegadoGeneral();
        private static List<ConsultaOrdenTrabajoVistaDTOs> _listaConsultaOrdenTrabajoVistaDtOses = null;
        private static List<DetalleOrdenTrabajoVistaModelo> _listaDetalleOrdenTrabajoVistaModelos = null;
        private static List<DetalleOrdenTrabajoFotografiaVistaDTOs> _listaDetalleOrdenTrabajoFotografiaVistaDtOses = null;
        private readonly ServicioDelegadoFlujoProceso _servicioDelegadoFlujoProceso = new ServicioDelegadoFlujoProceso();
        #endregion

        #region Eventos

        /// <summary>
        /// Graba la prenda a eprocesar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _botonGrabarReproceso_OnClick(object sender, EventArgs e)
        {
            try
            {
                HistorialReprocesoVistaDTOs _historialReprocesoVistaDtOs = new HistorialReprocesoVistaDTOs();

                HistorialProcesoVistaModelo _historialProcesoVista = new HistorialProcesoVistaModelo();
                //GUarda el proceso inicial que es la entrega del cliente hacia  la franquicia
                _historialProcesoVista.OrdenTrabajoId = _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.OrdenTrabajoId).First();
                EtapaProcesoVistaModelo _etapaProcesoVistaModelo = new EtapaProcesoVistaModelo();
                _etapaProcesoVistaModelo.EtapaProcesoId = Convert.ToInt32(Util.EtapaProceso.EntregaClienteHaciaFranquicia);
                _historialProcesoVista.EtapaProceso = _etapaProcesoVistaModelo;
                _historialProcesoVista.FechaRegistro = DateTime.Now;
                _historialProcesoVista.FechaInicio = DateTime.Now;
                _historialProcesoVista.FechaFin = DateTime.Now;
                _historialProcesoVista.SucursalId = User.SucursalId;
                _historialProcesoVista.PuntoVentaId = User.PuntoVentaId;
                _historialProcesoVista.NumeroOrden = _listaConsultaOrdenTrabajoVistaDtOses.Select(m => m.NumeroOrden).First().ToString();
                HistorialProcesoVistaModelo historialProcesoVistaModelo = _servicioDelegadoFlujoProceso.GrabarHistorialProceso(_historialProcesoVista);

                HistorialReprocesoVistaModelo historialReprocesoVista = new HistorialReprocesoVistaModelo();
                historialReprocesoVista.HistorialProceso = historialProcesoVistaModelo;
                historialReprocesoVista.DetallePrendaOrdenTrabajoId = Convert.ToInt32(_detallePrendaOrdenTrabajoId.Value);


                historialReprocesoVista = _servicioDelegadoFlujoProceso.GrabarHistorialReproceso(historialReprocesoVista);


                DetalleHistorialReprocesoVistaModelo detalleHistorialReproceso = new DetalleHistorialReprocesoVistaModelo();
                detalleHistorialReproceso.HistorialReproceso = historialReprocesoVista;
                detalleHistorialReproceso.Motivo = _motivo.Text.ToUpper();
                TipoReprocesoVistaModelo _tipoReproceso = new TipoReprocesoVistaModelo();
                _tipoReproceso.TipoReprocesoId = Convert.ToInt32(_tipoMotivoReproceso.SelectedItem.Value);
                detalleHistorialReproceso.TipoReproceso = _tipoReproceso;
                _servicioDelegadoFlujoProceso.GrabarDetalleHistorialReproceso(detalleHistorialReproceso);

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }
        /// <summary>
        /// Metodo para visualizar la  imagen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datosFotografia_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                if (e.CommandName == "VerFotografia")
                {
                    int index = Convert.ToInt32(e.CommandArgument);

                    DetalleOrdenTrabajoFotografiaVistaModelo imagenindividua =
                        _listaDetalleOrdenTrabajoFotografiaVistaDtOses.Where(
                            a =>
                                a.DetalleOrdenTrabajoFotografia.DetalleOrdenTrabajoFotografiaId.Equals(
                                    Convert.ToInt32(_datosFotografia.Rows[index].Cells[0].Text)))
                            .Select(a => a.DetalleOrdenTrabajoFotografia).FirstOrDefault();
                    Session["Registro"] = imagenindividua;
                    _btnVisualizar_ModalPopupExtender.TargetControlID = "_btnBuscar";
                    _btnVisualizar_ModalPopupExtender.Show();


                }
            }
            catch (ThreadAbortException ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }

        /// <summary>
        /// Agrega las fotografias 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnAgregarDireccionFotografia_OnClick(object sender, EventArgs e)
        {
            try
            {


                if (_direccionFotografia.FileBytes.Length <= 1048576)
                {
                    if (_direccionFotografia.HasFile)

                    {
                        bool extensionValida = false;
                        string extension = System.IO.Path.GetExtension(_direccionFotografia.FileName).ToLower();
                        String[] allowedExtensions = { ".png", ".jpeg", ".jpg" };
                        for (int i = 0; i < allowedExtensions.Length; i++)
                        {
                            if (extension == allowedExtensions[i])
                            {
                                extensionValida = true;
                            }
                        }

                        if (extensionValida)
                        {
                            using (BinaryReader reader = new BinaryReader(_direccionFotografia.PostedFile.InputStream))
                            {

                                //System.Drawing.Image imagen = System.Drawing.Image.FromStream(_direccionFotografia.PostedFile.InputStream);
                                //Bitmap bmp1 = new Bitmap(imagen);

                                //ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                                //// Create an Encoder object based on the GUID
                                //// for the Quality parameter category.
                                //System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

                                //// Create an EncoderParameters object.
                                //// An EncoderParameters object has an array of EncoderParameter
                                //// objects. In this case, there is only one
                                //// EncoderParameter object in the array.
                                //EncoderParameters myEncoderParameters = new EncoderParameters(1);
                                //EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50); //0 el máximo de compresión y 100 el mínimo

                                //myEncoderParameters.Param[0] = myEncoderParameter;

                                //bmp1.Save(Path.Combine("C:\\Prueba\\", "prueba.Jpeg"), jpgEncoder, myEncoderParameters);
                                byte[] image = reader.ReadBytes(_direccionFotografia.PostedFile.ContentLength);
                                DetalleOrdenTrabajoFotografiaVistaModelo _detalleOrdenTrabajoFotografiaVistaModelo =
                                    new DetalleOrdenTrabajoFotografiaVistaModelo();
                                DetallePrendaOrdenTrabajoVistaModelo _detallePrendaOrdenTrabajo =
                                    new DetallePrendaOrdenTrabajoVistaModelo();
                                _detallePrendaOrdenTrabajo.DetallePrendaOrdenTrabajoId =
                                    Convert.ToInt32(_detallePrendaId.Value);
                                _detalleOrdenTrabajoFotografiaVistaModelo.DetallePrendaOrdenTrabajo =
                                    _detallePrendaOrdenTrabajo;
                                _detalleOrdenTrabajoFotografiaVistaModelo.FechaRegistro = DateTime.Now;
                                _detalleOrdenTrabajoFotografiaVistaModelo.UsuarioId = User.Id;

                                _detalleOrdenTrabajoFotografiaVistaModelo.ImagenPrenda = image;
                                _servicioDelegadoVenta.GrabarDetalleOrdenFotografia(
                                    _detalleOrdenTrabajoFotografiaVistaModelo);






                            }
                        }
                        else
                        {
                            Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Formato_No_Valido").ToString(), "_btnBuscar");
                        }



                    }
                    else
                    {
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Imagen_No_Cargada").ToString(), "_btnBuscar");
                    }

                }
                else
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Tamano_No_Valido").ToString(), "_btnBuscar");
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }
        /// <summary>
        /// Agrega las  observaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnAceptarObservaciones_Click(object sender, EventArgs e)
        {
            try
            {
                DetalleOrdenTrabajoObservacionVistaModelo _detalleOrdenTrabajoObservacion = new DetalleOrdenTrabajoObservacionVistaModelo();
                _detalleOrdenTrabajoObservacion.UsuarioId = User.Id;
                _detalleOrdenTrabajoObservacion.DetalleOrdenTrabajoId = Convert.ToInt32(_detalleOrdenTrabajoId.Value);
                _detalleOrdenTrabajoObservacion.FechaCreacionObservacion = DateTime.Now;
                _detalleOrdenTrabajoObservacion.Observacion = _observacion.Text.ToUpper();
                _servicioDelegadoVenta.GrabarDetalleOrdenTrabajoObservacion(_detalleOrdenTrabajoObservacion);
                _observacion.Text = String.Empty;

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }


        /// <summary>
        /// Carga  los totales de las prendas  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private decimal _montoTotal = 0;
        private int _cantidadTotal = 0;
        protected void _datos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //_montoTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ValorTotal"));
                    //_cantidadTotal += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Cantidad"));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Totales:";
                    e.Row.Cells[1].Text = _listaDetalleOrdenTrabajoVistaModelos.Sum(a=>a.Cantidad).ToString();
                    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;

                    e.Row.Cells[6].Text = _listaDetalleOrdenTrabajoVistaModelos.Sum(a => a.ValorTotal).ToString();
                    e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Font.Bold = true;
                }
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }
        

        /// <summary>
        /// Carga los datos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Observacion")

                {
                    _observacion.Text = String.Empty;
                    _btnObservaciones_ModalPopupExtender.TargetControlID = "_btnBuscar";
                    _btnObservaciones_ModalPopupExtender.Show();
                    int index = Convert.ToInt32(e.CommandArgument);
                    List<DetalleOrdenTrabajoObservacionVistaDTOs> _lisaDetalleOrdenTrabajoObservacion = _servicioDelegadoVenta.ObtenerDetalleOrdenTrabajoObservacionPorDetalleOrdenTrabajoId(Convert.ToInt32(_datos.Rows[index].Cells[0].Text));
                    if (_lisaDetalleOrdenTrabajoObservacion.Count > 0)
                    {
                        _datosObservaciones.DataSource = _lisaDetalleOrdenTrabajoObservacion;
                        _datosObservaciones.DataBind();
                    }

                    //int ordenCerrada = Convert.ToInt32(_listaHistorialProcesoVistaModelos.Where(a => a.EtapaProceso.EtapaProcesoId.Equals(Convert.ToInt32(Util.EtapaProceso.EntregaFranquiciaHaciaCliente))).Select(b => b.EtapaProceso.EtapaProcesoId).FirstOrDefault().ToString());
                    //int ordenAnulada = Convert.ToInt32(_listaHistorialProcesoVistaModelos.Where(a => a.EtapaProceso.EtapaProcesoId.Equals(Convert.ToInt32(Util.EtapaProceso.AnulacionOrdenTrabajo))).Select(b => b.EtapaProceso.EtapaProcesoId).FirstOrDefault().ToString());

                    //if (ordenCerrada == Convert.ToInt32(Util.EtapaProceso.EntregaFranquiciaHaciaCliente) ||
                    //    ordenAnulada == Convert.ToInt32(Util.EtapaProceso.AnulacionOrdenTrabajo))
                    //{

                    //    _observacion.ReadOnly = true;
                    //    _btnAceptaAnulacionOrden.Enabled = false;
                    //    _btnAceptaAnulacionOrden.CssClass = "btn btn-primary";
                    //}
                    //else
                    //{

                    //    _observacion.ReadOnly = false;
                    //    _btnAceptaAnulacionOrden.Enabled = true;
                    //    _detalleOrdenTrabajoId.Value = _datos.Rows[index].Cells[0].Text;
                    //}


                }
                if (e.CommandName == "Fotografia")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    _btnAgregarFotografia_ModalPopupExtender.TargetControlID = "_btnBuscar";
                    _btnAgregarFotografia_ModalPopupExtender.Show();
                    _detallePrendaId.Value = _datos.Rows[index].Cells[0].Text;
                    _listaDetalleOrdenTrabajoFotografiaVistaDtOses = _servicioDelegadoVenta.ObtenerDetalleOrdenTrabajoFotografiaDtOsesPorDetallePrendaId(
                            Convert.ToInt32(_detallePrendaId.Value));
                    _datosFotografia.DataSource = _listaDetalleOrdenTrabajoFotografiaVistaDtOses;
                    _datosFotografia.DataBind();
                }
                if (e.CommandName == "Reproceso")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    //int ordenCerrada = Convert.ToInt32(_listaHistorialProcesoVistaModelos.Where(a => a.EtapaProceso.EtapaProcesoId.Equals(Convert.ToInt32(Util.EtapaProceso.EntregaFranquiciaHaciaCliente))).Select(b => b.EtapaProceso.EtapaProcesoId).FirstOrDefault().ToString());
                    //int ordenAnulada = Convert.ToInt32(_listaHistorialProcesoVistaModelos.Where(a => a.EtapaProceso.EtapaProcesoId.Equals(Convert.ToInt32(Util.EtapaProceso.AnulacionOrdenTrabajo))).Select(b => b.EtapaProceso.EtapaProcesoId).FirstOrDefault().ToString());

                    //if (ordenCerrada == Convert.ToInt32(Util.EtapaProceso.EntregaFranquiciaHaciaCliente) || ordenAnulada == Convert.ToInt32(Util.EtapaProceso.AnulacionOrdenTrabajo))
                    //    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Orden_Cerrada").ToString(), "_btnBuscar");
                    //else
                    //{

                        _tipoMotivoReproceso.DataSource = _servicioDelegadoGeneral.ObtenerTipoReprocesos();
                        _tipoMotivoReproceso.DataBind();
                        _detallePrendaOrdenTrabajoId.Value = _datos.Rows[index].Cells[0].Text;
                        List<DetalleHistorialReprocesoVistaDTOs> lisaDetalleHistorialReprocesoVistaDtOses = _servicioDelegadoFlujoProceso.ObtenerDetalleHistorialReprocesosPorDetalleOrdenTrabajoId(Convert.ToInt32(_datos.Rows[index].Cells[0].Text));
                        _datosReproceso.DataSource = lisaDetalleHistorialReprocesoVistaDtOses;
                        _datosReproceso.DataBind();
                    _motivo.Text = String.Empty;
                    _botonReproceso_ModalPopupExtender.TargetControlID = "_btnBuscar";
                        _botonReproceso_ModalPopupExtender.Show();
                    
                    // }
                }


            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }

        /// <summary>
        /// Carga los  datos  de la pagina
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

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }

        /// <summary>
        /// Busca la información de la orden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarControles();
                _listaConsultaOrdenTrabajoVistaDtOses = _servicioDelegadoVenta.ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(_numeroOrden.Text,Convert.ToInt32(_sucursal.SelectedItem.Value));
                 _listaDetalleOrdenTrabajoVistaModelos = _servicioDelegadoVenta.ObtenerDetalleOrdenTrabajoPorNumeroOrdenYPuntoVenta(_numeroOrden.Text, Convert.ToInt32(_sucursal.SelectedItem.Value));

                if (_listaConsultaOrdenTrabajoVistaDtOses.Count() > 0 && _listaDetalleOrdenTrabajoVistaModelos.Count>0 )
                {
                    _datos.DataSource = _listaConsultaOrdenTrabajoVistaDtOses;
                    _datos.DataBind();
                   
                }
                else
                {
                    LimpiarControles();
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Orden_Trabajo_No_Existe").ToString(), "_btnBuscar");
                }
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
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
        /// Limpia  los controles  de la pantalla
        /// </summary>
        private void LimpiarControles()
        {
            _datos.DataSource = null;
            _datos.DataBind();
        }



        #endregion

        
    }
}