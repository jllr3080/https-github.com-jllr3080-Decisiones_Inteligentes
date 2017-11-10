#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Contabilidad;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.General;
using JLLR.Core.ServicioDelegado.Proveedor.VistaModelo.Seguridad;
using Web.Base;
using Web.ServicioDelegado;

#endregion

namespace Web.Contabilidad
{
    public partial class CierreMes :PaginaBase
    {
        #region DECLARACION E  INSTANCIAS
        private readonly JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado.ServicioDelegadoGeneral _servicioDelegadoGeneral= new JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado.ServicioDelegadoGeneral();
        private readonly JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado.ServicioDelegadoContabilidad _servicioDelegadoContabilidad = new JLLR.Core.ServicioDelegado.Proveedor.ServicioDelegado.ServicioDelegadoContabilidad();
        private static  List<MesVistaModelo> _meses= new List<MesVistaModelo>();
        #endregion

        #region EVENTOS

        /// <summary>
        /// Busca  la informacion de  los  cierres  de mes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnBuscar_OnClick(object sender, EventArgs e)
        {
            try
            {
                _datos.DataSource = _servicioDelegadoContabilidad.ObtenerCuentaPorPagarPorFechas(_meses.Where(m => m.MesId.Equals(Convert.ToInt32(_mes.SelectedItem.Value))).Select(b => b.FechaDesde).FirstOrDefault().ToString(), _meses.Where(m => m.MesId.Equals(Convert.ToInt32(_mes.SelectedItem.Value))).Select(b => b.FechaHasta).FirstOrDefault().ToString(), Convert.ToInt32(_sucursal.SelectedItem.Value));
                _datos.DataBind();
                if (_datos.Rows.Count == 0)
                    Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Informacion_No_existe").ToString(), "_btnBuscar");
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Cierra el mes  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnCierreMes_OnClick(object sender, EventArgs e)
        {
            try
            {
                 CierreMesVistaModelo cierreMes= new CierreMesVistaModelo();
                 cierreMes.AplicacionPendiente = false;
                 cierreMes.FechaCreacion=DateTime.Now;
                MesVistaModelo mes = new MesVistaModelo();
                mes.MesId = Convert.ToInt32(_mes.SelectedItem.Value);
                cierreMes.Mes=mes;
                PuntoVentaVistaModelo puntoVenta= new PuntoVentaVistaModelo();
                puntoVenta.PuntoVentaId = Convert.ToInt32(_sucursal.SelectedItem.Value);
                cierreMes.PuntoVenta = puntoVenta;
                SucursalVistaModelo sucursal = new SucursalVistaModelo();
                sucursal.SucursalId = Convert.ToInt32(Util.Sucursal.Quito);
                cierreMes.Sucursal = sucursal;
                cierreMes.Valor=Convert.ToDecimal(_servicioDelegadoContabilidad.ObtenerCuentaPorPagarPorFechas(_meses.Where(m => m.MesId.Equals(Convert.ToInt32(_mes.SelectedItem.Value))).Select(b => b.FechaDesde).FirstOrDefault().ToString(), _meses.Where(m => m.MesId.Equals(Convert.ToInt32(_mes.SelectedItem.Value))).Select(b => b.FechaHasta).FirstOrDefault().ToString(), Convert.ToInt32(_sucursal.SelectedItem.Value)).Sum(z=>z.CuentaPorPagar.Valor));
                UsuarioVistaModelo usuario = new UsuarioVistaModelo();
                usuario.UsuarioId = Convert.ToInt32(User.Id);
                cierreMes.Usuario = usuario;
                cierreMes = _servicioDelegadoContabilidad.GrabarCierreMes(cierreMes);

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Informacion_No_existe").ToString(), "_btnBuscar");


            }
            catch (Exception ex)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }

        /// <summary>
        ///  Cancela la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void _btnCancelar_OnClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Inicio/Default.aspx");
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// Carga  los totales  a  pagar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private decimal total = 0;
        protected void _datos_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CuentaPorPagar.Valor"));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[2].Text = "Totales:";
                    e.Row.Cells[3].Text = String.Format("{0:0.00}", total);
                    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;


                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Carga la informacion inicial de la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    _sucursal.DataSource = _servicioDelegadoGeneral.ObtenerPuntosVentaPorSucursalId(Convert.ToInt32(Util.Sucursal.Quito));
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
                    _meses= _servicioDelegadoGeneral.ObtenerMeses();
                    _mes.DataSource = _meses;
                    _mes.DataBind();

                }
                
            }
            catch (Exception)
            {

                Mensajes(GetGlobalResourceObject("Web_es_Ec", "Mensaje_Error_Sistema").ToString(), "_btnBuscar");
            }
        }
        #endregion

        #region METODOS
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