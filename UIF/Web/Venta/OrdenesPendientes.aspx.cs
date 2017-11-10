using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Base;
using Web.DTOs.Venta;
using Web.ServicioDelegado;

namespace Web.Venta
{
    public partial class OrdenesPendientes : PaginaBase
    {
        private readonly ServicioDelegadoVenta _servicioDelegadoVenta= new ServicioDelegadoVenta();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                { 
                    List<OrdenTrabajoVistaDTOs> _listaOrdenTrabajoVistaDtOses =_servicioDelegadoVenta.ObtenerOrdenTrabajoPorEstadoTemporal(Convert.ToInt32(User.PuntoVentaId));

                    List<OrdenTrabajoSimple> _listaOrdenTrabajoSimples= new List<OrdenTrabajoSimple>();
                    foreach (var orden in _listaOrdenTrabajoVistaDtOses)
                    {
                        OrdenTrabajoSimple ordenTrabajoSimple= new OrdenTrabajoSimple();
                        ordenTrabajoSimple.NumeroOrden = orden.OrdenTrabajo.NumeroOrden;
                        ordenTrabajoSimple.OrdenTrabajoId= orden.OrdenTrabajo.OrdenTrabajoId;
                        _listaOrdenTrabajoSimples.Add(ordenTrabajoSimple);
                    }

                    _ordenPendiente.DataSource = _listaOrdenTrabajoSimples;
                    _ordenPendiente.DataBind();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void _ordenPendiente_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        #region Metodos
        

        #endregion
    }

    public class OrdenTrabajoSimple
    {
        public Int64 OrdenTrabajoId { get; set; }

        public  string NumeroOrden { get; set; }
    }
}