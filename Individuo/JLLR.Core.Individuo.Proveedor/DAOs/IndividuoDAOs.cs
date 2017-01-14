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
    /// Metodos del individuo
    /// </summary>
    public class IndividuoDAOs : BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Grabar el individuo
        /// </summary>
        /// <param name="individuo"></param>
        public INDIVIDUO GrabarIndividuo(INDIVIDUO individuo)
        {
            try
            {
                _entidad.INDIVIDUO.Add(individuo);
                _entidad.SaveChanges();
                return individuo;


            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Actualiza  el individuo
        /// </summary>
        /// <param name="individuo"></param>

        public void Actualizaindividuo(INDIVIDUO individuo)
        {
            try
            {
                var original = _entidad.INDIVIDUO.Find(individuo.INDIVIDUO_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(individuo);
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
