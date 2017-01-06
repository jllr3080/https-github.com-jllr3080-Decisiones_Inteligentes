#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using entidadDTOs = JLLR.Core.Venta.Proveedor.DTOs;
using modeloDTOs = JLLR.Core.Venta.Servicio.DTOs;
using ensamblador = JLLR.Core.Venta.Servicio.Ensamblador;

#endregion

namespace JLLR.Core.Venta.Servicio.EnsambladorDTOs
{
    /// <summary>
    /// Ingresa una  entidad y lo transforma en un modelo
    /// </summary>
    public class EnsambladorModeloDTOs
    {

        #region  CONSULTA ORDEN DE TRABJO
        /// <summary>
        /// Convierte el DTO de entidad a modelo
        /// </summary>
        /// <param name="e">Entidad</param>
        /// <returns></returns>
        public modeloDTOs.ConsultaOrdenTrabajoDTOs CrearConsultaOrdenTrabajoDtOs(entidadDTOs.ConsultaOrdenTrabajoDTOs e)
        {
          
            return new modeloDTOs.ConsultaOrdenTrabajoDTOs
            {
               TipoLavado = e.TipoLavado,
               EstadoPago = e.EstadoPago,
               Marca = e.Marca,
               NumeroOrden = e.NumeroOrden,
               FechaIngreso = e.FechaIngreso,
               FechaEntrega = e.FechaEntrega,
               ValorUnitario = e.ValorUnitario,
               Cantidad = e.Cantidad,
               Color = e.Color,
               Prenda = e.Prenda,
               ValorTotal = e.ValorTotal,
               NombreCliente = e.NombreCliente,
               Observacion = e.Observacion,
                EstadoPagoId = e.EstadoPagoId,
                DetalleOrdenTrabajoId = e.DetalleOrdenTrabajoId,
                OrdenTrabajoId = e.OrdenTrabajoId

            };

        }

        /// <summary>
        /// Convierte un listado de DTO en listado de  modelos de DTO
        /// </summary>
        /// <param name="listadoEntidad">Listado de Entidades</param>
        /// <returns></returns>
        public List<modeloDTOs.ConsultaOrdenTrabajoDTOs> CrearConsultaOrdenesTrabajoDtOs(IQueryable<entidadDTOs.ConsultaOrdenTrabajoDTOs> listadoEntidad)
        {
            List<modeloDTOs.ConsultaOrdenTrabajoDTOs> listaModelo = new List<modeloDTOs.ConsultaOrdenTrabajoDTOs> ();

            foreach (var entidad in listadoEntidad)
            {
                listaModelo.Add(CrearConsultaOrdenTrabajoDtOs(entidad));
            }
            return listaModelo;

        }

        #endregion
    }
}