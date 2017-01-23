#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.FlujoProceso.Proveedor.DTOs;

#endregion
namespace JLLR.Core.FlujoProceso.Proveedor.DAOs
{
    /// <summary>
    /// Metodos  generales
    /// </summary>
    public class TransaccionalDAOs:BaseDAOs
    {
        #region Declaracion e Instancias
        private readonly  Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();
        #endregion

        #region REPORTES

        /// <summary>
        /// Obtiene el historial de prendas 
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="fechaRegistro"></param>
        /// <param name="etapaProcesoId"></param>
        /// <returns></returns>
        public List<HistorialProcesoDTOs> ObtenerHistorialProcesoPrendasPorVariosParametros(int sucursalId,
            int puntoVentaId, DateTime fechaRegistro, int etapaProcesoId)
        {
            try
            {
                var historialProcesos = from historialProceso in _entidad.HISTORIAL_PROCESO
                    join puntoVenta in _entidad.PUNTO_VENTA on historialProceso.PUNTO_VENTA_ID equals
                        puntoVenta.PUNTO_VENTA_ID
                    join etapaProceso in _entidad.ETAPA_PROCESO on historialProceso.ETAPA_PROCESO_ID equals
                        etapaProceso.ETAPA_PROCESO_ID
                    where
                        historialProceso.SUCURSAL_ID == sucursalId && historialProceso.PUNTO_VENTA_ID == puntoVentaId &&
                        historialProceso.ETAPA_PROCESO_ID == etapaProcesoId
                    select new HistorialProcesoDTOs() {NumeroOrden = historialProceso.NUMERO_ORDEN,OrdenTrabajoId =historialProceso.ORDEN_TRABAJO_ID,NombrePuntoVenta = puntoVenta.DESCRIPCION,FechaRegistro = historialProceso.FECHA_REGISTRO,NumeroPrendas = 0,UsuarioRecibeId = historialProceso.USUARIO_RECIBE_ID,UsuarioEntregaId = historialProceso.USUARIO_ENTREGA_ID};

                List < HistorialProcesoDTOs > _listaHistorialProcesoDtOses= new List<HistorialProcesoDTOs>();


                foreach (var objetoHistorialProcesoDTOs in historialProcesos)
                {

                    HistorialProcesoDTOs _historialProcesoDtOs= new HistorialProcesoDTOs();
                    _historialProcesoDtOs = objetoHistorialProcesoDTOs;
                    var detalleOrdenesTrabajo = from detalleOrdenTrabajo in _entidad.DETALLE_ORDEN_TRABAJO
                        where detalleOrdenTrabajo.ORDEN_TRABAJO_ID == objetoHistorialProcesoDTOs.OrdenTrabajoId
                        select detalleOrdenTrabajo;

                    _historialProcesoDtOs.NumeroPrendas = detalleOrdenesTrabajo.Sum(m => m.CANTIDAD);
                    _historialProcesoDtOs.UsuarioEntrega =
                        _entidad.USUARIO.Find(Convert.ToInt32(objetoHistorialProcesoDTOs.UsuarioEntregaId)).NOMBRE_USUARIO;

                    _historialProcesoDtOs.UsuarioRecibe =
                        _entidad.USUARIO.Find(Convert.ToInt32(objetoHistorialProcesoDTOs.UsuarioRecibeId)).NOMBRE_USUARIO;
                    _listaHistorialProcesoDtOses.Add(_historialProcesoDtOs);

                }

                return _listaHistorialProcesoDtOses;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        #endregion
    }
}
