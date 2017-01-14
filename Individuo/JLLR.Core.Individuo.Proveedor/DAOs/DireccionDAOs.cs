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
    /// Graba la direccion
    /// </summary>
    public class DireccionDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Grabar  direccion
        /// </summary>
        /// <param name="direccion"></param>
        public void GrabarDireccion(DIRECCION direccion)
        {
            try
            {
                _entidad.DIRECCION.Add(direccion);
                _entidad.SaveChanges();


            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Actualiza la  direccion de  domicilio
        /// </summary>
        /// <param name="direccion"></param>
        public void ActualizaDireccion(DIRECCION direccion)
        {
            try
            {
                var original = _entidad.DIRECCION.Find(direccion.DIRECCION_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(direccion);
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
