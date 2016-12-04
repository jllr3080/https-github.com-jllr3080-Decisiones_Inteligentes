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
    /// Metodos  de  telefono
    /// </summary>
    public class TelefonoDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Grabar  direccion
        /// </summary>
        /// <param name="telefono"></param>
        public void GrabarTelefono(TELEFONO telefono)
        {
            try
            {
                _entidad.TELEFONO.Add(telefono);
                _entidad.SaveChanges();


            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
