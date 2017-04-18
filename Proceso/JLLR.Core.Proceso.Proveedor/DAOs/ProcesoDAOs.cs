#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.Proceso.Proveedor.DAOs
{
    public class ProcesoDAOs:BaseDAOs
    {
        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();


        /// <summary>
        /// Graba el evio  de correo 
        /// </summary>
        /// <param name="proceso"></param>
        public PROCESO GrabarProceso(PROCESO proceso)
        {
            try
            {
                _entidad.PROCESO.Add(proceso);
                _entidad.SaveChanges();
                return proceso;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        
    }
}
