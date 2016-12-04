#region using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.Individuo.Proveedor.Validacion
{
    /// <summary>
    ///  Validaciones  a nivel de  negocio
    /// </summary>
    public class ValidacionNegocioDAOs
    {
        #region DECLARACIONES  E INSTANCIAS
        private Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();
        #endregion

        #region CLIENTE


        /// <summary>
        /// Validar si el cliente ya existe  
        /// </summary>
        /// <returns></returns>
        public bool ValidarExistenciaClientePorNumeroIdentificacion( string numeroIdentificacion)
        {
            try
            {
                var individuos = from individuo in _entidad.INDIVIDUO
                    join cliente in _entidad.CLIENTE on individuo.INDIVIDUO_ID equals cliente.INDIVIDUO_ID
                    where individuo.NUMERO_IDENTIFICACION == numeroIdentificacion
                    select individuo;

                if (individuos.Count() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        #endregion
    }
}
