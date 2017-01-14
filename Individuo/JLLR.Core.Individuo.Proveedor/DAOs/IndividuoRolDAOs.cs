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
    /// Metodos de la tabla de   individuo rol
    /// </summary>
    public class IndividuoRolDAOs:BaseDAOs
    {
        /// <summary>
        /// decisiones inteligentes
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();


        /// <summary>
        /// Graba el rol del individuo
        /// </summary>
        /// <param name="individuoRol"></param>
        /// <returns></returns>

        public INDIVIDUO_ROL GrabarIndividuoRol(INDIVIDUO_ROL individuoRol)
        {
            try
            {
                _entidad.INDIVIDUO_ROL.Add(individuoRol);
                _entidad.SaveChanges();
                return individuoRol;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Actualiza el rol del individuo
        /// </summary>
        /// <param name="individuoRol"></param>
        public void ActualizaIndividuoRol(INDIVIDUO_ROL individuoRol)
        {
            try
            {
                var original = _entidad.INDIVIDUO_ROL.Find(individuoRol.INDIVIDUO_ROL_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(individuoRol);
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
