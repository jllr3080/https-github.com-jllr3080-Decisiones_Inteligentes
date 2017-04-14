#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using JLLR.Core.ReglaNegocio.Servicio.DTOs;
using JLLR.Core.ReglaNegocio.Servicio.Modelo;
using JLLR.Core.ReglaNegocio.Servicio.Transformador;

#endregion

namespace JLLR.Core.ReglaNegocio.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioReglaNegocio : IServicioReglaNegocio
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
         private readonly TransformadoReglaNegocio _transformadoReglaNegocio= new TransformadoReglaNegocio();

        #region TRANSACCIONAL

        /// <summary>
        /// Obtiene  las  promociones  vigentes 
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>

        public List<ReglaModelo> ObtenerPromocionesVigentes(int puntoVentaId, int sucursalId)
        {
            try
            {
                return _transformadoReglaNegocio.ObtenerPromocionesVigentes(puntoVentaId, sucursalId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Obtener las reglas para aplicar     
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public List<ReglaDTOs> ObtenerReglasPorPuntoVentaIdYSucursalId(int puntoVentaId, int sucursalId)
        {
            try
            {

                return _transformadoReglaNegocio.ObtenerReglasPorPuntoVentaIdYSucursalId(puntoVentaId, sucursalId);


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region REGLA NEGOCIO

        /// <summary>
        /// Ejeuta las  reglas  de  negocio
        /// </summary>
        /// <param name="parametroEntradaReglaNegocio"></param>
        /// <returns></returns>
        public ParametroSalidaReglaNegocioDTOs EjecucionReglaNegocio(ParametroEntradaReglaNegocioDTOs parametroEntradaReglaNegocio)
        {

            try
            {

                return _transformadoReglaNegocio.EjecucionReglaNegocio(parametroEntradaReglaNegocio);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
      #endregion
    }
}
