#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.General;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Inventario;
using Web.Base;


#endregion
namespace Web.Parametrizacion
{
    public partial class Prenda : PaginaBase
    {

        #region Declaraciones  e Instancias
        
        private ServicioDelegadoInventario _servicioDelegadoInventario= new ServicioDelegadoInventario();
        private static List<ProductoVistaModelo> _lisaProductoVistaModelos= new List<ProductoVistaModelo>(); 
        private static ProductoVistaModelo productoVista= new ProductoVistaModelo();
        private static bool actualizar = false;
        #endregion

        #region Eventos

        /// <summary>
        /// Carga la informacion  incial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    
                    CargarDatos();
                }
                
            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }
        }

        /// <summary>
        /// Se redirige a cancelar
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


        /// <summary>
        /// Ingresar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _ingresarInformacion_OnClick(object sender, EventArgs e)
        {
            try
            {
               
                if (actualizar == true)
                {
                    productoVista.Nombre = _nombrePrenda.Text.ToUpper();
                    productoVista.TiempoEntrega = Convert.ToInt32(_tiempoEntrega.Text);
                    productoVista.PrendaEspecial = Convert.ToBoolean(_prendaEspecial.Checked);
                    productoVista.NumeroPrendas = Convert.ToInt32(_numeroPrendas.Text);
                    productoVista.EstaHabilitado = Convert.ToBoolean(_estaHabilitado.Checked); 
                    _servicioDelegadoInventario.ActualizarProducto(productoVista);
                }
                else
                {
                    ProductoVistaModelo productoVistaNuevo = new ProductoVistaModelo();
                    ModeloVistaModelo modelo = new ModeloVistaModelo
                    {
                        ModeloId = Convert.ToInt32(1)
                    };
                    TipoProductoVistaModelo tipoProducto = new TipoProductoVistaModelo
                    {
                        TipoProductoId = Convert.ToInt32(1)
                    };
                    MaterialVistaModelo material = new MaterialVistaModelo
                    {
                        MaterialId = Convert.ToInt32(1)
                    };
                    MarcaVistaModelo marca = new MarcaVistaModelo
                    {
                        MarcaId = Convert.ToInt32(1)
                    };
                    productoVistaNuevo.Marca = marca;
                    productoVistaNuevo.Modelo = modelo;
                    productoVistaNuevo.TipoProducto = tipoProducto;
                    productoVistaNuevo.Material = material;
                    productoVistaNuevo.Nombre = _nombrePrenda.Text.ToUpper();
                    productoVistaNuevo.PedirMedida = false;
                    productoVistaNuevo.FechaCreacion = DateTime.Now;
                    productoVistaNuevo.UsuarioId = User.Id;
                    productoVistaNuevo.Visible = false;
                    productoVistaNuevo.TiempoEntrega = Convert.ToInt32(_tiempoEntrega.Text);
                    productoVistaNuevo.PrendaEspecial = Convert.ToBoolean(_prendaEspecial.Checked);
                    productoVistaNuevo.NumeroPrendas = Convert.ToInt32(_numeroPrendas.Text);
                    productoVistaNuevo.EstaHabilitado = Convert.ToBoolean(_estaHabilitado.Checked);

                    _servicioDelegadoInventario.GrabarProducto(productoVistaNuevo);

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
        /// Edita  la informacion de las prendas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "Editar")
                {
                    productoVista =
                        _lisaProductoVistaModelos
                            .FirstOrDefault(a => a.ProductoId.Equals(Convert.ToInt32(_datos.Rows[index].Cells[0].Text.ToString())));


                    _codigoInterno.Text = productoVista.ProductoId.ToString();
                    _nombrePrenda.Text = productoVista.Nombre;
                    _tiempoEntrega.Text = productoVista.TiempoEntrega.ToString();
                    _prendaEspecial.Checked = productoVista.PrendaEspecial.Value;
                    _numeroPrendas.Text = productoVista.NumeroPrendas.ToString();
                    _estaHabilitado.Checked = productoVista.EstaHabilitado.Value;




                   
                }
                actualizar = true;


            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }

        }

        /// <summary>
        /// Verifica  si esta  habilitado y el resultado es true  o false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (Convert.ToBoolean(e.Row.Cells[3].Text) == true)
                        e.Row.Cells[3].Text = GetGlobalResourceObject("Web_es_Ec", "Label_Si").ToString();
                    else if (Convert.ToBoolean(e.Row.Cells[3].Text) == false)
                        e.Row.Cells[3].Text = GetGlobalResourceObject("Web_es_Ec", "Label_No").ToString();

                    if (Convert.ToBoolean(e.Row.Cells[5].Text) == true)
                        e.Row.Cells[5].Text = GetGlobalResourceObject("Web_es_Ec", "Label_Habilitado").ToString();
                    else if (Convert.ToBoolean(e.Row.Cells[5].Text) == false)
                        e.Row.Cells[5].Text = GetGlobalResourceObject("Web_es_Ec", "Label_Inhabilitado").ToString();

                }

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_cancelar");
            }

        }

        /// <summary>
        /// Pagina el grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _datos_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            _datos.PageIndex = e.NewPageIndex;
            CargarDatos();
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Cargar Datos
        /// </summary>
        private void CargarDatos()
        {
            _lisaProductoVistaModelos = _servicioDelegadoInventario.ObtenerProductoPorTipoProductoId(Convert.ToInt32(Util.TipoProducto.Servicio));
            _datos.DataSource = _lisaProductoVistaModelos;
            _datos.DataBind();
            actualizar = false;
            _codigoInterno.Text = "0";
        }


        /// <summary>
        /// Encera los  controles
        /// </summary>
        private void LimpiarControles()
        {
            _numeroPrendas.Text = String.Empty;
            _estaHabilitado.Checked = false;
            _nombrePrenda.Text=String.Empty;
            _tiempoEntrega.Text=String.Empty;
            _prendaEspecial.Checked = false;
            _estaHabilitado.Checked = false;
            _codigoInterno.Text = "0";
            productoVista = null;


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
        #endregion
    }
}