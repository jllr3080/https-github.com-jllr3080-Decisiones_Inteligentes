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
    /// Metodos para grabar el correo electronico
    /// </summary>
    public class CorreoElectronicoDAOs : BaseDAOs
    {

        /// <summary>
        /// Declaraciones e instancias
        /// </summary>
        private Decisiones_Inteligentes _entidad = new Decisiones_Inteligentes();


        /// <summary>
        /// Grabar  el correo electronico
        /// </summary>
        /// <param name="email"></param>
        public void GrabarCorreoElectronico(E_MAIL email)
        {
            try
            {
                _entidad.E_MAIL.Add(email);
                _entidad.SaveChanges();


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualiza  el correo  electronico
        /// </summary>
        /// <param name="eMail"></param>
        public void ActualizaCorreoElectronico(E_MAIL eMail)
        {
            try
            {
                var original = _entidad.E_MAIL.Find(eMail.E_MAIL_ID);

                if (original != null)
                {
                    _entidad.Entry(original).CurrentValues.SetValues(eMail);
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
