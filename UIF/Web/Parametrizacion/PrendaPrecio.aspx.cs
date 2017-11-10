#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Inventario;
using Web.Base;

#endregion
namespace Web.Parametrizacion
{
    public partial class PrendaPrecio : PaginaBase
    {

        #region Declaraciones e  Instancias
        private ServicioDelegadoInventario _servicioDelegadoInventario= new ServicioDelegadoInventario();
        private static  List<ProductoPrecioVistaModelo> _listaProductoPrecioVistaModelos= new List<ProductoPrecioVistaModelo>();
        private static  ProductoPrecioVistaModelo _productoPrecioVistaModelo= new ProductoPrecioVistaModelo();
        private static bool actualizar = false;
        #endregion

        #region Eventos

        /// <summary>
        /// Carga la informacion incial de la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                { 
                    CargarDatosIniciales();
                    CargarDatos();
                }
            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }


        /// <summary>
        /// Graba o actualiza  la informacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _ingresarInformacion_OnClick(object sender, EventArgs e)
        {   
            try
            {

                if (actualizar == true)
                {
                    _productoPrecioVistaModelo.Precio = Convert.ToDecimal(_precio.Text);
                    _productoPrecioVistaModelo.EstaHabilitado = Convert.ToBoolean(_estaHabilitado.Checked);
                    _productoPrecioVistaModelo.FechaCreacion = Convert.ToDateTime(_fechaCreacion.Text);
                    _servicioDelegadoInventario.ActualizarProductoPrecio(_productoPrecioVistaModelo);
                }
                else
                {
                    ProductoPrecioVistaModelo productoPrecioVistaNuevo= new ProductoPrecioVistaModelo();
                    ProductoVistaModelo productoVistaNuevo = new ProductoVistaModelo()
                    {
                        ProductoId = Convert.ToInt32(_prenda.SelectedItem.Value)    
                    };

                    productoPrecioVistaNuevo.Precio = Convert.ToDecimal(_precio.Text);
                    productoPrecioVistaNuevo.EstaHabilitado = Convert.ToBoolean(_estaHabilitado.Checked);
                    productoPrecioVistaNuevo.FechaCreacion = DateTime.Now;
                    productoPrecioVistaNuevo.Modificable = true;
                    productoPrecioVistaNuevo.Producto = productoVistaNuevo;

                _servicioDelegadoInventario.GrabarProductoPrecio(productoPrecioVistaNuevo);

                }
                CargarDatos();
                LimpiarControles();
                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Exitoso").ToString(), "_cancelar");
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }

        /// <summary>
        /// Se  dirige a la pagina de  inicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _cancelar_OnClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Inicio/Default.aspx");
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }


        //Carga la informacion para editar
        protected void _datos_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "Editar")
                {
                    _productoPrecioVistaModelo =
                        _listaProductoPrecioVistaModelos
                            .FirstOrDefault(a => a.ProductoPrecioId.Equals(Convert.ToInt32(_datos.Rows[index].Cells[0].Text.ToString())));

                    _codigoInterno.Text = _productoPrecioVistaModelo.ProductoPrecioId.ToString();
                    _precio.Text = String.Format("{0:0.00}", Convert.ToDecimal(_productoPrecioVistaModelo.Precio.ToString())); 
                    _fechaCreacion.Text = _productoPrecioVistaModelo.FechaCreacion.Value.ToShortDateString();
                    _estaHabilitado.Checked = _productoPrecioVistaModelo.EstaHabilitado.Value;



                }
                actualizar = true;


            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }

        protected void _datos_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                 
                    if (Convert.ToBoolean(e.Row.Cells[3].Text) == true)
                        e.Row.Cells[3].Text = GetGlobalResourceObject("Web_es_Ec", "Label_Habilitado").ToString();
                    else if (Convert.ToBoolean(e.Row.Cells[3].Text) == false)
                        e.Row.Cells[3].Text = GetGlobalResourceObject("Web_es_Ec", "Label_Inhabilitado").ToString();

                }

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }

        }


        /// <summary>
        /// Realiza la paginacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _datos.PageIndex = e.NewPageIndex;
            CargarDatos();
        }

        /// <summary>
        /// Carga la informacion de  los precios de las prendas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _prenda_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
                LimpiarControles();
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");

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
        /// Carga los datos iniciales de la paginas
        /// </summary>
        private void CargarDatosIniciales()
        {
           
            _prenda.DataSource = _servicioDelegadoInventario.ObtenerProductoPorTipoProductoId(Convert.ToInt32(Util.TipoProducto.Servicio));
            _prenda.DataBind();
          LimpiarControles();
           
        }


        /// <summary>
        /// Carga  la informacion de   la  grilla
        /// </summary>
        private void CargarDatos()
        {
            _listaProductoPrecioVistaModelos = _servicioDelegadoInventario.ObtenerProductoPrecioPorEstadoYProductoId(Convert.ToInt32(_prenda.SelectedItem.Value));
            _datos.DataSource =
                _listaProductoPrecioVistaModelos;
            _datos.DataBind();
        }


        /// <summary>
        /// Limpia los controles
        /// </summary>
        private void LimpiarControles()
        {
            _codigoInterno.Text= String.Empty;
            _precio.Text=String.Empty;
            _fechaCreacion.Text = DateTime.Now.ToShortDateString();
            _estaHabilitado.Checked = false;
            _codigoInterno.Text = "0";
            _fechaCreacion.Text = DateTime.Now.ToShortDateString();
            _fechaCreacion.ReadOnly = true;
            actualizar = false;
        }

        #endregion


       
    }
}