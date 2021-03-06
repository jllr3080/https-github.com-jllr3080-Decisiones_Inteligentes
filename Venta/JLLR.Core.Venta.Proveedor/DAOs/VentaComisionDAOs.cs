﻿#region using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.Venta.Proveedor.DAOs
{
    /// <summary>
    /// Venta de  comision 
    /// </summary>
    public class VentaComisionDAOs:BaseDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Obtener Comision de las sucursal
        /// </summary>
        /// <param name="sucursalId"></param>
        /// <param name="puntoVentaId"></param>
        /// <param name="vieneRegla"></param>
        /// <param name="tipoLavadoId"></param>
        /// <returns></returns>
        public VENTA_COMISION ObtenerbVentaComisionPorVariosParametros(int sucursalId, int puntoVentaId, bool vieneRegla, int tipoLavadoId, int promocionAplicada)
        {
            try
            {
                if (vieneRegla ==false)
                { 
                var ventasComision = from ventaComision in _entidad.VENTA_COMISION
                    where
                    ventaComision.SUCURSAL_ID == sucursalId && ventaComision.PUNTO_VENTA_ID == puntoVentaId &&
                    ventaComision.TIPO_LAVADO_ID == tipoLavadoId && ventaComision.ESTA_HABILITADO == true && ventaComision.VIENE_REGLA==vieneRegla
                    select ventaComision;
                    return ventasComision.FirstOrDefault();
                }
                else
                {
                    var ventasComision = from ventaComision in _entidad.VENTA_COMISION
                                         where
                                         ventaComision.SUCURSAL_ID == sucursalId && ventaComision.PUNTO_VENTA_ID == puntoVentaId &&
                                         ventaComision.TIPO_LAVADO_ID == tipoLavadoId && ventaComision.ESTA_HABILITADO == true && ventaComision.VIENE_REGLA == vieneRegla && ventaComision.PROMOCION_APLICADA==promocionAplicada
                                         select ventaComision;

                    return ventasComision.FirstOrDefault();
                }

                
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Graba la  venta de la ocmision
        /// </summary>
        /// <param name="ventaComision"></param>

        public void GrabarVentaComision(VENTA_COMISION ventaComision)
        {
            try
            {
                _entidad.VENTA_COMISION.Add(ventaComision);
                _entidad.SaveChanges();
                
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// Actualizar  venta de  comision
        /// </summary>
        /// <param name="ventaComision"></param>
        public void ActualizarVentaComision(VENTA_COMISION ventaComision)
        {
            try
            {
                var original = _entidad.VENTA_COMISION.Find(ventaComision.VENTA_COMISION_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(ventaComision);
                    _entidad.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }


        /// <summary>
        /// Obtiene las  venta de las comisiones
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <returns></returns>
        public IQueryable<VENTA_COMISION> ObtenerVentaComisiones(int puntoVentaId)
        {
            try
            {
                var ventaComisiones = from ventaComision in _entidad.VENTA_COMISION
                                      where ventaComision.PUNTO_VENTA_ID==puntoVentaId
                                      select ventaComision;

                return ventaComisiones;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }



    }
}
