#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Base;
using Web.ServicioDelegado;

#endregion
namespace Web.Contabilidad
{
    public partial class CuentasPorPagar : PaginaBase
    {
        #region DECLARACIONES  E INSTANCIAS
        
        private readonly  ServicioDelegadoContabilidad _servicioDelegadoContabilidad= new ServicioDelegadoContabilidad();
        private readonly ServicioDelegadoGeneral _servicioDelegadoGeneral = new ServicioDelegadoGeneral();


        #endregion

        #region Eventos

        /// <summary>
        /// Carga  los totales  a  pagar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private decimal total = 0;
        protected void _datos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    
                    total+= Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CuentaPorPagar.Valor"));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[2].Text = "Totales:";
                    e.Row.Cells[3].Text = String.Format("{0:0.00}",total);
                    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;

                    
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }

        }


        /// <summary>
        /// Carga  la informacion   pinrcipal
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
                    if (User.NombrePerfil != "ADMINISTRADOR")
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

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBusqueda");
            }
        }

        protected void _btnBusqueda_Click(object sender, EventArgs e)
        {
            try
            {
                _datos.DataSource = _servicioDelegadoContabilidad.ObtenerCuentaPorPagarPorFechas(_fechaDesde.Text,
                    _fechaHasta.Text, Convert.ToInt32(_sucursal.SelectedItem.Value));

                _datos.DataBind();

            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBusqueda");
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
        #endregion

       

       
    }
}