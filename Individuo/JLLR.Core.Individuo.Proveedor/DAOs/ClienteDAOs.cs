#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLLR.Core.Base.Proveedor.DAOs;
using JLLR.Core.Base.Proveedor.Entidades;

#endregion
namespace JLLR.Core.Individuo.Proveedor.DAOs
{
    /// <summary>
    /// Metodos de  cliente
    /// </summary>
    public class ClienteDAOs:BaseDAOs
    {
        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Grabar el cliente
        /// </summary>
        /// <param name="cliente"></param>
        public CLIENTE GrabarCliente(CLIENTE cliente)
        {
            try
            {
                _entidad.CLIENTE.Add(cliente);
                _entidad.SaveChanges();
                return cliente;

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Actualiza  el  cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public void ActualizaCliente(CLIENTE cliente)
        {
            try
            {
                var original = _entidad.CLIENTE.Find(cliente.CLIENTE_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(cliente);
                    _entidad.SaveChanges();
                }

                
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

    }
}
