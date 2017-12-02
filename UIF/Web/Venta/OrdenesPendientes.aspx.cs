#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Inventario;
using Web.Base;
using Web.DTOs.Venta;
using Web.Models.Venta.Negocio;
using Web.ServicioDelegado;
using ServicioDelegadoInventario = JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado.ServicioDelegadoInventario;

#endregion
namespace Web.Venta
{
    public partial class OrdenesPendientes : PaginaBase
    {


        #region Declaraciones  e  Instancias

        private readonly ServicioDelegadoVenta _servicioDelegadoVenta= new ServicioDelegadoVenta();
        private static List<OrdenTrabajoVistaDTOs> _listaOrdenTrabajoVistaDtOses = null;
        
        private readonly ServicioDelegadoGeneral _servicioDelegadoGeneral = new ServicioDelegadoGeneral();
        private readonly ServicioDelegadoInventario _servicioDelegadoInventario = new ServicioDelegadoInventario();
        private readonly ServicioDelegadoReglaNegocio _servicioDelegadoReglaNegocio= new ServicioDelegadoReglaNegocio();
        #endregion

        #region Eventos

        /// <summary>
        /// Visualiza  si las prendas esta completo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVista = _listaOrdenTrabajoVistaDtOses.Where(a => a.OrdenTrabajo.NumeroOrden.Equals(_ordenPendiente.SelectedItem.Text)).Select(m => m.DetalleOrdenTrabajo).FirstOrDefault().Find((m => m.Producto.Nombre == DataBinder.Eval(e.Row.DataItem, "Producto.Nombre").ToString()));
                    if (_detalleOrdenTrabajoVista != null)
                    {
                        ProductoVistaModelo _productoVista = _servicioDelegadoInventario.ObtenerProductoPorId(_detalleOrdenTrabajoVista.Producto.ProductoId);
                        _numeroPrendas.Text = String.Format("{0:0}", _productoVista.NumeroPrendas * _detalleOrdenTrabajoVista.Cantidad);
                        if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Cantidad")) == _detalleOrdenTrabajoVista.DetallePrendaOrdenTrabajo.Count)
                            e.Row.BackColor = System.Drawing.Color.Green;
                    }







                }
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarDetalleReal");
            }
        }

        /// <summary>
        /// Se elimina las cuotas
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
                    DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVista = _listaOrdenTrabajoVistaDtOses.Where(a => a.OrdenTrabajo.NumeroOrden.Equals(_ordenPendiente.SelectedItem.Text)).Select(m => m.DetalleOrdenTrabajo).FirstOrDefault().Find((m => m.Producto.Nombre == _nombreMarca.Value.ToString()));
                    _detalleOrdenTrabajoVista.DetallePrendaOrdenTrabajo.RemoveAt(index);
                      _nombreMarca.Value = _datos.Rows[index].Cells[0].Text;

                    Panel Detalles = (Panel)_datos.Rows[index].Cells[9].FindControl("Detalles");
                    Detalles.Visible = true;
                    GridView _detalleCuotas = (GridView)Detalles.FindControl("_detalleCuotas");
                    DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVistaa = _listaOrdenTrabajoVistaDtOses.Where(a => a.OrdenTrabajo.NumeroOrden.Equals(_ordenPendiente.SelectedItem.Text)).Select(m => m.DetalleOrdenTrabajo).FirstOrDefault().Find((m => m.Producto.Nombre == _nombreMarca.Value.ToString()));
                    if (_detalleOrdenTrabajoVistaa != null)
                    {
                        _detalleCuotas.DataSource = _detalleOrdenTrabajoVistaa.DetallePrendaOrdenTrabajo;
                        _detalleCuotas.DataBind();
                    }

                    var lista = _listaOrdenTrabajoVistaDtOses.Where(a => a.OrdenTrabajo.NumeroOrden.Equals(_ordenPendiente.SelectedItem.Text)).Select(m => m.DetalleOrdenTrabajo).FirstOrDefault();

                    if (lista.Any())
                    {

                        foreach (var detalleOrdenTrabajo in lista)
                        {
                            detalleOrdenTrabajo.Producto.Nombre =
                                _servicioDelegadoInventario.ObtenerProductoPorId(detalleOrdenTrabajo.Producto.ProductoId)
                                    .Nombre;

                            if (detalleOrdenTrabajo.PromocionAplicada != 0)
                                detalleOrdenTrabajo.NombrePromocionAplicada =
                                    _servicioDelegadoReglaNegocio.ObtenerReglaPorId(
                                        Convert.ToInt32(detalleOrdenTrabajo.PromocionAplicada)).NombreRegla;
                            else
                                detalleOrdenTrabajo.NombrePromocionAplicada = "NINGUNA";


                        }
                    }
                    _datos.DataSource = lista;
                    _datos.DataBind();

                }
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarDetalleReal");
            }
        }

        /// <summary>
        /// Graba  el detalle  en temnporales
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

                
                DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVista = _listaOrdenTrabajoVistaDtOses.Where(a => a.OrdenTrabajo.NumeroOrden.Equals(_ordenPendiente.SelectedItem.Text)).Select(m => m.DetalleOrdenTrabajo).FirstOrDefault().Find((m => m.Producto.Nombre == _nombreMarca.Value.ToString()));
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

                var lista = _listaOrdenTrabajoVistaDtOses.Where(a => a.OrdenTrabajo.NumeroOrden.Equals(_ordenPendiente.SelectedItem.Text)).Select(m => m.DetalleOrdenTrabajo).FirstOrDefault();

                if (lista.Any())
                {

                    foreach (var detalleOrdenTrabajo in lista)
                    {
                        detalleOrdenTrabajo.Producto.Nombre =
                            _servicioDelegadoInventario.ObtenerProductoPorId(detalleOrdenTrabajo.Producto.ProductoId)
                                .Nombre;

                        if (detalleOrdenTrabajo.PromocionAplicada != 0)
                            detalleOrdenTrabajo.NombrePromocionAplicada =
                                _servicioDelegadoReglaNegocio.ObtenerReglaPorId(
                                    Convert.ToInt32(detalleOrdenTrabajo.PromocionAplicada)).NombreRegla;
                        else
                            detalleOrdenTrabajo.NombrePromocionAplicada = "NINGUNA";


                    }
                }
                _datos.DataSource = lista;
                _datos.DataBind();

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarDetalleReal");
            }
        }

        /// <summary>
        /// Carga  la informacion inicial  de  la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    CargaInicial();
                
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarDetalleReal");
            }
        }


        /// <summary>
        /// Selecciona  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _ordenPendiente_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               var lista=_listaOrdenTrabajoVistaDtOses.Where(a => a.OrdenTrabajo.NumeroOrden.Equals(_ordenPendiente.SelectedItem.Text)).Select(m => m.DetalleOrdenTrabajo).FirstOrDefault();

                if (lista.Any())
                {

                    foreach (var detalleOrdenTrabajo in lista)
                    {
                        detalleOrdenTrabajo.Producto.Nombre =
                            _servicioDelegadoInventario.ObtenerProductoPorId(detalleOrdenTrabajo.Producto.ProductoId)
                                .Nombre;

                        if (detalleOrdenTrabajo.PromocionAplicada != 0)
                            detalleOrdenTrabajo.NombrePromocionAplicada =
                                _servicioDelegadoReglaNegocio.ObtenerReglaPorId(
                                    Convert.ToInt32(detalleOrdenTrabajo.PromocionAplicada)).NombreRegla;
                        else
                            detalleOrdenTrabajo.NombrePromocionAplicada = "NINGUNA";


                    }
                }
                _datos.DataSource = lista;
                _datos.DataBind();
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarDetalleReal");
            }
        }

        /// <summary>
        /// Graba la informacion real y  actualiza  el estado  a  temporal  terminado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _grabarDetalleReal_OnClick(object sender, EventArgs e)
        {
            try
            {
                
                _servicioDelegadoVenta.GrabarDetallePrendaCompleto(_listaOrdenTrabajoVistaDtOses.Where(a => a.OrdenTrabajo.NumeroOrden.Equals(_ordenPendiente.SelectedItem.Text)).FirstOrDefault());
                CargaInicial();
                LimpiarControles();
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Exitoso").ToString(), "_grabarDetalleReal");

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_grabarDetalleReal");
            }
         
        }

        /// <summary>
        /// Metodo cuando  selecciona   editar  o ver resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "Agregar")
                {
                    _nombreMarca.Value = _datos.Rows[index].Cells[0].Text;
                    DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVista = _listaOrdenTrabajoVistaDtOses.Where(a => a.OrdenTrabajo.NumeroOrden.Equals(_ordenPendiente.SelectedItem.Text)).Select(m => m.DetalleOrdenTrabajo).FirstOrDefault().Find((m => m.Producto.Nombre == _nombreMarca.Value.ToString()));
                    ProductoVistaModelo _productoVista = _servicioDelegadoInventario.ObtenerProductoPorId(_detalleOrdenTrabajoVista.Producto.ProductoId);
                    _numeroPrendas.Text = String.Format("{0:0}", _productoVista.NumeroPrendas * _detalleOrdenTrabajoVista.Cantidad);
                    if (_detalleOrdenTrabajoVista.DetallePrendaOrdenTrabajo.Count<Convert.ToInt32(_numeroPrendas.Text)  )
                    { 

                        _btnDetalleOrden_ModalPopupExtender.TargetControlID = "_grabarDetalleReal";
                        _btnDetalleOrden_ModalPopupExtender.Show();
                        _colorDetalle.DataSource = _servicioDelegadoGeneral.ObetenerColores();
                        _colorDetalle.DataBind();
                        _marcaDetalle.DataSource = _servicioDelegadoGeneral.ObtenerMarcas();
                        _marcaDetalle.DataBind();
                        _estadoPrendaDetalle.Text = String.Empty;
                        _tratamientoEspecialDetalle.Text = String.Empty;
                        _informacionVisualDetalle.Text = String.Empty;
                        _observacion.Text=String.Empty;
                     
                    }
                    else
                        Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Numero_Prenda_Igual")?.ToString(), "_grabarDetalleReal");
                    




                }

                if (e.CommandName == "Visualizar")
                {
                    _nombreMarca.Value = _datos.Rows[index].Cells[0].Text;

                    Panel Detalles = (Panel)_datos.Rows[index].Cells[9].FindControl("Detalles");
                    Detalles.Visible = true;
                    GridView _detalleCuotas = (GridView)Detalles.FindControl("_detalleCuotas");
                    DetalleOrdenTrabajoVistaModelo _detalleOrdenTrabajoVistaa = _listaOrdenTrabajoVistaDtOses.Where(a => a.OrdenTrabajo.NumeroOrden.Equals(_ordenPendiente.SelectedItem.Text)).Select(m => m.DetalleOrdenTrabajo).FirstOrDefault().Find((m => m.Producto.Nombre == _nombreMarca.Value.ToString()));
                    if (_detalleOrdenTrabajoVistaa != null)
                    {
                        _detalleCuotas.DataSource = _detalleOrdenTrabajoVistaa.DetallePrendaOrdenTrabajo;
                        _detalleCuotas.DataBind();
                    }



                }

                if (e.CommandName == "EsconderVisualizar")
                {
                    Panel Detalles = (Panel)_datos.Rows[index].Cells[9].FindControl("Detalles");
                    Detalles.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema")?.ToString(), "_grabarDetalleReal");
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

        private void LimpiarControles()
        {
            _datos.DataSource = null;
            _datos.DataBind();
            _observacion.Text=String.Empty;
            _tratamientoEspecialDetalle.Text = String.Empty;
            _informacionVisualDetalle.Text=String.Empty;
            _estadoPrendaDetalle.Text=String.Empty;

        }

        /// <summary>
        /// Carga inicial
        /// </summary>

        private void CargaInicial()
        {
            try
            {
                _listaOrdenTrabajoVistaDtOses = _servicioDelegadoVenta.ObtenerOrdenTrabajoPorEstadoTemporal(Convert.ToInt32(User.PuntoVentaId));

                List<OrdenTrabajoSimple> _listaOrdenTrabajoSimples = new List<OrdenTrabajoSimple>();

                OrdenTrabajoSimple ordenTrabajoSimpleInicial = new OrdenTrabajoSimple();
                ordenTrabajoSimpleInicial.OrdenTrabajoId = -1;
                ordenTrabajoSimpleInicial.NumeroOrden = "SELECCIONE";
                _listaOrdenTrabajoSimples.Add(ordenTrabajoSimpleInicial);

                foreach (var orden in _listaOrdenTrabajoVistaDtOses)
                {
                    OrdenTrabajoSimple ordenTrabajoSimple = new OrdenTrabajoSimple();
                    ordenTrabajoSimple.NumeroOrden = orden.OrdenTrabajo.NumeroOrden;
                    ordenTrabajoSimple.OrdenTrabajoId = orden.OrdenTrabajo.OrdenTrabajoId;
                    _listaOrdenTrabajoSimples.Add(ordenTrabajoSimple);
                }

                _ordenPendiente.DataSource = _listaOrdenTrabajoSimples;
                _ordenPendiente.DataBind();
                _ordenPendiente.SelectedIndex =
                       _ordenPendiente.Items.IndexOf(
                           _ordenPendiente.Items.FindByValue("-1"));

               
            }
            catch (Exception ex)
            {
                    
                throw;
            }
        }

        #endregion

      

       
    }

    public class OrdenTrabajoSimple
    {
        public Int64 OrdenTrabajoId { get; set; }

        public  string NumeroOrden { get; set; }
    }
}