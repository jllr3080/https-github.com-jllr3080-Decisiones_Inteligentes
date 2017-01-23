#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JLLR.Core.FlujoProceso.Servicio.ServicioDelegado;
using entidad = JLLR.Core.Base.Proveedor.Entidades;
using modelo = JLLR.Core.FlujoProceso.Servicio.Modelo;
using modeloGeneral=JLLR.Core.General.Servicio.Modelo;
#endregion
namespace JLLR.Core.FlujoProceso.Servicio.Ensamblador
{

    /// <summary>
    /// Ingresa una  entidad y lo transforma en un modelo
    /// </summary>
    public class EnsambladorModelo
    {
        #region DECLARACIONES  E INSTANCIAS
        private readonly  ServicioDelegadoGeneral _servicioDelegadoGeneral= new ServicioDelegadoGeneral();
        #endregion          

        #region  HISTORIAL PROCESO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modelo.HistorialProcesoModelo CrearHistorialProceso(entidad.HISTORIAL_PROCESO e)
        {
            modeloGeneral.EtapaProcesoModelo etapaProceso =
                _servicioDelegadoGeneral.ObtenerEtapaProcesoPorEtapaProcesoId(Convert.ToInt32(e.ETAPA_PROCESO_ID));
            
            return new modelo.HistorialProcesoModelo
            {
                HistorialProcesoId = e.HISTORIAL_PROCESO_ID,
                OrdenTrabajoId =Convert.ToInt32( e.ORDEN_TRABAJO_ID),
                NumeroOrden = e.NUMERO_ORDEN,
                FechaRegistro = e.FECHA_REGISTRO,
                FechaInicio = e.FECHA_INICIO,
                FechaFin = e.FECHA_FIN,
                EtapaProceso = etapaProceso,
                Texto = e.TEXTO,
                PuntoVentaId = e.PUNTO_VENTA_ID,
                SucursalId = e.SUCURSAL_ID,
                DetalleOrdenTrabajoId = e.DETALLE_ORDEN_TRABAJO_ID,
                PerfilId = e.PERFIL_ID,
                UsuarioRecibeId = e.USUARIO_RECIBE_ID,
                UsuarioEntregaId = e.USUARIO_ENTREGA_ID,
                PasoPorEstaEtapa = e.PASO_ESTA_ETAPA


            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modelo.HistorialProcesoModelo> CrearHistorialProcesos(IQueryable<entidad.HISTORIAL_PROCESO> listadoEntidad)
        {
            List<modelo.HistorialProcesoModelo> listaModelo = new List<modelo.HistorialProcesoModelo>();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearHistorialProceso(entidad));
            }
            return listaModelo;

        }

        #endregion
    }
}