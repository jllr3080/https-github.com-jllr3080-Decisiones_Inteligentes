#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.ReglaNegocio.Proveedor.DAOs
{
    /// <summary>
    /// Metodos de las  acciones de las reglas
    /// </summary>
    public class AccionReglaDAOs

    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad=new Decisiones_Inteligentes();


        /// <summary>
        /// Obtiene
        /// </summary>
        /// <param name="productoId"></param>
        /// <returns></returns>
        public decimal ObtenerValorRegla(int productoId)
        {
            try
            {
                var accionesRegla = from accionRegla in _entidad.ACCION_REGLA
                    where accionRegla.PRODUCTO_ID == productoId
                    select accionRegla;

                return Convert.ToDecimal(accionesRegla.FirstOrDefault().VALOR);


            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
