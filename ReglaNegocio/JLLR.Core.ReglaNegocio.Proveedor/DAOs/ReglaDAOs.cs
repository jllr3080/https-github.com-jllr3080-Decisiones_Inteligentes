#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.ReglaNegocio.Proveedor.DAOs
{
    /// <summary>
    /// Metodos de relas
    /// </summary>
    public class ReglaDAOs:BaseDAOs
    {

        //Declaraciones  e instancias
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();


        /// <summary>
        /// Obtiene la promocion por  Id
        /// </summary>
        /// <param name="reglaId"></param>
        /// <returns></returns>
        public REGLA ObtenerReglaPorId(int reglaId)
        {
            try
            {
                return _entidad.REGLA.Find(reglaId);
            }
            catch (Exception ex)
            {
                    
                throw;
            }
        }
    }
}
