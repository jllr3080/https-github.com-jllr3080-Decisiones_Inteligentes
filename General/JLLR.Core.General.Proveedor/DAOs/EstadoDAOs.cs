#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion

namespace JLLR.Core.General.Proveedor.DAOs
{
    /// <summary>
    /// Metodos de  provincia
    /// </summary>
    public class EstadoDAOs : BaseDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private readonly Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();

        /// <summary>
        /// Obtener  provincias
        /// </summary>
        /// <returns></returns>
        public IQueryable<ESTADO> ObtenerEstadoPorPaisId(int paisId)
        {
            try
            {

                var estados = from estado in _entidad.ESTADO
                              where estado.PAIS_ID == paisId
                              select estado;

                return estados.OrderBy(m => m.DESCRIPCION);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
