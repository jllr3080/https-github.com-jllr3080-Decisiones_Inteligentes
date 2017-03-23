
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
#endregion
namespace Web.Venta
{
    public partial class OrdenTrabajo : PaginaBase
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly ServicioDelegadoLogistica _servicioDelegadoLogistica = new ServicioDelegadoLogistica();
        private readonly  ServicioDelegadoContabilidad _servicioDelegadoContabilidad= new ServicioDelegadoContabilidad();
        private readonly ServicioDelegadoIndividuo _servicioDelegadoIndividuo = new ServicioDelegadoIndividuo();
        private readonly ServicioDelegadoInventario _servicioDelegadoInventario = new ServicioDelegadoInventario();
        private readonly ServicioDelegadoVenta _servicioDelegadoVenta = new ServicioDelegadoVenta();
        private readonly ServicioDelegadoGeneral _servicioDelegadoGeneral = new ServicioDelegadoGeneral();
        private readonly  ServicioDelegadoFlujoProceso _servicioDelegadoFlujoProceso= new ServicioDelegadoFlujoProceso();
        private static OrdenTrabajoVistaDTOs _ordenTrabajoVistaDtOs = new OrdenTrabajoVistaDTOs();
        private static ClienteVistaDTOs clienteVistaDtOs = new ClienteVistaDTOs();
        private static List<DetalleOrdenTrabajoVistaModelo> _listaTrabajoVistaDtOs =
            new List<DetalleOrdenTrabajoVistaModelo>();
        private readonly  ServicioDelegadoReglaNegocio _servicioDelegadoReglaNegocio= new ServicioDelegadoReglaNegocio();

        #endregion

        #region Eventos


        /// <summary>
        /// Agrega el reporte por libras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _agregarRopaPorLibras_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarOrdenTrabajo();
                CargarDetalleOrdenTrabajoPorLibras();
                LimpiarDetalleOrdenTrabajoPorLibras();

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }
        }

        /// <summary>
        /// Prenda 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _prendaPorLibras_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _cantidadPorLibras.Text = "1";
                _tallaPorLibras.DataSource =_servicioDelegadoInventario.ObtenProductoTallaPorProductoId(Convert.ToInt32(_prendaPorLibras.SelectedItem.Value));
                _tallaPorLibras.DataBind();
                List<ProductoPrecioVistaModelo> _precio =_servicioDelegadoInventario.ObtenerProductoPrecioPorProductoIdYProductoTallaId(Convert.ToInt32(_prendaPorLibras.SelectedItem.Value),
                   Convert.ToInt32(_tallaPorLibras.SelectedItem.Value));
                foreach (var productoPrecioVistaModelo in _precio)
                {

                    _valorUnitarioPorLibras.Text = String.Format("{0:0.00}", productoPrecioVistaModelo.Precio);
                }

                _valorTotalPorLibras.Text = String.Format("{0:0.00}", Convert.ToDecimal(_cantidadPorLibras.Text) * Convert.ToDecimal(_valorUnitarioPorLibras.Text));
            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _tallaPorLibras_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<ProductoPrecioVistaModelo> _precio =_servicioDelegadoInventario.ObtenerProductoPrecioPorProductoIdYProductoTallaId(Convert.ToInt32(_prendaPorLibras.SelectedItem.Value),
                 Convert.ToInt32(_tallaPorLibras.SelectedItem.Value));
                foreach (var productoPrecioVistaModelo in _precio)
                {

                    _valorUnitarioPorLibras.Text = String.Format("{0:0.00}", productoPrecioVistaModelo.Precio);
                }
                _valorTotalPorLibras.Text = String.Format("{0:0.00}", Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitarioPorLibras.Text));

            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _numeroLibras_TextChanged(object sender, EventArgs e)
        {
            try
            {

                _valorTotalLibra.Text = String.Format("{0:0.00}",
                    Convert.ToDecimal(_numeroLibras.Text)*Convert.ToDecimal(_valorUnitarioLibra.Text));


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
        protected void _valorUnitarioLibra_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _valorTotalLibra.Text = String.Format("{0:0.00}",
                   Convert.ToDecimal(_numeroLibras.Text) * Convert.ToDecimal(_valorUnitarioLibra.Text));
            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }
        }
        /// <summary>
        /// Opcion de  libras   se visualiza  el panel de libras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _opcionLibras_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _panelLibras.Visible = true;
                _panelEdredones.Visible = false;
                _valorUnitarioLibra.Text = Convert.ToString(_servicioDelegadoGeneral.ObtenerParametroPorDescripcion("VALOR_LIBRA").NumeroDecimal);
                LimpiarDetalleOrdenTrabajoPorLibras();


            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }

        }

        /// <summary>
        /// Opcion de edredones se visualiza la opcion de edredones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _opcionEdredones_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _panelLibras.Visible = false;
                _panelEdredones.Visible = true;
                _prendaPorLibras.DataSource = _servicioDelegadoInventario.ObtenerProductoPorTipoProductoId(Convert.ToInt32(Util.TipoProducto.Servicio));
                _prendaPorLibras.DataBind();
                _tallaPorLibras.DataSource =
                    _servicioDelegadoInventario.ObtenProductoTallaPorProductoId(
                        Convert.ToInt32(_prenda.SelectedItem.Value));
                _tallaPorLibras.DataBind();
                _marcaPorLibras.DataSource = _servicioDelegadoGeneral.ObtenerMarcas();
                _marcaPorLibras.DataBind();
                _colorPorLibras.DataSource = _servicioDelegadoGeneral.ObetenerColores();
                _colorPorLibras.DataBind();
                _valorUnitarioLibra.Text =String.Empty;
                LimpiarDetalleOrdenTrabajoPorLibras();



            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }

        }

        /// <summary>
        /// Aplica las promociones 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _promocion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

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
                    _servicioDelegadoGeneral.ValidarSiExisteMarcaPorDescripcion(_txtMarca.Text);

                if (_validarMarcaVistaModelo == null)
                {
                    MarcaVistaModelo _marcaVistaModelo = new MarcaVistaModelo();
                    _marcaVistaModelo.Descripcion = _txtMarca.Text;
                    _marcaVistaModelo.EstaHabilitado = true;
                    _servicioDelegadoGeneral.GrabarMarca(_marcaVistaModelo);
                    _marca.DataSource = _servicioDelegadoGeneral.ObtenerMarcas();
                    _marca.DataBind();
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
                _btnMarca_ModalPopupExtender.TargetControlID = "_crearMarca";
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
                    _valorPago.Text = String.Format("{0:0.00}", _listaTrabajoVistaDtOs.Sum(m => m.ValorTotal));
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
        private int _cantidadTotal = 0;

        protected void _datos_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    _montoTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ValorTotal"));
                    _cantidadTotal += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Cantidad"));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[2].Text = "Totales:";
                    e.Row.Cells[3].Text = _cantidadTotal.ToString();
                    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;

                    e.Row.Cells[7].Text = _montoTotal.ToString();
                    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
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
                if (e.CommandName == "Eliminar")
                {
                  int index = Convert.ToInt32(e.CommandArgument);
                  _listaTrabajoVistaDtOs.RemoveAt(index);
                    if (Convert.ToInt32(_tipoLavado.SelectedItem.Value) == Convert.ToInt32(Util.TipoLavado.LavadoSeco))
                    {
                        _datos.DataSource = _listaTrabajoVistaDtOs;
                        _datos.DataBind();
                    }

                    else
                    {
                        _datosLibras.DataSource = _listaTrabajoVistaDtOs;
                        _datosLibras.DataBind();
                    }


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
                if (Convert.ToInt32(_tipoLavado.SelectedItem.Value) == Convert.ToInt32(Util.TipoLavado.LavadoSeco))
                {
                    _panelLavadoSeco.Visible = true;
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
                        Convert.ToDecimal(_cantidad.Text)*Convert.ToDecimal(_valorUnitario.Text));
                    _panelLavadoMojado.Visible = false;
                }
                else if (Convert.ToInt32(_tipoLavado.SelectedItem.Value) ==
                         Convert.ToInt32(Util.TipoLavado.LavadoPorLibras))
                {
                    _panelLavadoSeco.Visible = false;
                    _panelLavadoMojado.Visible = true;
                    
                }
                else
                {
                    _panelLavadoSeco.Visible = false;
                    _panelLavadoMojado.Visible = false;
                }

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

                        EstadoPagoVistaModelo _estadoPagoVista = new EstadoPagoVistaModelo
                        {
                            EstadoPagoId = Convert.ToInt32(_estadoPago.SelectedItem.Value)
                        };
                        _ordenTrabajoVistaDtOs.OrdenTrabajo.EstadoPago = _estadoPagoVista;
                        _ordenTrabajoVistaDtOs.OrdenTrabajo.SeEnvio = false;
                        _ordenTrabajoVistaDtOs.OrdenTrabajo.EnvioMatriz = true;
                        //Graba la Orden de trabajo
                        OrdenTrabajoVistaModelo _ordenTrabajoVistaModelo =
                            _servicioDelegadoVenta.GrabarOrdenTrabajoCompleta(_ordenTrabajoVistaDtOs);

                        //GUarda el proceso inicial que es la entrega del cliente hacia  la franquicia
                        HistorialProcesoVistaModelo _historialProcesoVista = new HistorialProcesoVistaModelo();
                        _historialProcesoVista.OrdenTrabajoId = _ordenTrabajoVistaModelo.OrdenTrabajoId;
                        EtapaProcesoVistaModelo _etapaProcesoVistaModelo = new EtapaProcesoVistaModelo();
                        _etapaProcesoVistaModelo.EtapaProcesoId =
                            Convert.ToInt32(Util.EtapaProceso.EntregaClienteHaciaFranquicia);
                        _historialProcesoVista.EtapaProceso = _etapaProcesoVistaModelo;
                        _historialProcesoVista.FechaRegistro = DateTime.Now;
                        _historialProcesoVista.FechaInicio = DateTime.Now;
                        _historialProcesoVista.FechaFin = DateTime.Now;
                        _historialProcesoVista.SucursalId = User.SucursalId;
                        _historialProcesoVista.PuntoVentaId = User.PuntoVentaId;
                        _historialProcesoVista.NumeroOrden = _ordenTrabajoVistaModelo.NumeroOrden;
                        _historialProcesoVista.UsuarioRecibeId = User.Id;
                        _historialProcesoVista.UsuarioEntregaId = User.Id;
                        _historialProcesoVista.PerfilId = User.PerfilId;
                        _historialProcesoVista.PasoPorEstaEtapa = false;
                        _servicioDelegadoFlujoProceso.GrabarHistorialProceso(_historialProcesoVista);

                        //Graba las cuentas por cobrar
                        CuentaPorCobrarVistaModelo _cuentaPorCobrarVista = new CuentaPorCobrarVistaModelo();
                        _cuentaPorCobrarVista.SucursalId = User.SucursalId;
                        _cuentaPorCobrarVista.PuntoVentaId = User.PuntoVentaId;
                        _cuentaPorCobrarVista.ClienteId = _ordenTrabajoVistaModelo.ClienteModelo.ClienteId;
                        _cuentaPorCobrarVista.FechaCreacion = DateTime.Now;
                        _cuentaPorCobrarVista.FechaModificacion = DateTime.Now;
                        _cuentaPorCobrarVista.FechaVencimiento = _ordenTrabajoVistaModelo.FechaEntrega;
                        _cuentaPorCobrarVista.NumeroFactura = String.Empty;
                        _cuentaPorCobrarVista.NumeroOrden = _ordenTrabajoVistaModelo.NumeroOrden;
                        _cuentaPorCobrarVista.Saldo = Convert.ToDecimal(_valorPago.Text);
                        _cuentaPorCobrarVista.Valor = _ordenTrabajoVistaDtOs.DetalleOrdenTrabajo.Sum(m => m.ValorTotal);
                        _cuentaPorCobrarVista.UsuarioModificacionId = User.Id;
                        _cuentaPorCobrarVista.UsuarioCreacionId = User.Id;
                        _cuentaPorCobrarVista.EstadoPagoId = _ordenTrabajoVistaModelo.EstadoPago.EstadoPagoId;

                        _cuentaPorCobrarVista =
                            _servicioDelegadoContabilidad.GrabarCuentaPorCobrar(_cuentaPorCobrarVista);

                        //if (_ordenTrabajoVistaModelo.EstadoPago.EstadoPagoId ==
                        //    Convert.ToInt32(Util.EstadoPago.Cancelado) ||
                        //    _ordenTrabajoVistaModelo.EstadoPago.EstadoPagoId == Convert.ToInt32(Util.EstadoPago.Abonado))
                        //{
                            HistorialCuentaPorCobrarVistaModelo _historialCuentaPorCobrar =
                                new HistorialCuentaPorCobrarVistaModelo();
                            _historialCuentaPorCobrar.UsuarioId = User.Id;
                            _historialCuentaPorCobrar.CuentaPorCobrarId = _cuentaPorCobrarVista.CuentaPorCobrarId;
                            _historialCuentaPorCobrar.FechaCobro = DateTime.Now;
                            FormaPagoVistaModelo _formaPago = new FormaPagoVistaModelo();
                            _formaPago.FormaPagoId = Convert.ToInt32(Util.FormaPago.Efectivo);
                            _historialCuentaPorCobrar.FormaPago = _formaPago;
                            _historialCuentaPorCobrar.ValorCobro = Convert.ToDecimal(_valorPago.Text);

                            _historialCuentaPorCobrar =_servicioDelegadoContabilidad.GrabarHistorialCuentaPorCobrar(_historialCuentaPorCobrar);

                        //}


                        //Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Exitoso").ToString(), "_grabarOrdenTrabajo");
                        Session["OrdenTrabajoId"] = _ordenTrabajoVistaModelo.NumeroOrden;
                        Response.Redirect("~/Reporte/ReporteImpresionOrden.aspx");
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
                _valorTotal.Text = String.Format("{0:0.00}", Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));


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
              
                _valorTotal.Text = String.Format("{0:0.00}", Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));

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

                    if (Convert.ToInt32(_tipoLavado.SelectedItem.Value) == Convert.ToInt32(Util.TipoLavado.LavadoSeco))
                    {
                        _panelLavadoSeco.Visible = true;
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
                        _panelLavadoMojado.Visible = false;
                    }
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
                clienteVistaDtOs =
                   _servicioDelegadoIndividuo.ObtenerDatosClientePorNumeroIdentificacion(_numeroDocumento.Text);

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
                _numeroDocumento.Text = string.Empty;


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

        }

        /// <summary>
        /// Carga los detalles de  los diferentes tipos de  lavado
        /// </summary>
        private void CargarDatosDetalle()
        {
            try
            {
                _prenda.DataSource = _servicioDelegadoInventario.ObtenerProductoPorTipoProductoId(Convert.ToInt32(Util.TipoProducto.Servicio));
                _prenda.DataBind();
                _talla.DataSource =
                    _servicioDelegadoInventario.ObtenProductoTallaPorProductoId(
                        Convert.ToInt32(_prenda.SelectedItem.Value));
                _talla.DataBind();
                //_material.DataSource = _servicioDelegadoGeneral.ObtenerMateriales();
                //_material.DataBind();
                _marca.DataSource = _servicioDelegadoGeneral.ObtenerMarcas();
                _marca.DataBind();
                _color.DataSource = _servicioDelegadoGeneral.ObetenerColores();
                _color.DataBind();



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
                _prenda.DataSource = _servicioDelegadoInventario.ObtenerProductoPorTipoProductoId(Convert.ToInt32(Util.TipoProducto.Servicio));
                _prenda.DataBind();
                _talla.DataSource =
                    _servicioDelegadoInventario.ObtenProductoTallaPorProductoId(
                        Convert.ToInt32(_prenda.SelectedItem.Value));
                _talla.DataBind();
                //_material.DataSource = _servicioDelegadoGeneral.ObtenerMateriales();
                //_material.DataBind();
                _marca.DataSource = _servicioDelegadoGeneral.ObtenerMarcas();
                _marca.DataBind();
                _color.DataSource = _servicioDelegadoGeneral.ObetenerColores();
                _color.DataBind();
                _sucursal.Text = User.NombrePuntoVenta;
                _usuario.Text = User.NombreUsuario;
                _tipoLavado.DataSource = _servicioDelegadoGeneral.ObtenerTiposLavado();
                _tipoLavado.DataBind();
                _estadoPago.DataSource = _servicioDelegadoGeneral.ObtenerEstadosPago();
                _estadoPago.DataBind();
                _estadoPago.SelectedIndex = _estadoPago.Items.IndexOf(_estadoPago.Items.FindByValue("1"));
                _labelValorPago.Visible = false;
                _valorPago.Visible = false;
                _promocion.DataSource =
                _servicioDelegadoReglaNegocio.ObtenerReglasPorPuntoVentaIdYSucursalId(
                       Convert.ToInt32(User.PuntoVentaId), Convert.ToInt32(User.SucursalId));
                _promocion.DataBind();
                ListItem _listItem= new ListItem();
                _listItem.Value = "-1";
                _listItem.Text = "NINGUNA";
                _listItem.Selected = true;
                
                _promocion.Items.Add(_listItem);

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarOrdenTrabajo");
            }

        }

        /// <summary>
        /// Carga la  orden de trabajo
        /// </summary>
        private void AgregarOrdenTrabajo()
        {
            try
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
                    NumeroOrden = "0"


                };
                _ordenTrabajoVistaDtOs.OrdenTrabajo = _ordenTrabajoVista;


                DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVista = new DetalleOrdenTrabajoVistaModelo();

                if ((Convert.ToInt32(_tipoLavado.SelectedItem.Value) == Convert.ToInt32(Util.TipoLavado.LavadoPorLibras) &&
                     _opcionEdredones.Checked == true) ||
                    (Convert.ToInt32(_tipoLavado.SelectedItem.Value) == Convert.ToInt32(Util.TipoLavado.LavadoSeco)))
                {
                    
               
                ProductoVistaModelo _productoVista = new ProductoVistaModelo
                {
                    ProductoId = Convert.ToInt32(_prenda.SelectedItem.Value),
                    Nombre = _prenda.SelectedItem.Text

                };
                ProductoTallaVistaModelo _productoTallaVista = new ProductoTallaVistaModelo
                {
                    ProductoTallaId = Convert.ToInt32(_talla.SelectedItem.Value),
                    Descripcion = _talla.SelectedItem.Text
                };
                MarcaVistaModelo _marcaVista = new MarcaVistaModelo
                {
                    MarcaId = Convert.ToInt32(_marca.SelectedItem.Value),
                    Descripcion = _marca.SelectedItem.Text

                };
                MaterialVistaModelo _materialVista = new MaterialVistaModelo
                {
                    MaterialId = Convert.ToInt32(1)
                    //Descripcion = _material.SelectedItem.Text
                };
                ColorVistaModelo _colorVista = new ColorVistaModelo
                {
                    ColorId = Convert.ToInt32(_color.SelectedItem.Value),
                    Descripcion = _color.SelectedItem.Text
                };
                ImpuestoVistaModelo _impuestoVista = new ImpuestoVistaModelo
                {
                    ImpuestoId = 1
                };
                VentaComisionVistaModelo _ventaComisionVista = new VentaComisionVistaModelo
                {
                    VentaComisionId = 1
                };
                List<DetalleOrdenTrabajoObservacionVistaModelo> _listaDetalleOrdenTrabajoObservacion= new List<DetalleOrdenTrabajoObservacionVistaModelo>();
                DetalleOrdenTrabajoObservacionVistaModelo _detalleOrdenTrabajoObservacion= new DetalleOrdenTrabajoObservacionVistaModelo();
                _detalleOrdenTrabajoObservacion.UsuarioId = User.Id;
                _detalleOrdenTrabajoObservacion.FechaCreacionObservacion = DateTime.Now;
                _detalleOrdenTrabajoObservacion.Observacion = _observacion.Text;
                _listaDetalleOrdenTrabajoObservacion.Add(_detalleOrdenTrabajoObservacion);
                _detalleOrdenTrabajoVista.Producto = _productoVista;
                _detalleOrdenTrabajoVista.ProductoTalla = _productoTallaVista;
                _detalleOrdenTrabajoVista.Marca = _marcaVista;
                _detalleOrdenTrabajoVista.Material = _materialVista;
                _detalleOrdenTrabajoVista.Color = _colorVista;
                _detalleOrdenTrabajoVista.Cantidad = Convert.ToInt32(_cantidad.Text);
                _detalleOrdenTrabajoVista.ValorUnitario = Convert.ToDecimal(_valorUnitario.Text);
                _detalleOrdenTrabajoVista.ValorTotal = Convert.ToDecimal(_valorTotal.Text);
                _detalleOrdenTrabajoVista.Observacion = _observacion.Text;
                _detalleOrdenTrabajoVista.Impuesto = _impuestoVista;
                _detalleOrdenTrabajoVista.OrdenTrabajo = _ordenTrabajoVista;
                _detalleOrdenTrabajoVista.VentaComision = _ventaComisionVista;
                _detalleOrdenTrabajoVista.PorcentajeImpuesto = 14;
                _detalleOrdenTrabajoVista.DetalleOrdenTrabajoObservacion = _listaDetalleOrdenTrabajoObservacion;
                _detalleOrdenTrabajoVista.TratamientoEspecial = _tratamientoEspecial.Text;
                _detalleOrdenTrabajoVista.NumeroInternoPrenda = _numeroInterno.Text;
                }
                //Lavado en Mojado
                if (Convert.ToInt32(_tipoLavado.SelectedItem.Value) == Convert.ToInt32(Util.TipoLavado.LavadoPorLibras))
                {
                    if (_opcionLibras.Checked==true)
                    {
                        ProductoVistaModelo _productoVista = new ProductoVistaModelo
                        {
                            ProductoId   = 172,
                            Nombre = "LAVADO POR LIBRAS"

                        };

                        _detalleOrdenTrabajoVista.NumeroLibras = Convert.ToDecimal(_numeroLibras.Text);
                    _detalleOrdenTrabajoVista.Suavizante =Convert.ToBoolean( _suavizante.Checked);
                    _detalleOrdenTrabajoVista.Desengrasante = Convert.ToBoolean(_desengrasante.Checked);
                    _detalleOrdenTrabajoVista.FijadorColor = Convert.ToBoolean(_fijadorColor.Checked);
                    _detalleOrdenTrabajoVista.ValorUnitario = Convert.ToDecimal(_valorUnitarioLibra.Text);
                    _detalleOrdenTrabajoVista.ValorTotal= Convert.ToDecimal(_valorTotalLibra.Text);
                    _detalleOrdenTrabajoVista.Cantidad = Convert.ToInt32(_numeroLibras.Text);
                        _detalleOrdenTrabajoVista.Producto = _productoVista;
                    }



                }


                _listaTrabajoVistaDtOs.Add(_detalleOrdenTrabajoVista);
                _ordenTrabajoVistaDtOs.DetalleOrdenTrabajo = _listaTrabajoVistaDtOs;






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
                _observacion.Text = String.Empty;
                _cantidad.Text = "1";

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Encera  todos los controles de detalle de  orden de trabajo
        /// </summary>
        private void LimpiarDetalleOrdenTrabajoPorLibras()
        {
            try
            {
                _cantidadPorLibras.Text = String.Empty;
                CargarDatosDetalle();
                _valorUnitarioPorLibras.Text = String.Empty;
                _valorTotalPorLibras.Text = String.Empty;
                _estadoPrendaPorLibras.Text = String.Empty;
                _tratamientoEspecialPorLibras.Text = String.Empty;
                _numeroInternoPorLibras.Text = String.Empty;
                _informacionVisualPorLibras.Text = String.Empty;
                _cantidadPorLibras.Text = "1";
                _valorUnitarioLibra.Text=String.Empty;
                _valorTotalLibra.Text=String.Empty;
                _suavizante.Checked = false;
                _desengrasante.Checked = false;
                _fijadorColor.Checked = false;
                _numeroLibras.Text = "1";



            }
            catch (Exception ex)
            {

                throw;
            }

        }


        /// <summary>
        /// Carga el detalle de la orden de trabajo
        /// </summary>
        private void CargarDetalleOrdenTrabajoPorLibras()
        {
            try
            {
                _datosLibras.DataSource = _ordenTrabajoVistaDtOs.DetalleOrdenTrabajo;
                _datosLibras.DataBind();


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