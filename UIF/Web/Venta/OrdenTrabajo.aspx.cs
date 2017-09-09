
#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Base;
using Web.DTOs.Individuo;
using Web.DTOs.Logistica;
using Web.DTOs.ReglaNegocio;
using Web.DTOs.Venta;
using Web.Models.Contabilidad;
using Web.Models.FlujoProceso;
using Web.Models.General;
using Web.Models.Individuo;
using Web.Models.Inventario.Parametrizacion;
using Web.Models.Seguridad.Negocio;
using Web.Models.Venta.Negocio;
using Web.Models.Venta.Parametrizacion;
using Web.ServicioDelegado;
using Web.Util;

#endregion
namespace Web.Venta
{
    public partial class OrdenTrabajo : PaginaBase
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly ServicioDelegadoIndividuo _servicioDelegadoIndividuo = new ServicioDelegadoIndividuo();
        private readonly ServicioDelegadoInventario _servicioDelegadoInventario = new ServicioDelegadoInventario();
        private readonly ServicioDelegadoVenta _servicioDelegadoVenta = new ServicioDelegadoVenta();
        private readonly ServicioDelegadoGeneral _servicioDelegadoGeneral = new ServicioDelegadoGeneral();
        private static OrdenTrabajoVistaDTOs _ordenTrabajoVistaDtOs = new OrdenTrabajoVistaDTOs();
        private static ClienteVistaDTOs clienteVistaDtOs = new ClienteVistaDTOs();
        private  static  List<ClienteVistaDTOs>  listaClienteVistaDtOses= new List<ClienteVistaDTOs>();
        private static List<DetalleOrdenTrabajoVistaModelo> _listaTrabajoVistaDtOs =new List<DetalleOrdenTrabajoVistaModelo>();
        private readonly  ServicioDelegadoReglaNegocio _servicioDelegadoReglaNegocio= new ServicioDelegadoReglaNegocio();
        private static List<ProductoVistaModelo> _productoVista=null;
        private readonly Util.Colecciones _colecciones = new Colecciones();
        #endregion

        #region Eventos
        /// <summary>
        /// Cambia  el tipo de  busqueda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _tipoBusqueda_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// Selecciona los  clientes
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

                    clienteVistaDtOs = listaClienteVistaDtOses.Find(m => m.NombreCompleto == _clientes.Rows[index].Cells[0].Text);

                    if (clienteVistaDtOs != null)
                    {
                        _cliente.Text = clienteVistaDtOs.NombreCompleto;
                        _direccion.Text = clienteVistaDtOs.DireccionCliente;
                        _telefono.Text = clienteVistaDtOs.TelefonoCliente;
                    }
                    else
                    {
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Cliente_No_Existe").ToString(), "_grabarOrdenTrabajo");
                    }
                  

                }

             

            }
            catch (Exception)
            {
                
                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _suavizante_CheckedChanged(object sender, EventArgs e)
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

                _valorTotal.Text = String.Format("{0:0.00}", Convert.ToDecimal(_cantidad.Text)*Convert.ToDecimal(_valorUnitario.Text));
                _valorTotalPagar.Text = String.Format("{0:0.00}", Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _fijadorColor_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                decimal valor = Convert.ToDecimal(_valorUnitario.Text);
                decimal valorExtra =
                    Convert.ToDecimal(
                        _servicioDelegadoGeneral.ObtenerParametroPorDescripcion("SUAVIZANTE").NumeroDecimal);
                if (_fijadorColor.Checked == true)

                    _valorUnitario.Text = Convert.ToString(valor + valorExtra);
                else
                    _valorUnitario.Text = Convert.ToString(valor - valorExtra);
                _valorTotal.Text = String.Format("{0:0.00}", Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));
                _valorTotalPagar.Text = String.Format("{0:0.00}", Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _desengrasante_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                decimal valor = Convert.ToDecimal(_valorUnitario.Text);
                decimal valorExtra =
                    Convert.ToDecimal(
                        _servicioDelegadoGeneral.ObtenerParametroPorDescripcion("SUAVIZANTE").NumeroDecimal);
                if (_desengrasante.Checked == true)

                    _valorUnitario.Text = Convert.ToString(valor + valorExtra);
                else
                    _valorUnitario.Text = Convert.ToString(valor - valorExtra);
                _valorTotal.Text = String.Format("{0:0.00}", Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));
                _valorTotalPagar.Text = String.Format("{0:0.00}", Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }
        }

        /// <summary>
        /// Elimina  el detalle  de la prenda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _detallePrenda_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "Eliminar")
                {
                    DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVista = _listaTrabajoVistaDtOs.Find(m => m.Producto.Nombre == _nombreMarca.Value.ToString());
                    _detalleOrdenTrabajoVista.DetallePrendaOrdenTrabajo.RemoveAt(index);
                    
                }
            }
            catch (Exception ex)
            {
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }
        }

        /// <summary>
        /// Agrega el detalle  de las  prendas
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
                _listaDetalleOrdenTrabajoObservacion.Add(_detalleOrdenTrabajoObservacion);

                DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVista = _listaTrabajoVistaDtOs.Find(m=>m.Producto.Nombre== _nombreMarca.Value.ToString());
                DetallePrendaOrdenTrabajoVistaModelo _detallePrendaOrdenTrabajo = new DetallePrendaOrdenTrabajoVistaModelo();
                _detallePrendaOrdenTrabajo.ColorId =Convert.ToInt32(_colorDetalle.SelectedItem.Value);
                _detallePrendaOrdenTrabajo.MarcaId = Convert.ToInt32(_marcaDetalle.SelectedItem.Value);
                _detallePrendaOrdenTrabajo.EstadoPrenda = _estadoPrendaDetalle.Text.ToUpper();
                _detallePrendaOrdenTrabajo.InformacionVisual = _informacionVisualDetalle.Text.ToUpper();
                _detallePrendaOrdenTrabajo.NumeroInternoPrenda = _numeroInternoDetalle.Text.ToUpper();
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




            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }

        }
        /// <summary>
        /// Revision de promociones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _revisarPromocionesVigentes_Click(object sender, EventArgs e)
        {
            try
            {
                _btnRevisionPromociones_ModalPopupExtender.TargetControlID = "_grabarOrdenTrabajo";
                _btnRevisionPromociones_ModalPopupExtender.Show();
                _promociones.DataSource = _servicioDelegadoReglaNegocio.ObtenerPromocionesVigentes(Convert.ToInt32(User.PuntoVentaId),Convert.ToInt32(User.SucursalId));
                _promociones.DataBind();
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }


        }

        


       
        /// <summary>
        /// Graba la marca   y lo coloca en el  combo de marca
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnGrabarrMarca_Click(object sender, EventArgs e)
        {
            try
            {
                MarcaVistaModelo _validarMarcaVistaModelo =
                    _servicioDelegadoGeneral.ValidarSiExisteMarcaPorDescripcion(_txtMarca.Text.ToUpper());

                if (_validarMarcaVistaModelo == null)
                {
                    MarcaVistaModelo _marcaVistaModelo = new MarcaVistaModelo();
                    _marcaVistaModelo.Descripcion = _txtMarca.Text.ToUpper();
                    _marcaVistaModelo.EstaHabilitado = true;
                    _servicioDelegadoGeneral.GrabarMarca(_marcaVistaModelo);
                   


                }

                else
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Marca_Existe").ToString(), "_grabarOrdenTrabajo");


            }
            catch (Exception ex)
            {
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");

            }
        }

        /// <summary>
        /// Crea la marca 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _crearMarca_Click(object sender, EventArgs e)
        {
            try
            {
                _txtMarca.Text=String.Empty;
                if(Convert.ToInt32(_tipoLavado.SelectedItem.Value)==Convert.ToInt32(Util.TipoLavado.LavadoSeco))
                _btnMarca_ModalPopupExtender.TargetControlID = "_crearMarca";
                else if (Convert.ToInt32(_tipoLavado.SelectedItem.Value) == Convert.ToInt32(Util.TipoLavado.LavadoPorLibras))
                    _btnMarca_ModalPopupExtender.TargetControlID = "_crearMarcaPorLibras";
                _btnMarca_ModalPopupExtender.Show();
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }

        }

        /// <summary>
        /// depende  de la forma de pago 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _estadoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Pendiente
                if (_estadoPago.SelectedItem.Value.ToString() == "1")
                {
                    _valorPago.Visible = false;
                    _labelValorPago.Visible = false;
                    _valorPago.Text=String.Empty;
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
                    _valorPago.Text = String.Empty;
                    _valorPago.Focus();
                }

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
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

        protected void _datos_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    _montoTotalUnitario += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ValorTotalUnitario"));
                    _montoDescuento += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ValorDescuento"));
                    _cantidadTotal += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Cantidad"));
                    _montoTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ValorTotal"));
                    if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ValorDescuento")) > 0)
                        e.Row.BackColor = System.Drawing.Color.Red;

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

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }


        }

        /// <summary>
        /// Elimina el item seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
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
                    _btnDetalleOrden_ModalPopupExtender.TargetControlID = "_grabarOrdenTrabajo";
                    _btnDetalleOrden_ModalPopupExtender.Show();
                    
                    _colorDetalle.DataSource = _servicioDelegadoGeneral.ObetenerColores();
                    _colorDetalle.DataBind();
                    _marcaDetalle.DataSource = _servicioDelegadoGeneral.ObtenerMarcas();
                    _marcaDetalle.DataBind();
                    _estadoPrendaDetalle.Text="BUENO";
                    _tratamientoEspecialDetalle.Text="NINGUNO";
                    _numeroInternoDetalle.Text=String.Empty;
                    _informacionVisualDetalle.Text=String.Empty;
                    _nombreMarca.Value = _datos.Rows[index].Cells[1].Text;
                    DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVista = _listaTrabajoVistaDtOs.Find(m => m.Producto.Nombre == _nombreMarca.Value.ToString());
                   _numeroPrendas.Text = (_productoVista.Find(m=>m.ProductoId== _detalleOrdenTrabajoVista.Producto.ProductoId).NumeroPrendas* _detalleOrdenTrabajoVista.Cantidad).ToString();
                    _detallePrenda.DataSource = _detalleOrdenTrabajoVista.DetallePrendaOrdenTrabajo;
                    _detallePrenda.DataBind();

                }
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }
        }

        /// <summary>
        /// Visualizacion de los paneles de acuerdo al tipo de  lavado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _tipoLavado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //InicializarVariables();
                //LimpiarDetalleOrdenTrabajo();
                //CargarDetalleOrdenTrabajo();
                // _productoVista= _servicioDelegadoInventario.ObtenerProductoPorTipoProductoId(Convert.ToInt32(Util.TipoProducto.Servicio));
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
                    _prenda.DataSource = _productoVista.Where(m=>m.Visible ==true).ToList();
                    _prenda.DataBind();
                    _envioMatriz.Checked = false;
                    _envioMatriz.Enabled = true;

                }
                _talla.DataSource =
                        _servicioDelegadoInventario.ObtenProductoTallaPorProductoId(
                            Convert.ToInt32(_prenda.SelectedItem.Value));
                _talla.DataBind();
                _cantidad.Text = "1";
                List<ProductoPrecioVistaModelo> _precio =
                    _servicioDelegadoInventario.ObtenerProductoPrecioPorProductoIdYProductoTallaId(
                        Convert.ToInt32(_prenda.SelectedItem.Value),
                        Convert.ToInt32(_talla.SelectedItem.Value));
                foreach (var productoPrecioVistaModelo in _precio)
                {

                    _valorUnitario.Text = String.Format("{0:0.00}", productoPrecioVistaModelo.Precio);
                }
                _valorTotal.Text = String.Format("{0:0.00}",
                    Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));
                EjecutarPromociones();

            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }

        }


        /// <summary>
        /// Gurada la orden de  trabajo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _grabarOrdenTrabajo_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ordenTrabajoVistaDtOs.DetalleOrdenTrabajo.Count <= 20)
                {
                    if (_valorPago.Text == String.Empty)
                        _valorPago.Text = "0";

                    if (_listaTrabajoVistaDtOs.Sum(m => m.ValorTotal) >=Convert.ToDecimal(_valorPago.Text)  )
                    {
                        if (ValidacionNumeroPrendas(_ordenTrabajoVistaDtOs.DetalleOrdenTrabajo) == true)
                        {
                       
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
                        string numeroOrden= _servicioDelegadoVenta.GrabarTransaccionInicialCompleta(_ordenTrabajoVistaDtOs);
                        
                        Session["OrdenTrabajoId"] = numeroOrden;
                        Response.Redirect("~/Reporte/ReporteImpresionRapida.aspx");
                        }
                        else
                            Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Numero_Prendas_No_Coincide").ToString(),
                              "_grabarOrdenTrabajo");
                    }
                    else
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Valor_Abono_Mayo_PagoTotal").ToString(),
                           "_grabarOrdenTrabajo");
                }
                else
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Mayor_Veinte_Prendas").ToString(),
                        "_grabarOrdenTrabajo");




            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }
        }

        /// <summary>
        /// Valor total 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _cantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {

                EjecutarPromociones();
                
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }
        }

        /// <summary>
        /// Carga las tallas de las prendas 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _prenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                _talla.DataSource =
                    _servicioDelegadoInventario.ObtenProductoTallaPorProductoId(
                        Convert.ToInt32(_prenda.SelectedItem.Value));
                _talla.DataBind();
                List<ProductoPrecioVistaModelo> _precio =
               _servicioDelegadoInventario.ObtenerProductoPrecioPorProductoIdYProductoTallaId(
                   Convert.ToInt32(_prenda.SelectedItem.Value),
                   Convert.ToInt32(_talla.SelectedItem.Value));
                foreach (var productoPrecioVistaModelo in _precio)
                {

                    _valorUnitario.Text = String.Format("{0:0.00}", productoPrecioVistaModelo.Precio);
                }

                if (Convert.ToInt32(_prenda.SelectedItem.Value) == Convert.ToInt32(Util.LavadoPorLibras.LavadoPorLibras))
                {
                    _suavizante.Visible = true;
                    _desengrasante.Visible = true;
                    _fijadorColor.Visible = true;

                  
                }
                else
                {
                    _suavizante.Visible = false;
                    _desengrasante.Visible = false;
                    _fijadorColor.Visible = false;

                }
                _suavizante.Checked = false;
                _desengrasante.Checked = false;
                _fijadorColor.Checked = false;
                EjecutarPromociones();

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }
        }

        /// <summary>
        /// Carga los precios  de las prendas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _talla_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                List<ProductoPrecioVistaModelo> _precio =
               _servicioDelegadoInventario.ObtenerProductoPrecioPorProductoIdYProductoTallaId(
                   Convert.ToInt32(_prenda.SelectedItem.Value),
                   Convert.ToInt32(_talla.SelectedItem.Value));
                foreach (var productoPrecioVistaModelo in _precio)
                {

                    _valorUnitario.Text = String.Format("{0:0.00}", productoPrecioVistaModelo.Precio);
                }
                _valorTotal.Text = String.Format("{0:0.00}", Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));



            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }

        }

        /// <summary>
        /// Envia a la creacion del cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnCrearCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Individuo/Cliente.aspx");
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }
        }

        /// <summary>
        /// Agrega la orden de  trabajo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnAgregarDetalleOrdenTrabajo_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarOrdenTrabajo();
                CargarDetalleOrdenTrabajo();
                LimpiarDetalleOrdenTrabajo();
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }

        }

        /// <summary>
        /// Carga los datos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    InicializarVariables();
                    CargarDatos();

                   
                }
            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }

        }

        /// <summary>
        /// Retorna a la pagina por defecto
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
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnBusquedaCliente_Click(object sender, EventArgs e)
        {
            try
            {

                if (_tipoBusqueda.SelectedItem.Value=="1")
                clienteVistaDtOs =
                   _servicioDelegadoIndividuo.ObtenerDatosClientePorNumeroIdentificacion(_numeroDocumentoBusqueda.Text.ToUpper());
                else
                {
                    listaClienteVistaDtOses= _servicioDelegadoIndividuo.ObtenerDatosClientePorApellidos(_numeroDocumentoBusqueda.Text.ToUpper(), _parametroDos.Text.ToUpper());

                    if (listaClienteVistaDtOses.Count>0)
                    { 
                    _clientes.DataSource = listaClienteVistaDtOses;
                    _clientes.DataBind();
                    _btnCliente_ModalPopupExtender.TargetControlID = "_grabarOrdenTrabajo";
                    _btnCliente_ModalPopupExtender.Show();
                    }
                    else
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Cliente_No_Existe").ToString(), "_grabarOrdenTrabajo");
                }

                if (clienteVistaDtOs != null)
                {
                    _cliente.Text = clienteVistaDtOs.NombreCompleto;
                    _direccion.Text = clienteVistaDtOs.DireccionCliente;
                    _telefono.Text = clienteVistaDtOs.TelefonoCliente;
                }
                else
                {
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Cliente_No_Existe").ToString(), "_grabarOrdenTrabajo");
                }
            }
            catch (Exception ex)
            {
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }
        }

        #endregion
        
        #region  metodos

        /// <summary>
        /// Limpia los controles 
        /// </summary>
        public void LimpiarControles()
        {
            try
            {
                _numeroDocumentoBusqueda.Text = string.Empty;


            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
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
        /// Inicializa las variables 
        /// </summary>
        private void InicializarVariables()
        {

           
            _ordenTrabajoVistaDtOs = new OrdenTrabajoVistaDTOs();
            clienteVistaDtOs = new ClienteVistaDTOs();
            _listaTrabajoVistaDtOs = new List<DetalleOrdenTrabajoVistaModelo>();
            _productoVista= new  List<ProductoVistaModelo>();

        }

        /// <summary>
        /// Carga los detalles de  los diferentes tipos de  lavado
        /// </summary>
        private void CargarDatosDetalle()
        {
            try
            {
                List<ProductoVistaModelo> _productoVista = _servicioDelegadoInventario.ObtenerProductoPorTipoProductoId(Convert.ToInt32(Util.TipoProducto.Servicio));
                if (Convert.ToInt32(_tipoLavado.SelectedItem.Value) == Convert.ToInt32(Util.TipoLavado.LavadoSeco))
                {
                    _prenda.DataSource = _productoVista;
                    _prenda.DataBind();


                }
                else if (Convert.ToInt32(_tipoLavado.SelectedItem.Value) ==
                         Convert.ToInt32(Util.TipoLavado.LavadoPorLibras))
                {
                    _prenda.DataSource = _productoVista.Where(m => m.Visible == true).ToList();
                    _prenda.DataBind();


                }
                _talla.DataSource =
                    _servicioDelegadoInventario.ObtenProductoTallaPorProductoId(
                        Convert.ToInt32(_prenda.SelectedItem.Value));
                _talla.DataBind();
                _cantidad.Text = "1";
                EjecutarPromociones();
              

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Carga los datos de la pagina web
        /// </summary>
        private void CargarDatos()
        {
            try
            {
                _fecha.Text = DateTime.Now.ToShortDateString();
                _fechaEntrega.Text = DateTime.Now.AddDays(2).ToShortDateString();
                _sucursal.Text = User.NombrePuntoVenta;
                _usuario.Text = User.NombreUsuario;
                _tipoLavado.DataSource = _servicioDelegadoGeneral.ObtenerTiposLavado();
                _tipoLavado.DataBind();
                _estadoPago.DataSource = _servicioDelegadoGeneral.ObtenerEstadosPago();
                _estadoPago.DataBind();
                _estadoPago.SelectedIndex = _estadoPago.Items.IndexOf(_estadoPago.Items.FindByValue("1"));
                _labelValorPago.Visible = false;
                _valorPago.Visible = false;
                _productoVista = _servicioDelegadoInventario.ObtenerProductoPorTipoProductoId(Convert.ToInt32(Util.TipoProducto.Servicio));
                _prenda.DataSource = _productoVista;
                _prenda.DataBind();

                _talla.DataSource =
                        _servicioDelegadoInventario.ObtenProductoTallaPorProductoId(
                            Convert.ToInt32(_prenda.SelectedItem.Value));
                _talla.DataBind();
                 _cantidad.Text = "1";
                List<ProductoPrecioVistaModelo> _precio = _servicioDelegadoInventario.ObtenerProductoPrecioPorProductoIdYProductoTallaId(Convert.ToInt32(_prenda.SelectedItem.Value), Convert.ToInt32(_talla.SelectedItem.Value));
                    foreach (var productoPrecioVistaModelo in _precio)
                    {
                        _valorUnitario.Text = String.Format("{0:0.00}", productoPrecioVistaModelo.Precio);
                    }
                    _valorTotal.Text = String.Format("{0:0.00}",Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));
                  EjecutarPromociones();
                _envioMatriz.Checked = true;
                _envioMatriz.Enabled = false;
                _tipoEntrega.DataSource = _servicioDelegadoGeneral.ObtenerEntregaUrgencias();
                _tipoEntrega.DataBind();
                bool fechaBloqueada =
                 Convert.ToBoolean(_servicioDelegadoGeneral.ObtenerParametroPorDescripcion("BLOQUEAR_FECHA_ENTREGA").Boolenao);

                if (fechaBloqueada == true)
                    _fechaEntrega.ReadOnly = true;
                else
                    _fechaEntrega.ReadOnly = false;

                _tipoBusqueda.DataSource = _colecciones.ObtenerTipoDocumentos();
                _tipoBusqueda.DataBind();
                _tipoBusqueda.SelectedIndex = _tipoBusqueda.Items.IndexOf(_tipoBusqueda.Items.FindByValue("-1"));
                _numeroDocumentoBusqueda.Text = String.Empty;
                _numeroDocumentoBusqueda.ReadOnly = true;

                _parametroDos.Text = String.Empty;
                _parametroDos.ReadOnly = true;



            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }

        }

        /// <summary>
        /// Ejecuta promociones en seco
        /// </summary>
        private void EjecutarPromociones()
        {
            try
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

                _descuento.Text = parametroSalidaReglaNegocio.ValorDescuento.ToString();
                _valorTotalPagar.Text = parametroSalidaReglaNegocio.ValorTotalPagar.ToString();
                _valorTotal.Text = String.Format("{0:0.00}", parametroSalidaReglaNegocio.ValorTotal);
                _promocionAplicada.Text = parametroSalidaReglaNegocio.NombrePromocion;
                _promocionId.Value = parametroSalidaReglaNegocio.PromocionId.ToString();
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
                  Convert.ToInt32( _servicioDelegadoGeneral.ObtenerParametroPorDescripcion("NUMERO_URGENTES").NumeroEntero);
                int cantidadRealizadaDia= _servicioDelegadoVenta.ObtenerNumeroEntregaUrgentesPorFechaActual(Convert.ToInt32(User.PuntoVentaId));

                if (cantidadRealizadaDia <  cantidadEntregaUrgenciaParametrizada || Convert.ToInt32(_tipoEntrega.SelectedItem.Value)!=2)
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
                    EntregaUrgencia = _entregaUrgencia


                };
                _ordenTrabajoVistaDtOs.OrdenTrabajo = _ordenTrabajoVista;


                DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVista = new DetalleOrdenTrabajoVistaModelo();

               

               
                    ProductoVistaModelo _productoVista = new ProductoVistaModelo
                {
                    ProductoId = Convert.ToInt32(_prenda.SelectedItem.Value),
                    Nombre = _prenda.SelectedItem.Text.ToUpper(),
                    NumeroPrendas = 2

                };
                ProductoTallaVistaModelo _productoTallaVista = new ProductoTallaVistaModelo
                {
                    ProductoTallaId = Convert.ToInt32(_talla.SelectedItem.Value),
                    Descripcion = _talla.SelectedItem.Text.ToUpper()
                    
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
                _detalleOrdenTrabajoVista.ProductoTalla = _productoTallaVista;

                

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
                    List<ProductoVistaModelo> _listaPrendas= _servicioDelegadoInventario.ObtenerProductoPorTipoProductoId(Convert.ToInt32(Util.TipoProducto.Servicio));
                    foreach (var detalleOrdenTrabajoVista in _listaTrabajoVistaDtOs)
                    {
                        ProductoVistaModelo productoVistaModelo = _listaPrendas.FirstOrDefault(m => m.ProductoId.Equals(Convert.ToInt32(detalleOrdenTrabajoVista.Producto.ProductoId)));
                                

                        if (detalleOrdenTrabajoVista.Producto.ProductoId ==Convert.ToInt32(productoVistaModelo.ProductoId))
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
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Prenda_Especial").ToString(), "_grabarOrdenTrabajo");
                    DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVistaa = _listaTrabajoVistaDtOs.Find(m => m.Producto.Nombre == _nombreMarca.Value.ToString());
                    _listaTrabajoVistaDtOs.RemoveAt(_listaTrabajoVistaDtOs.Count-1);
                }

                    Validacion _validacion= new Validacion();

                    _fechaEntrega.Text = DateTime.Now.AddDays(maximoDias + _validacion.CalculoDias()).ToShortDateString();

                }
                else
                {
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Numero_Prenda_Urgente").ToString(), "_grabarOrdenTrabajo");

                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Encera  todos los controles de detalle de  orden de trabajo
        /// </summary>
        private void LimpiarDetalleOrdenTrabajo()
        {
            try
            {
                _cantidad.Text = String.Empty;
                CargarDatosDetalle();
                _valorUnitario.Text = String.Empty;
                _valorTotal.Text = String.Empty;
                _cantidad.Text = "1";
                _descuento.Text= String.Empty;
                _valorTotalPagar.Text= String.Empty;
                _promocionAplicada.Text=String.Empty;
                _promocionId.Value = string.Empty;


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


        #endregion

       
    }
}