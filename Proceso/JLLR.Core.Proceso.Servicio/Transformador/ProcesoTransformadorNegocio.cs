#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.Proceso.Servicio.Ensamblador;
using JLLR.Core.Proceso.Proveedor.Negocio;
using JLLR.Core.Proceso.Servicio.Modelo;

#endregion
namespace JLLR.Core.Proceso.Servicio.Transformador
{
    public class ProcesoTransformadorNegocio
    {
        #region Declaraciones  e Instancias
        private readonly  ProcesoNegocio _procesoNegocio = new ProcesoNegocio();
        private  readonly  EnsambladorEntidad _ensambladorEntidad= new EnsambladorEntidad();
        private readonly  EnsambladorModelo _ensambladorModelo= new EnsambladorModelo();

        #endregion

        #region NEGOCIO

        #endregion

        #region PROCESO
        /// <summary>
        /// Graba el evio  de correo 
        /// </summary>
        /// <param name="proceso"></param>
        public ProcesoModelo GrabarProceso(ProcesoModelo proceso)
        {
            try
            {
                return _ensambladorModelo.CrearProceso(_procesoNegocio.GrabarProceso(_ensambladorEntidad.CrearProceso(proceso)));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}