﻿#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;
using JLLR.Core.ReglaNegocio.Proveedor.DTOs;

#endregion

namespace JLLR.Core.ReglaNegocio.Proveedor.DAOs
{
    /// <summary>
    /// Metodos  transaccionales en general
    /// </summary>
    public class TransaccionalDAOs:BaseDAOs
    {

        /// <summary>
        /// Declaraciones e instancias 
        /// </summary>
        private readonly  Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Obtener las reglas para aplicar     
        /// </summary>
        /// <param name="puntoVentaId"></param>
        /// <param name="sucursalId"></param>
        /// <returns></returns>
        public IQueryable<ReglaDTOs> ObtenerReglasPorPuntoVentaIdYSucursalId(int puntoVentaId, int sucursalId)
        {
            try
            {
                var reglasNegocio = from regla in _entidad.REGLA
                    join accionRegla in _entidad.ACCION_REGLA on regla.REGLA_ID equals accionRegla.REGLA_ID
                    where
                        regla.PUNTO_VENTA_ID == puntoVentaId && regla.SUCURSAL_ID == sucursalId &&
                        accionRegla.ESTA_HABILITADO == true
                    select new ReglaDTOs
                    {
                        ProductoId = accionRegla.PRODUCTO_ID,
                        NombreRegla = regla.NOMBRE_REGLA,
                        Porcentaje = accionRegla.VALOR,
                        ReglaId = regla.REGLA_ID
                    };
                return reglasNegocio.OrderBy(m=>m.NombreRegla);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }



    }
}