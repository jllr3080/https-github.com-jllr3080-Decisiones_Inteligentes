﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.Venta.Proveedor.DAOs
{
    public class DetalleOrdenTrabajoFotografiaDAOs:BaseDAOs
    {

        /// <summary>
        /// Declaraciones  e instancias
        /// </summary>
         private  readonly Decisiones_Inteligentes _entidad= new Decisiones_Inteligentes();


        /// <summary>
        /// Graba la fotografia  que se  genero en la orden de trabajo
        /// </summary>
        /// <param name="detalleTrabajoFotografia"></param>
        public void GrabarDetalleOrdenFotografia(DETALLE_TRABAJO_FOTOGRAFIA detalleTrabajoFotografia)
        {
            try
            {
                _entidad.DETALLE_TRABAJO_FOTOGRAFIA.Add(detalleTrabajoFotografia);
                _entidad.SaveChanges();
               
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        
    }
}
