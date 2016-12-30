
#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Base;
using Web.DTOs.Individuo;
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

        #endregion

        #region Eventos

        /// <summary>
        /// valida  si la orden de trabajo ya fue  ingresada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _numeroOrden_TextChanged(object sender, EventArgs e)
        {
            try
            {

                List<ConsultaOrdenTrabajoVistaDTOs> _listaConsultaOrdenTrabajoVistaDtOses =
                    _servicioDelegadoVenta.ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(_numeroOrden.Text,
                        Convert.ToInt32(User.PuntoVentaId));
                if (_listaConsultaOrdenTrabajoVistaDtOses.Count > 0)
                { 
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Numero_Orden_Existe").ToString(), "_grabarOrdenTrabajo");
                    _numeroOrden.Text=String.Empty;
                    _numeroOrden.Focus();

                }


            }
            catch (Exception ex)
            {
                
                throw;
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
                    _valorTotal.Text = String.Format("{0:0.00}", Convert.ToDecimal(_cantidad.Text) * Convert.ToDecimal(_valorUnitario.Text));

                }


                else
                    _panelLavadoSeco.Visible = false;
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

                List<ConsultaOrdenTrabajoVistaDTOs> _listaConsultaOrdenTrabajoVistaDtOses =
                   _servicioDelegadoVenta.ObtenerOrdenTrabajoPorNumeroOrdenYPuntoVenta(_numeroOrden.Text,
                       Convert.ToInt32(User.PuntoVentaId));
                if (_listaConsultaOrdenTrabajoVistaDtOses.Count > 0)
                {
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Numero_Orden_Existe").ToString(), "_grabarOrdenTrabajo");
                    _numeroOrden.Text = String.Empty;
                    _numeroOrden.Focus();

                }
                else
                {
                    _ordenTrabajoVistaDtOs.OrdenTrabajo.NumeroOrden = _numeroOrden.Text;

                    //Graba la Orden de trabajo
                    OrdenTrabajoVistaModelo _ordenTrabajoVistaModelo = _servicioDelegadoVenta.GrabarOrdenTrabajoCompleta(_ordenTrabajoVistaDtOs);

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
                    _historialProcesoVista.NumeroOrden = _ordenTrabajoVistaModelo.NumeroOrden;
                    _servicioDelegadoFlujoProceso.GrabarHistorialProceso(_historialProcesoVista);


                    CuentaPorCobrarVistaModelo _cuentaPorCobrarVista= new CuentaPorCobrarVistaModelo();
                    _cuentaPorCobrarVista.SucursalId = User.SucursalId;
                    _cuentaPorCobrarVista.PuntoVentaId = User.PuntoVentaId;
                    _cuentaPorCobrarVista.ClienteId = _ordenTrabajoVistaModelo.ClienteModelo.ClienteId;
                    _cuentaPorCobrarVista.FechaCreacion= DateTime.Now;
                    _cuentaPorCobrarVista.FechaModificacion= DateTime.Now;
                    _cuentaPorCobrarVista.FechaVencimiento = _ordenTrabajoVistaModelo.FechaEntrega;
                    _cuentaPorCobrarVista.NumeroFactura= String.Empty;
                    _cuentaPorCobrarVista.NumeroOrden = _ordenTrabajoVistaModelo.NumeroOrden;
                    _cuentaPorCobrarVista.Saldo = 0;
                    _cuentaPorCobrarVista.Valor = _ordenTrabajoVistaDtOs.DetalleOrdenTrabajo.Sum(m => m.ValorTotal);
                    _cuentaPorCobrarVista.UsuarioModificacionId = User.Id;
                    _cuentaPorCobrarVista.UsuarioCreacionId = User.Id;
                    _cuentaPorCobrarVista.EstadoPagoId = _ordenTrabajoVistaModelo.EstadoPago.EstadoPagoId;

                    _cuentaPorCobrarVista = _servicioDelegadoContabilidad.GrabarCuentaPorCobrar(_cuentaPorCobrarVista);

                    if (_ordenTrabajoVistaModelo.EstadoPago.EstadoPagoId == Convert.ToInt32(Util.EstadoPago.Cancelado))
                    {
                        HistorialCuentaPorCobrarVistaModelo _historialCuentaPorCobrar = new HistorialCuentaPorCobrarVistaModelo();
                        _historialCuentaPorCobrar.UsuarioId = User.Id;
                        _historialCuentaPorCobrar.CuentaPorCobrarId = _cuentaPorCobrarVista.CuentaPorCobrarId;
                        _historialCuentaPorCobrar.FechaCobro=DateTime.Now;
                        _historialCuentaPorCobrar.ValorCobro= _ordenTrabajoVistaDtOs.DetalleOrdenTrabajo.Sum(m => m.ValorTotal);

                        _historialCuentaPorCobrar =
                            _servicioDelegadoContabilidad.GrabarHistorialCuentaPorCobrar(_historialCuentaPorCobrar);

                    }
                    //Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Exitoso").ToString(), "_grabarOrdenTrabajo");
                    Response.Redirect("~/Inicio/Default.aspx");
                }
                

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
                _material.DataSource = _servicioDelegadoGeneral.ObtenerMateriales();
                _material.DataBind();
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
                _material.DataSource = _servicioDelegadoGeneral.ObtenerMateriales();
                _material.DataBind();
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
                    FechaEntrega = DateTime.Now,
                    FechaIngreso = DateTime.Now,
                    EstadoPago = _estadoPagoVista,
                    TipoLavado = _tipoLavadoVista,
                    Usuario = _usuarioVista,
                    Sucursal = _sucursalVista,
                    PuntoVenta = _puntoVentaVista,
                    ClienteModelo = _clienteVista,
                    NumeroOrden = _numeroOrden.Text


                };
                _ordenTrabajoVistaDtOs.OrdenTrabajo = _ordenTrabajoVista;


                DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVista = new DetalleOrdenTrabajoVistaModelo();

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
                    MaterialId = Convert.ToInt32(_material.SelectedItem.Value),
                    Descripcion = _material.SelectedItem.Text
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