#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modelo = JLLR.Core.Proceso.Servicio.Modelo;
using  modeloGeneral=JLLR.Core.General.Servicio.Modelo;
#endregion
namespace JLLR.Core.Proceso.Servicio.Ensamblador
{
    public class EnsambladorEntidad
    {

        #region PROCESO
        /// <summary>
        /// Convierte el modelo en una entidad
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public entidad.PROCESO CrearProceso(modelo.ProcesoModelo m)
        {
            return new entidad.PROCESO()
            {
             NUMERO_ORDEN = m.NumeroOrden,
             SUCURSAL_ID = m.SucursalId,
             PUNTO_VENTA_ID = m.PuntoVentaId,
             ETAPA_PROCESO_ID = m.EtapaProceso.EtapaProcesoId,
             FECHA_ENVIO = m.FechaEnvio,
             PROCESO_ID = m.ProcesoId,
             SE_ENVIO = m.SeEnvio,
             MENSAJE = m.Mensaje
            };
        }


        /// <summary>
        /// Convierte un listado de modelos en listado de entidades
        /// </summary>
        /// <param name="listadoModelo">Listado de Modelos</param>
        /// <returns></returns>z|
        public List<entidad.PROCESO> CrearProcesos(List<Modelo.ProcesoModelo> listadoModelo)
        {
            List<entidad.PROCESO> listaEntidad = new List<entidad.PROCESO>();

            foreach (var modelo in listadoModelo)
            {
                listaEntidad.Add(CrearProceso(modelo));
            }
            return listaEntidad;

        }
        #endregion
    }
}