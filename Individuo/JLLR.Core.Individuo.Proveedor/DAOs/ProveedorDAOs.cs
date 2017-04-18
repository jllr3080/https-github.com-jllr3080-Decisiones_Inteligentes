#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.Individuo.Proveedor.DAOs
{
    /// <summary>
    /// Metodo de  proveedores
    /// </summary>
    public class ProveedorDAOs : BaseDAOs
    {

        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();


        /// <summary>
        /// Grabar el proveedor
        /// </summary>
        /// <param name="proveedor"></param>
        /// <returns></returns>

        public PROVEEDOR GrabarProveedor(PROVEEDOR proveedor)
        {
            try
            {
                _entidad.PROVEEDOR.Add(proveedor);
                _entidad.SaveChanges();
                return proveedor;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza  el  cliente
        /// </summary>
        /// <param name="proveedor"></param>
        /// <returns></returns>
        public void ActualizaProveedor(PROVEEDOR proveedor)
        {
            try
            {
                var original = _entidad.PROVEEDOR.Find(proveedor.PROVEEDOR_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(proveedor);
                    _entidad.SaveChanges();
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
