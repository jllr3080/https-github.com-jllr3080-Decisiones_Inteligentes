#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modelo = JLLR.Core.Proceso.Servicio.Modelo;
using modeloGeneral = JLLR.Core.General.Servicio.Modelo;
#endregion
namespace JLLR.Core.Proceso.Servicio.Ensamblador
{
    public class EnsambladorModelo
    {

        #region PROCESO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.ProcesoModelo CrearProceso(entidad.PROCESO e)
        {
            modeloGeneral.EtapaProcesoModelo etapaProceso= new modeloGeneral.EtapaProcesoModelo();
            etapaProceso.EtapaProcesoId =Convert.ToInt32(e.ETAPA_PROCESO_ID);
            return new modelo.ProcesoModelo
            {
               PuntoVentaId = e.PUNTO_VENTA_ID,
               SucursalId = e.SUCURSAL_ID,
               NumeroOrden = e.NUMERO_ORDEN,
               EtapaProceso = etapaProceso,
               SeEnvio = e.SE_ENVIO,
               FechaEnvio = e.FECHA_ENVIO,
               ProcesoId = e.PROCESO_ID,
               Mensaje = e.MENSAJE
            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.ProcesoModelo> CrearProcesos(IQueryable<entidad.PROCESO> listadoEntidad)
        {
            List<modelo.ProcesoModelo> listaModelo = new List<modelo.ProcesoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearProceso(entidad));
            }
            return listaModelo;

        }

        #endregion
    }
}