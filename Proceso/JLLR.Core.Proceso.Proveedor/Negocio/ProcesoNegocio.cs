#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Proceso.Proveedor.DAOs;

#endregion
namespace JLLR.Core.Proceso.Proveedor.Negocio
{
    public class ProcesoNegocio
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly  ProcesoDAOs _procesoDaOs= new ProcesoDAOs();
        private  readonly  TransaccionalDAOs _transaccionalDaOs= new TransaccionalDAOs();
        #endregion
     
        #region PROCESO
        /// <summary>
        /// Graba el evio  de correo 
        /// </summary>
        /// <param name="proceso"></param>
        public PROCESO GrabarProceso(PROCESO proceso)
        {
            try
            {
               return _procesoDaOs.GrabarProceso(proceso);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
