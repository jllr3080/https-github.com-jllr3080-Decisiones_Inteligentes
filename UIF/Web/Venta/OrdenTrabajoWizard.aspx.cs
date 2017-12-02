#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Inventario;
using Web.Base;
using Web.DTOs.Individuo;
using Web.DTOs.ReglaNegocio;
using Web.DTOs.Venta;
using Web.Models.General;
using Web.Models.Individuo;

using Web.Models.Seguridad.Negocio;
using Web.Models.Venta.Negocio;
using Web.Models.Venta.Parametrizacion;
using Web.ServicioDelegado;
using Web.Util;

#endregion
namespace Web.Venta
{
	public partial class OrdenTrabajoWizard : PaginaBase
	{
        #region Declaraciones  e Instancias
        private readonly ServicioDelegadoIndividuo _servicioDelegadoIndividuo = new ServicioDelegadoIndividuo();
        private readonly ServicioDelegadoInventario _servicioDelegadoInventario = new ServicioDelegadoInventario();
        private readonly ServicioDelegadoVenta _servicioDelegadoVenta = new ServicioDelegadoVenta();
        private readonly ServicioDelegadoGeneral _servicioDelegadoGeneral = new ServicioDelegadoGeneral();
        private static OrdenTrabajoVistaDTOs _ordenTrabajoVistaDtOs = new OrdenTrabajoVistaDTOs();
        private static ClienteVistaDTOs clienteVistaDtOs = new ClienteVistaDTOs();
        private static List<ClienteVistaDTOs> listaClienteVistaDtOses = new List<ClienteVistaDTOs>();
        private static List<DetalleOrdenTrabajoVistaModelo> _listaTrabajoVistaDtOs = new List<DetalleOrdenTrabajoVistaModelo>();
        private readonly ServicioDelegadoReglaNegocio _servicioDelegadoReglaNegocio = new ServicioDelegadoReglaNegocio();
        private static List<ProductoVistaModelo> _productoVista = null;
        private readonly Util.Colecciones _colecciones = new Colecciones();
        #endregion



        #region Eventos

        /// <summary>
        /// Elimina 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _detalleCuotas_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "Eliminar")
                {
                    _nombreMarca.Value = _datos.Rows[index].Cells[0].Text;
                    DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVista = _listaTrabajoVistaDtOs.Find(m => m.Producto.Nombre == _nombreMarca.Value.ToString());
                    _detalleOrdenTrabajoVista.DetallePrendaOrdenTrabajo.RemoveAt(index);
                    CargarDetalleOrdenTrabajo();

                }

            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_emisionPrenda");
            }
         
        }

        /// <summary>
        /// Graba el  detalle de la prenda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _grabarDetalle_OnClick(object sender, EventArgs e)
        {
            try
            {

                //if (_detalleOrdenTrabajoVista.DetallePrendaOrdenTrabajo.Find())
                List<DetalleOrdenTrabajoObservacionVistaModelo> _listaDetalleOrdenTrabajoObservacion = new List<DetalleOrdenTrabajoObservacionVistaModelo>();
                DetalleOrdenTrabajoObservacionVistaModelo _detalleOrdenTrabajoObservacion = new DetalleOrdenTrabajoObservacionVistaModelo();
                _detalleOrdenTrabajoObservacion.UsuarioId = User.Id;
                _detalleOrdenTrabajoObservacion.FechaCreacionObservacion = DateTime.Now;
                _detalleOrdenTrabajoObservacion.Observacion = _observacion.Text;
                _listaDetalleOrdenTrabajoObservacion.Add(_detalleOrdenTrabajoObservacion);

                DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVista = _listaTrabajoVistaDtOs.Find(m => m.Producto.Nombre == _nombreMarca.Value.ToString());
                DetallePrendaOrdenTrabajoVistaModelo _detallePrendaOrdenTrabajo = new DetallePrendaOrdenTrabajoVistaModelo();
                _detallePrendaOrdenTrabajo.ColorId = Convert.ToInt32(_colorDetalle.SelectedItem.Value);
                _detallePrendaOrdenTrabajo.MarcaId = Convert.ToInt32(_marcaDetalle.SelectedItem.Value);
                _detallePrendaOrdenTrabajo.EstadoPrenda = _estadoPrendaDetalle.Text.ToUpper();
                _detallePrendaOrdenTrabajo.InformacionVisual = _informacionVisualDetalle.Text.ToUpper();
                _detallePrendaOrdenTrabajo.TratamientoEspecial = _tratamientoEspecialDetalle.Text.ToUpper();
                _detallePrendaOrdenTrabajo.NombreMarca = _marcaDetalle.SelectedItem.Text.ToUpper();
                _detallePrendaOrdenTrabajo.NombreColor = _colorDetalle.SelectedItem.Text.ToUpper();
                _detallePrendaOrdenTrabajo.DetalleOrdenTrabajoObservacion = _listaDetalleOrdenTrabajoObservacion;

                if (_detalleOrdenTrabajoVista.DetallePrendaOrdenTrabajo == null)
                {
                    _detalleOrdenTrabajoVista.DetallePrendaOrdenTrabajo =
                        new List<DetallePrendaOrdenTrabajoVistaModelo>();
                    _detalleOrdenTrabajoVista.DetallePrendaOrdenTrabajo.Add(_detallePrendaOrdenTrabajo);
                }
                else
                {
                    _detalleOrdenTrabajoVista.DetallePrendaOrdenTrabajo.Add(_detallePrendaOrdenTrabajo);
                }
                CargarDetalleOrdenTrabajo();



            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_emisionPrenda");
            }
        }


        /// <summary>
        /// Graba la orden de trabajo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _emisionPrenda_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            try
            {
                if (_ordenTrabajoVistaDtOs.DetalleOrdenTrabajo.Count <= 20)
                {
                    if (_valorPago.Text == String.Empty)
                        _valorPago.Text = "0";

                    if (_listaTrabajoVistaDtOs.Sum(m => m.ValorTotal) >= Convert.ToDecimal(_valorPago.Text))
                    {
                        //if (ValidacionNumeroPrendas(_ordenTrabajoVistaDtOs.DetalleOrdenTrabajo) == true )
                        //{

                            EstadoPagoVistaModelo _estadoPagoVista = new EstadoPagoVistaModelo
                            {
                                EstadoPagoId = Convert.ToInt32(_estadoPago.SelectedItem.Value)
                            };
                            _ordenTrabajoVistaDtOs.OrdenTrabajo.EstadoPago = _estadoPagoVista;
                            _ordenTrabajoVistaDtOs.OrdenTrabajo.SeEnvio = false;
                            _ordenTrabajoVistaDtOs.OrdenTrabajo.EnvioMatriz = _envioMatriz.Checked;

                            _ordenTrabajoVistaDtOs.OrdenTrabajo.NumeroOrdenManual = _numeroOrdenManual.Text;
                            if (_valorPago.Text != String.Empty)
                                _ordenTrabajoVistaDtOs.Abono = Convert.ToDecimal(_valorPago.Text);
                            else
                                _ordenTrabajoVistaDtOs.Abono = 0;
                            _ordenTrabajoVistaDtOs.PerfilId = User.PerfilId;

                            //Graba la Orden de trabajo
                            string numeroOrden = _servicioDelegadoVenta.GrabarTransaccionInicialCompleta(_ordenTrabajoVistaDtOs);

                            Session["OrdenTrabajoId"] = numeroOrden;
                            Response.Redirect("~/Reporte/ReporteImpresionRapida.aspx");
                        //}
                        //else
                        //    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Numero_Prendas_No_Coincide").ToString(),
                        //      "_emisionPrenda");
                    }
                    else
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Valor_Abono_Mayo_PagoTotal").ToString(),
                           "_emisionPrenda");
                }
                else
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Mayor_Veinte_Prendas").ToString(),
                        "_emisionPrenda");




            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_emisionPrenda");
            }
        }
        protected void _btnGrabarMarca_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Selecciona  la ventana en el cual sale  el cliente 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _clientes_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "Seleccionar")
                {

                    clienteVistaDtOs = listaClienteVistaDtOses.Find(m => m.NumeroDocumento == _clientes.Rows[index].Cells[0].Text);

                    if (clienteVistaDtOs != null)
                    {
                        _cliente.Text = clienteVistaDtOs.NombreCompleto;
                        _direccion.Text = clienteVistaDtOs.DireccionCliente;
                        _telefono.Text = clienteVistaDtOs.TelefonoCliente;
                    }
                    else
                    {
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Cliente_No_Existe").ToString(), "_emisionPrenda");
                    }


                }



            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Cambia  la intearcion  si es pendiente cancelado  o pagado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void _estadoPago_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Pendiente
                if (_estadoPago.SelectedItem.Value.ToString() == "1")
                {
                    _valorPago.Visible = false;
                    _labelValorPago.Visible = false;
                    _valorPago.Text = String.Empty;
                    _valorPago.ReadOnly = false;
                }
                //Cancelado
                else if (_estadoPago.SelectedItem.Value.ToString() == "2")
                {
                    _valorPago.Visible = true;
                    _labelValorPago.Visible = true;
                    _valorPago.ReadOnly = true;
                    _valorPago.Text = String.Format("{0:0.00}", _ordenTrabajoVistaDtOs.DetalleOrdenTrabajo.Sum(m => m.ValorTotal));
                }
                //Abonado
                else if (_estadoPago.SelectedItem.Value.ToString() == "3")
                {
                    _valorPago.Visible = true;
                    _labelValorPago.Visible = true;
                    _valorPago.ReadOnly = false;
                    _valorPago.Text = String.Format("{0:0.00}", _ordenTrabajoVistaDtOs.DetalleOrdenTrabajo.Sum(m => m.ValorTotal));
                    
                }

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_emisionPrenda");
            }
        }


        /// <summary>
        /// Pasos  del wizard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _emisionPrenda_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            try
            {


                //if (_emisionPrenda.ActiveStep.ID == "_informacionPersonal")
                //{
                //    Page.Validate("Form");
                //    if (Page.IsValid==true)
                //    e.Cancel = true;
                //}

                //            If wizRegistration.ActiveStep.ID = "wizSelectPostalCode" AndAlso e.NextStepIndex > e.CurrentStepIndex Then
                //    Page.Validate("Form")
                //    If Not Page.IsValid() Then
                //        e.Cancel = True
                //    End If
                //End If
                //                wizar

                _revisionPrendas.Enabled = false;
            if (e.NextStepIndex == 1)
            {
                    CargaInicialPaso1();
                     TipoLavado();
                    
            }
                InicializarValores();
                EjecutarPromociones();
            }
            catch (Exception ex)
            {
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_emisionPrenda");
            }


}

        protected void _emisionPrenda_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            try
            {
                if (e.NextStepIndex == 0)
                    _tipoLavado.Enabled = false;
            }
            catch (Exception ex)
            {
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_emisionPrenda");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                 if(!IsPostBack)
                    CargarInformacionInicial();
            }
            catch (Exception ex)
            {
                
                throw;
            }

        }
       

        /// <summary>
        /// Busca al cliente 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnBusquedaCliente_OnClick(object sender, EventArgs e)
        {
            try
            {

                if (_tipoBusqueda.SelectedItem.Value == "1")
                    clienteVistaDtOs =
                       _servicioDelegadoIndividuo.ObtenerDatosClientePorNumeroIdentificacion(_numeroDocumentoBusqueda.Text.ToUpper());
                else
                {
                    listaClienteVistaDtOses = _servicioDelegadoIndividuo.ObtenerDatosClientePorApellidos(_numeroDocumentoBusqueda.Text.ToUpper(), _parametroDos.Text.ToUpper());

                    if (listaClienteVistaDtOses.Count > 0)
                    {
                        _clientes.DataSource = listaClienteVistaDtOses;
                        _clientes.DataBind();
                        _btnCliente_ModalPopupExtender.TargetControlID = "_emisionPrenda";
                        _btnCliente_ModalPopupExtender.Show();
                    }
                    else
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Cliente_No_Existe").ToString(), "_emisionPrenda");
                }

                if (clienteVistaDtOs != null)
                {
                    _cliente.Text = clienteVistaDtOs.NombreCompleto;
                    _direccion.Text = clienteVistaDtOs.DireccionCliente;
                    _telefono.Text = clienteVistaDtOs.TelefonoCliente;
                }
                else
                {
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Cliente_No_Existe").ToString(), "_emisionPrenda");
                }
            }
            catch (Exception ex)
            {
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_emisionPrenda");
            }
        }

        /// <summary>
        /// Depende  de como escoje la informacion para la  busqueda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _tipoBusqueda_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_tipoBusqueda.SelectedItem.Value.ToString() == "1")
            {
                _numeroDocumentoBusqueda.Text = String.Empty;
                _numeroDocumentoBusqueda.ReadOnly = false;
                _parametroDos.Text = String.Empty;
                _parametroDos.ReadOnly = true;
                _labelNumeroDocumentoBusqueda.Text = GetGlobalResourceObject("Web_es_Ec", "Label_Numero_Documento").ToString();
                _labelParametroDos.Text = String.Empty;


            }
            else if (_tipoBusqueda.SelectedItem.Value.ToString() == "-1")
            {

                _labelNumeroDocumentoBusqueda.Text = String.Empty;
                _labelParametroDos.Text = String.Empty;
                _numeroDocumentoBusqueda.Text = String.Empty;
                _numeroDocumentoBusqueda.ReadOnly = true;

                _parametroDos.Text = String.Empty;
                _parametroDos.ReadOnly = true;
            }
            else if (_tipoBusqueda.SelectedItem.Value.ToString() == "2")
            {
                _numeroDocumentoBusqueda.Text = String.Empty;
                _numeroDocumentoBusqueda.ReadOnly = false;
                _parametroDos.Text = String.Empty;
                _parametroDos.ReadOnly = false;
                _labelNumeroDocumentoBusqueda.Text = GetGlobalResourceObject("Web_es_Ec", "Label_Apellido_Paterno").ToString();
                _labelParametroDos.Text = GetGlobalResourceObject("Web_es_Ec", "Label_Busqueda_Apellido_Materno").ToString();

            }
            if (_tipoBusqueda.SelectedItem.Value.ToString() == "3")
            {
                _numeroDocumentoBusqueda.Text = String.Empty;
                _numeroDocumentoBusqueda.ReadOnly = false;
                _parametroDos.Text = String.Empty;
                _parametroDos.ReadOnly = true;
                _labelNumeroDocumentoBusqueda.Text = GetGlobalResourceObject("Web_es_Ec", "Label_Razon_Social").ToString();
                _labelParametroDos.Text = String.Empty;



            }
        }



        /// <summary>
        /// Renvia  ala pagina de  creacion de  clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnCrearCliente_OnClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Individuo/Cliente.aspx");
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_emisionPrenda");
            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "Eliminar")
                {

                    _listaTrabajoVistaDtOs.RemoveAt(index);
                    _datos.DataSource = _listaTrabajoVistaDtOs;
                    _datos.DataBind();

                    int maximoDias = 2;
                    if (_listaTrabajoVistaDtOs.Count != 0)

                    {
                        List<ProductoVistaModelo> _listaPrendas = _servicioDelegadoInventario.ObtenerProductoPorTipoProductoId(Convert.ToInt32(Util.TipoProducto.Servicio));
                        foreach (var detalleOrdenTrabajoVista in _listaTrabajoVistaDtOs)
                        {
                            ProductoVistaModelo productoVistaModelo = _listaPrendas.FirstOrDefault(m => m.ProductoId.Equals(Convert.ToInt32(detalleOrdenTrabajoVista.Producto.ProductoId)));


                            if (detalleOrdenTrabajoVista.Producto.ProductoId == Convert.ToInt32(productoVistaModelo.ProductoId))
                            {
                                if (maximoDias <= Convert.ToInt32(productoVistaModelo.TiempoEntrega))
                                    maximoDias = Convert.ToInt32(productoVistaModelo.TiempoEntrega);

                            }


                        }
                    }

                    Validacion _validacion = new Validacion();

                    _fechaEntrega.Text = DateTime.Now.AddDays(maximoDias + _validacion.CalculoDias()).ToShortDateString();

                }


                if (e.CommandName == "Agregar")
                {

                    if (_ordenTrabajoVistaDtOs.OrdenTrabajo.EsTemporal != true)
                    {
                        _nombreMarca.Value = _datos.Rows[index].Cells[0].Text;
                        
                        DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVista =
                                _listaTrabajoVistaDtOs.Find(m => m.Producto.Nombre == _nombreMarca.Value.ToString());
                        _numeroPrendas.Text =
                            (_productoVista.Find(m => m.ProductoId == _detalleOrdenTrabajoVista.Producto.ProductoId)
                                .NumeroPrendas * _detalleOrdenTrabajoVista.Cantidad).ToString();
                        if (_detalleOrdenTrabajoVista.DetallePrendaOrdenTrabajo == null)
                        {
                            _btnDetalleOrden_ModalPopupExtender.TargetControlID = "_emisionPrenda";
                            _btnDetalleOrden_ModalPopupExtender.Show();
                            _colorDetalle.DataSource = _servicioDelegadoGeneral.ObetenerColores();
                            _colorDetalle.DataBind();
                            _marcaDetalle.DataSource = _servicioDelegadoGeneral.ObtenerMarcas();
                            _marcaDetalle.DataBind();
                            _estadoPrendaDetalle.Text = String.Empty;
                            _tratamientoEspecialDetalle.Text = String.Empty;
                            _observacion.Text = String.Empty;
                            _informacionVisualDetalle.Text = String.Empty;
                        }
                       else if (_detalleOrdenTrabajoVista.DetallePrendaOrdenTrabajo.Count <
                            Convert.ToInt32(_numeroPrendas.Text))
                        {
                            _btnDetalleOrden_ModalPopupExtender.TargetControlID = "_emisionPrenda";
                            _btnDetalleOrden_ModalPopupExtender.Show();
                            _colorDetalle.DataSource = _servicioDelegadoGeneral.ObetenerColores();
                            _colorDetalle.DataBind();
                            _marcaDetalle.DataSource = _servicioDelegadoGeneral.ObtenerMarcas();
                            _marcaDetalle.DataBind();
                            _estadoPrendaDetalle.Text = String.Empty;
                            _tratamientoEspecialDetalle.Text = String.Empty;
                            _observacion.Text = String.Empty;
                            _informacionVisualDetalle.Text = String.Empty;
                            
                            

                        }
                        else
                            Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Numero_Prenda_Igual")?.ToString(), "_emisionPrenda");
                    }
                    else
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Emision_Rapida").ToString(), "_emisionPrenda");

                }

                if (e.CommandName == "Visualizar")
                {
                    _nombreMarca.Value = _datos.Rows[index].Cells[0].Text;
                   
                        Panel Detalles = (Panel)_datos.Rows[index].Cells[10].FindControl("Detalles");
                        Detalles.Visible = true;
                        GridView _detalleCuotas = (GridView)Detalles.FindControl("_detalleCuotas");
                       DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVistaa = _listaTrabajoVistaDtOs.Find(m => m.Producto.Nombre == _nombreMarca.Value.ToString());
                        if (_detalleOrdenTrabajoVistaa != null)
                        {
                            _detalleCuotas.DataSource = _detalleOrdenTrabajoVistaa.DetallePrendaOrdenTrabajo;
                            _detalleCuotas.DataBind();
                        }
                     


                }

                if (e.CommandName == "EsconderVisualizar")
                {
                    Panel Detalles = (Panel)_datos.Rows[index].Cells[10].FindControl("Detalles");
                    Detalles.Visible = false;
                }
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_emisionPrenda");
            }
        }


        /// <summary>
        /// Totales  en el pie  de la grilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private decimal _montoTotal = 0;
        private decimal _montoTotalUnitario = 0;
        private decimal _montoDescuento = 0;
        private int _cantidadTotal = 0;
        protected void _datos_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    _montoTotalUnitario += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ValorTotalUnitario"));
                    _montoDescuento += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ValorDescuento"));
                    _cantidadTotal += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Cantidad"));
                    _montoTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ValorTotal"));
                    //if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ValorDescuento")) > 0)
                    //    e.Row.BackColor = System.Drawing.Color.Red;
                    DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVista =_listaTrabajoVistaDtOs.Find(a => a.Producto.Nombre == DataBinder.Eval(e.Row.DataItem, "Producto.Nombre").ToString());

                    //DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVista = _listaTrabajoVistaDtOs.Find(m => m.Producto.Nombre == _nombreMarca.Value.ToString());
                    if (_detalleOrdenTrabajoVista != null)
                    {
                        JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado.ServicioDelegadoInventario
                            _servicioDelegadoInventario1 =
                                new JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado.ServicioDelegadoInventario();
                        ProductoVistaModelo _productoVista = _servicioDelegadoInventario1.ObtenerProductoPorId(_detalleOrdenTrabajoVista.Producto.ProductoId);
                        _numeroPrendas.Text = String.Format("{0:0}", _productoVista.NumeroPrendas * _detalleOrdenTrabajoVista.Cantidad);
                        if (_detalleOrdenTrabajoVista.DetallePrendaOrdenTrabajo!=null )
                            if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Cantidad")) == _detalleOrdenTrabajoVista.DetallePrendaOrdenTrabajo.Count )
                            e.Row.BackColor = System.Drawing.Color.Green;
                    }



                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[4].Text = "Totales:";

                    e.Row.Cells[5].Text = _cantidadTotal.ToString();
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[7].Text = _montoTotalUnitario.ToString();
                    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Font.Bold = true;

                    e.Row.Cells[8].Text = _montoDescuento.ToString();
                    e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Font.Bold = true;

                    e.Row.Cells[9].Text = _montoTotal.ToString();
                    e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Font.Bold = true;

                }
             
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_emisionPrenda");
            }
        }

        /// <summary>
        /// Agrega la orden de trabajo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnAgregarDetalleOrdenTrabajo_OnClick(object sender, EventArgs e)
        {
            try
            {
                if(_soloPlanchado.Checked==true || _procentajeManchado.Checked==true)
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Solo_Planchado_Manchado").ToString(), "_emisionPrenda");
                
                AgregarOrdenTrabajo();
                CargarDetalleOrdenTrabajo();
                CargaInicialPaso1();
                _soloPlanchado.Enabled = false;
                _procentajeManchado.Enabled = false;
                
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_emisionPrenda");
            }
        }

        /// <summary>
        /// Valida el procentaje de manchado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _procentajeManchado_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
               
                if (_procentajeManchado.Checked == true)
                {
                    EjecutarPromociones();
                    _valorUnitario.Text = String.Format("{0:0.00}", Convert.ToDecimal(_valorUnitario.Text) * Convert.ToDecimal(0.3) + (Convert.ToDecimal(_valorUnitario.Text)));
                    _valorTotal.Text = String.Format("{0:0.00}", Convert.ToDecimal(_valorTotal.Text) * Convert.ToDecimal(0.3) + (Convert.ToDecimal(_valorTotal.Text)));
                    _descuento.Text = "0";
                    _valorTotalPagar.Text = String.Format("{0:0.00}", Convert.ToDecimal(_valorTotalPagar.Text) * Convert.ToDecimal(0.3) + (Convert.ToDecimal(_valorTotalPagar.Text)));
                    _soloPlanchado.Checked = false;
                }
                else
                _prenda_OnSelectedIndexChanged(sender, e);
                

            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Solo planchado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _soloPlanchado_OnCheckedChanged(object sender, EventArgs e)
        {
            try{
               
                if (_soloPlanchado.Checked == true)
                {
                    EjecutarPromociones();
                    _valorUnitario.Text = (Convert.ToDecimal(_valorUnitario.Text) / 2).ToString();
                    _valorTotal.Text = (Convert.ToDecimal(_valorTotal.Text) / 2).ToString();
                    _descuento.Text = "0";
                    _valorTotalPagar.Text = (Convert.ToDecimal(_valorTotalPagar.Text) / 2).ToString();
                    _procentajeManchado.Checked = false;
                }
                else
                {
                    _prenda_OnSelectedIndexChanged(sender, e);
                 
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Cuando  se agerga suavizante  a la ropa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _suavizante_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {


              
                decimal valor = Convert.ToDecimal(_valorUnitario.Text);
                decimal valorExtra =
                    Convert.ToDecimal(
                        _servicioDelegadoGeneral.ObtenerParametroPorDescripcion("SUAVIZANTE").NumeroDecimal);
                if (_suavizante.Checked == true)

                    _valorUnitario.Text = Convert.ToString(valor + valorExtra);
                else
                    _valorUnitario.Text = Convert.ToString(valor - valorExtra);
                _valorTotal.Text = String.Format("{0:0.00}",
                    Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));
                _valorTotalPagar.Text = String.Format("{0:0.00}",
                    Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));
            }
            catch (Exception ex)
            {
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_emisionPrenda");
            }
            
        }


        /// <summary>
        /// Fijador de  color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _fijadorColor_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
               

                decimal valor = Convert.ToDecimal(_valorUnitario.Text);
                decimal valorExtra =
                    Convert.ToDecimal(
                        _servicioDelegadoGeneral.ObtenerParametroPorDescripcion("FIJADOR_COLOR").NumeroDecimal);
                if (_fijadorColor.Checked == true)

                    _valorUnitario.Text = Convert.ToString(valor + valorExtra);
                else
                    _valorUnitario.Text = Convert.ToString(valor - valorExtra);
                _valorTotal.Text = String.Format("{0:0.00}",
                    Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));
                _valorTotalPagar.Text = String.Format("{0:0.00}",
                    Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));
            }
            catch (Exception ex)
            {
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_emisionPrenda");
            }
        }


        /// <summary>
        /// Calcula  el valor de desengrasante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _desengrasante_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
            
                decimal valor = Convert.ToDecimal(_valorUnitario.Text);
                decimal valorExtra =
                    Convert.ToDecimal(
                        _servicioDelegadoGeneral.ObtenerParametroPorDescripcion("DESENGRASANTE").NumeroDecimal);
                if (_desengrasante.Checked == true)

                    _valorUnitario.Text = Convert.ToString(valor + valorExtra);
                else
                    _valorUnitario.Text = Convert.ToString(valor - valorExtra);
                _valorTotal.Text = String.Format("{0:0.00}",
                    Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));
                _valorTotalPagar.Text = String.Format("{0:0.00}",
                    Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));
            }
            catch (Exception ex)
            {
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_emisionPrenda");
            }
        }

        /// <summary>
        /// Calcula las promociones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _cantidad_OnTextChanged(object sender, EventArgs e)
        {
            EjecutarPromociones();
        }

       

        /// <summary>
        /// Selecciona la prenda  e  inicializa los valores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _prenda_OnSelectedIndexChanged(object sender, EventArgs e)
        {
           
            InicializarValores();
            if (Convert.ToInt32(_prenda.SelectedItem.Value) == Convert.ToInt32(Util.LavadoPorLibras.LavadoPorLibras))
            {
                _suavizante.Visible = true;
                _desengrasante.Visible = true;
                _fijadorColor.Visible = true;
                _soloPlanchado.Visible = false;
                _procentajeManchado.Visible = false;


            }
            else
            {
                _suavizante.Visible = false;
                _desengrasante.Visible = false;
                _fijadorColor.Visible = false;
                _soloPlanchado.Visible = true;
                _procentajeManchado.Visible = true;

            }
            _suavizante.Checked = false;
            _desengrasante.Checked = false;
            _fijadorColor.Checked = false;
            if (_soloPlanchado.Checked != true || _procentajeManchado.Checked != true)
                EjecutarPromociones();

            if (_soloPlanchado.Checked == true)
                _soloPlanchado_OnCheckedChanged(sender, e);
            if (_procentajeManchado.Checked == true)
                _procentajeManchado_OnCheckedChanged(sender, e);
        }

        /// <summary>
        /// Revisa las promociones vigentes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _revisarPromocionesVigentes_OnClick(object sender, EventArgs e)
        {
            try
            {
                _btnRevisionPromociones_ModalPopupExtender.TargetControlID = "_emisionPrenda";
                _btnRevisionPromociones_ModalPopupExtender.Show();
                _promociones.DataSource = _servicioDelegadoReglaNegocio.ObtenerPromocionesVigentes(Convert.ToInt32(User.PuntoVentaId), Convert.ToInt32(User.SucursalId));
                _promociones.DataBind();
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_emisionPrenda");
            }
        }


        /// <summary>
        /// Crea la marca  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _crearMarca_OnClick(object sender, EventArgs e)
        {
            try
            {
                _txtMarca.Text = String.Empty;
                _btnMarca_ModalPopupExtender.TargetControlID = "_emisionPrenda";
                _btnMarca_ModalPopupExtender.Show();
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_emisionPrenda");
            }
        }

        #endregion

        #region  Metodos

        /// <summary>
        /// Encera  todos los controles de detalle de  orden de trabajo
        /// </summary>
        private void LimpiarDetalleOrdenTrabajo()
        {
            try
            {
                _cantidad.Text = String.Empty;
                CargaInicialPaso1();
                _valorUnitario.Text = String.Empty;
                _valorTotal.Text = String.Empty;
                _cantidad.Text = "1";
                _descuento.Text = String.Empty;
                _valorTotalPagar.Text = String.Empty;
                _promocionAplicada.Text = String.Empty;
                _promocionId.Value = string.Empty;


            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Carga el detalle de la orden de trabajo
        /// </summary>
        private void CargarDetalleOrdenTrabajo()
        {
            try
            {
                _datos.DataSource = _ordenTrabajoVistaDtOs.DetalleOrdenTrabajo;
                _datos.DataBind();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Carga la  orden de trabajo
        /// </summary>
        private void AgregarOrdenTrabajo()
        {
            try
            {
                int cantidadEntregaUrgenciaParametrizada =
                  Convert.ToInt32(_servicioDelegadoGeneral.ObtenerParametroPorDescripcion("NUMERO_URGENTES").NumeroEntero);
                int cantidadRealizadaDia = _servicioDelegadoVenta.ObtenerNumeroEntregaUrgentesPorFechaActual(Convert.ToInt32(User.PuntoVentaId));

                if (cantidadRealizadaDia < cantidadEntregaUrgenciaParametrizada || Convert.ToInt32(_tipoEntrega.SelectedItem.Value) != 2)
                {


                    TipoLavadoVistaModelo _tipoLavadoVista = new TipoLavadoVistaModelo
                    {
                        TipoLavadoId = Convert.ToInt32(_tipoLavado.SelectedItem.Value)

                    };
                    UsuarioVistaModelo _usuarioVista = new UsuarioVistaModelo
                    {
                        UsuarioId = User.Id
                    };

                    ClienteVistaModelo _clienteVista = new ClienteVistaModelo
                    {
                        ClienteId = Convert.ToInt32(clienteVistaDtOs.ClienteId)
                    };

                    EstadoPagoVistaModelo _estadoPagoVista = new EstadoPagoVistaModelo
                    {
                        EstadoPagoId = Convert.ToInt32(_estadoPago.SelectedItem.Value)
                    };

                    SucursalVistaModelo _sucursalVista = new SucursalVistaModelo
                    {
                        SucursalId = Convert.ToInt32(User.SucursalId)
                    };
                    PuntoVentaVistaModelo _puntoVentaVista = new PuntoVentaVistaModelo
                    {
                        PuntoVentaId = Convert.ToInt32(User.PuntoVentaId)
                    };
                    EntregaUrgenciaVistaModelo _entregaUrgencia = new EntregaUrgenciaVistaModelo
                    {
                        EntregaUrgenciaId = Convert.ToInt32(_tipoEntrega.SelectedItem.Value)
                    };
                    OrdenTrabajoVistaModelo _ordenTrabajoVista = new OrdenTrabajoVistaModelo
                    {
                        FechaEntrega = Convert.ToDateTime(_fechaEntrega.Text),
                        FechaIngreso = Convert.ToDateTime(_fecha.Text),
                        EstadoPago = _estadoPagoVista,
                        TipoLavado = _tipoLavadoVista,
                        Usuario = _usuarioVista,
                        Sucursal = _sucursalVista,
                        PuntoVenta = _puntoVentaVista,
                        ClienteModelo = _clienteVista,
                        NumeroOrden = "0",
                        EntregaUrgencia = _entregaUrgencia,
                         RevisionPrendaCliente = _revisionPrendas.Checked,
                         ObjetoOlvidado = _objetoOlvidado.Text,
                         EsTemporal = _revisionPrendas.Checked
                    


                    };
                    _ordenTrabajoVistaDtOs.OrdenTrabajo = _ordenTrabajoVista;

                    //if (
                    //    _listaTrabajoVistaDtOs.Where(m => m.Producto.Nombre.Equals(_prenda.SelectedItem.Text.ToString())).Select(a=>a.Producto) !=
                    //    null && !_listaTrabajoVistaDtOs.Any())

                    if(1==1)
                    {


                        DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVista = new DetalleOrdenTrabajoVistaModelo();




                        ProductoVistaModelo _productoVista = new ProductoVistaModelo
                        {
                            ProductoId = Convert.ToInt32(_prenda.SelectedItem.Value),
                            Nombre = _prenda.SelectedItem.Text.ToUpper(),
                            NumeroPrendas = 2

                        };


                        ImpuestoVistaModelo _impuestoVista = new ImpuestoVistaModelo
                        {
                            ImpuestoId = 1
                        };
                        VentaComisionVistaModelo _ventaComisionVista = new VentaComisionVistaModelo
                        {
                            VentaComisionId = 1
                        };


                        _detalleOrdenTrabajoVista.Producto = _productoVista;



                        _detalleOrdenTrabajoVista.Cantidad = Convert.ToInt32(_cantidad.Text);
                        _detalleOrdenTrabajoVista.ValorUnitario = Convert.ToDecimal(_valorUnitario.Text);
                        _detalleOrdenTrabajoVista.ValorTotal = Convert.ToDecimal(_valorTotalPagar.Text);
                        _detalleOrdenTrabajoVista.Impuesto = _impuestoVista;
                        _detalleOrdenTrabajoVista.OrdenTrabajo = _ordenTrabajoVista;
                        _detalleOrdenTrabajoVista.VentaComision = _ventaComisionVista;
                        _detalleOrdenTrabajoVista.PorcentajeImpuesto = 12;



                        _detalleOrdenTrabajoVista.ValorTotalUnitario = Convert.ToDecimal(_valorTotal.Text);
                        _detalleOrdenTrabajoVista.ValorDescuento = Convert.ToDecimal(_descuento.Text);
                        _detalleOrdenTrabajoVista.PromocionAplicada = Convert.ToInt32(_promocionId.Value);
                        _detalleOrdenTrabajoVista.NombrePromocionAplicada = _promocionAplicada.Text;
                        _detalleOrdenTrabajoVista.Suavizante = _suavizante.Checked;
                        _detalleOrdenTrabajoVista.FijadorColor = _fijadorColor.Checked;
                        _detalleOrdenTrabajoVista.Desengrasante = _desengrasante.Checked;
                        _listaTrabajoVistaDtOs.Add(_detalleOrdenTrabajoVista);
                        _ordenTrabajoVistaDtOs.DetalleOrdenTrabajo = _listaTrabajoVistaDtOs;

                        int cantidadEspecial = 0;
                        int cantidadNormal = 0;
                        int maximoDias = 2;
                        if (_listaTrabajoVistaDtOs.Count != 0)

                        {
                            List<ProductoVistaModelo> _listaPrendas =
                                _servicioDelegadoInventario.ObtenerProductoPorTipoProductoId(
                                    Convert.ToInt32(Util.TipoProducto.Servicio));
                            foreach (var detalleOrdenTrabajoVista in _listaTrabajoVistaDtOs)
                            {
                                ProductoVistaModelo productoVistaModelo =
                                    _listaPrendas.FirstOrDefault(
                                        m =>
                                            m.ProductoId.Equals(
                                                Convert.ToInt32(detalleOrdenTrabajoVista.Producto.ProductoId)));


                                if (detalleOrdenTrabajoVista.Producto.ProductoId ==
                                    Convert.ToInt32(productoVistaModelo.ProductoId))
                                {
                                    if (productoVistaModelo.PrendaEspecial == true)
                                        cantidadEspecial += 1;
                                    else
                                        cantidadNormal += 1;
                                    if (maximoDias <= Convert.ToInt32(productoVistaModelo.TiempoEntrega))
                                        maximoDias = Convert.ToInt32(productoVistaModelo.TiempoEntrega);




                                }


                            }
                        }

                        if (cantidadEspecial != 0 && cantidadNormal != 0)
                        {
                            Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Prenda_Especial").ToString(),
                                "_emisionPrenda");
                            DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVistaa =
                                _listaTrabajoVistaDtOs.Find(m => m.Producto.Nombre == _nombreMarca.Value.ToString());
                            _listaTrabajoVistaDtOs.RemoveAt(_listaTrabajoVistaDtOs.Count - 1);
                        }

                        Validacion _validacion = new Validacion();

                        _fechaEntrega.Text =
                            DateTime.Now.AddDays(maximoDias + _validacion.CalculoDias()).ToShortDateString();
                    }
                    else

                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Prenda_Ingresada").ToString(), "_emisionPrenda");
                }
               

                
                    else
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Prenda_Especial").ToString(), "_emisionPrenda");
                


           


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Inicializa los valores de las cantidades 
        /// </summary>

        private void InicializarValores()
	    {
	        try
	        {
                _cantidad.Text = "1";
                _valorUnitario.Text = String.Format("{0:0.00}", _servicioDelegadoInventario.ObtenerProductoPrecioPorProductoId(
                        Convert.ToInt32(_prenda.SelectedItem.Value)).FirstOrDefault().Precio);

                _descuento.Text = String.Format("{0:0.00}",0);
                _valorTotalPagar.Text = String.Format("{0:0.00}",Convert.ToDecimal(_valorUnitario.Text)*Convert.ToDecimal(_cantidad.Text)); 
                _valorTotal.Text = String.Format("{0:0.00}", Convert.ToDecimal(_valorUnitario.Text) * Convert.ToDecimal(_cantidad.Text));
                _promocionAplicada.Text ="NINGUNA";
                
            }
	        catch (Exception)
	        {
	            
	            throw;
	        }
	    }

	    /// <summary>
        /// Carga  la  informacion  del paso  1
        /// </summary>
	    private void CargaInicialPaso1()
	    {
	        try
	        {
                TipoLavado();
	        
            }
	        catch (Exception)
	        {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Cliente_No_Existe").ToString(), "_emisionPrenda");
            }
	    }

	    /// <summary>
        /// Carga  la informacion inicial en el page load
        /// </summary>
	    private void CargarInformacionInicial()
	    {
	        try
	        {
                _fecha.Text = DateTime.Now.ToShortDateString();
                _sucursal.Text = User.NombrePuntoVenta;
                _usuario.Text = User.NombreUsuario;
                _tipoLavado.DataSource = _servicioDelegadoGeneral.ObtenerTiposLavado();
                _tipoLavado.DataBind();
                _tipoBusqueda.DataSource = _colecciones.ObtenerTipoDocumentos();
                _tipoBusqueda.DataBind();
                _tipoBusqueda.SelectedIndex = _tipoBusqueda.Items.IndexOf(_tipoBusqueda.Items.FindByValue("-1"));
                _tipoEntrega.DataSource = _servicioDelegadoGeneral.ObtenerEntregaUrgencias();
                _tipoEntrega.DataBind();
                
                List<EstadoPagoVistaModelo> _listaEstadoPago= _servicioDelegadoGeneral.ObtenerEstadosPago();
                EstadoPagoVistaModelo estadoPago= new EstadoPagoVistaModelo();
	            estadoPago.EstadoPagoId = -1;
	            estadoPago.Descripcion = "SELECIONE";
                _listaEstadoPago.Add(estadoPago);

                _estadoPago.DataSource = _listaEstadoPago;
                _estadoPago.DataBind();
                _estadoPago.SelectedIndex =
                       _estadoPago.Items.IndexOf(
                           _estadoPago.Items.FindByValue("-1"));

                _fechaEntrega.Text = DateTime.Now.ToShortDateString();
	            InicializarVariables();

                bool fechaBloqueada =
                 Convert.ToBoolean(_servicioDelegadoGeneral.ObtenerParametroPorDescripcion("BLOQUEAR_FECHA_ENTREGA").Boolenao);

	            if (fechaBloqueada == true)
	            {
                    _fechaEntrega.ReadOnly = false;
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Fecha_Habilitada").ToString(), "_emisionPrenda");
                }
	            
                else
                    _fechaEntrega.ReadOnly = true;


            }
	        catch (Exception)
	        {
	            
	            throw;
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


        /// <summary>
        /// Ejecuta promociones en seco
        /// </summary>
        private void EjecutarPromociones()
        {
            try
            {

                if (_soloPlanchado.Checked!=true && _procentajeManchado.Checked !=true)
                { 
                ParametroEntradaReglaNegocioVistaDTOs parametroEntradaReglaNegocio =
                    new ParametroEntradaReglaNegocioVistaDTOs();

                parametroEntradaReglaNegocio.Cantidad = Convert.ToInt32(_cantidad.Text);
                parametroEntradaReglaNegocio.ProductoId = Convert.ToInt32(_prenda.SelectedItem.Value);
                parametroEntradaReglaNegocio.ValorTotal = Convert.ToDecimal(_cantidad.Text) *
                                                          Convert.ToDecimal(_valorUnitario.Text);

                parametroEntradaReglaNegocio.ValorUnitario = Convert.ToDecimal(_valorUnitario.Text);
                parametroEntradaReglaNegocio.ValorPromocion = Convert.ToDecimal(0);
                parametroEntradaReglaNegocio.PuntoVentaId = User.PuntoVentaId;
                parametroEntradaReglaNegocio.SucursalId = User.SucursalId;

                ParametroSalidaReglaNegocioVistaDTOs parametroSalidaReglaNegocio =
                    _servicioDelegadoReglaNegocio.EjecucionReglaNegocio(parametroEntradaReglaNegocio);

                _descuento.Text = String.Format("{0:0.00}", parametroSalidaReglaNegocio.ValorDescuento);
                _valorTotalPagar.Text = String.Format("{0:0.00}", parametroSalidaReglaNegocio.ValorTotalPagar);
                _valorTotal.Text = String.Format("{0:0.00}", parametroSalidaReglaNegocio.ValorTotal);
                _promocionAplicada.Text = parametroSalidaReglaNegocio.NombrePromocion;
                _promocionId.Value = parametroSalidaReglaNegocio.PromocionId.ToString();
                }
                else
                {
                    InicializarValores();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Valida  si  tiene  ingresado  numero de prendas
        /// </summary>
        /// <param name="detalleOrdenTrabajo"></param>
        /// <returns></returns>
        private bool ValidacionNumeroPrendas(List<DetalleOrdenTrabajoVistaModelo> detalleOrdenTrabajo)
        {
            try
            {
                foreach (var objetoDetalleOrdenTrabajo in detalleOrdenTrabajo)
                {
                    if (objetoDetalleOrdenTrabajo.DetallePrendaOrdenTrabajo != null)
                    {
                        if (objetoDetalleOrdenTrabajo.DetallePrendaOrdenTrabajo.Count != 0 &&
                            objetoDetalleOrdenTrabajo.DetallePrendaOrdenTrabajo.Count <=
                            objetoDetalleOrdenTrabajo.Cantidad)
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
	    private void InicializarVariables()
	    {

              _ordenTrabajoVistaDtOs = new OrdenTrabajoVistaDTOs();
            clienteVistaDtOs = new ClienteVistaDTOs();
          listaClienteVistaDtOses = new List<ClienteVistaDTOs>();
          _listaTrabajoVistaDtOs = new List<DetalleOrdenTrabajoVistaModelo>();
    
      _productoVista = null;
       
            }

        /// <summary>
        /// Tipo de  lavado
        /// </summary>
	    private void TipoLavado()
	    {
            _productoVista = _servicioDelegadoInventario.ObtenerProductoPorTipoProductoId(Convert.ToInt32(Util.TipoProducto.Servicio));
            if (Convert.ToInt32(_tipoLavado.SelectedItem.Value) == Convert.ToInt32(Util.TipoLavado.LavadoSeco))
            {
                _prenda.DataSource = _productoVista;
                _prenda.DataBind();
                _envioMatriz.Checked = true;
                _envioMatriz.Enabled = false;


            }
            else if (Convert.ToInt32(_tipoLavado.SelectedItem.Value) ==
                     Convert.ToInt32(Util.TipoLavado.LavadoPorLibras))
            {
                _prenda.DataSource = _productoVista.Where(m => m.Visible == true).ToList();
                _prenda.DataBind();
                _envioMatriz.Checked = false;
                _envioMatriz.Enabled = true;

            }
        }

        /// <summary>
        /// Valida  el tipo extra
        /// </summary>
        /// <param name="tipoExtra"></param>
	    private void ExtraLavadoPorLibras(string tipoExtra)
	    {
            try
            {
                decimal valor = Convert.ToDecimal(_valorUnitario.Text);
                decimal valorExtra =
                    Convert.ToDecimal(
                        _servicioDelegadoGeneral.ObtenerParametroPorDescripcion(tipoExtra).NumeroDecimal);
                if (_fijadorColor.Checked == true)

                    _valorUnitario.Text = Convert.ToString(valor + valorExtra);
                else
                    _valorUnitario.Text = Convert.ToString(valor - valorExtra);
                _valorTotal.Text = String.Format("{0:0.00}",
                    Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));
                _valorTotalPagar.Text = String.Format("{0:0.00}",
                    Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));
            }
            catch (Exception ex)
            {
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_emisionPrenda");
            }
        }

	    #endregion

	   
	}



}