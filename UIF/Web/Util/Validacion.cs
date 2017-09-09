#region  using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
#endregion

namespace Web.Util
{
    public class Validacion
    {

        /// <summary>
        /// Valida que la cedula sea  valida
        /// </summary>
        /// <param name="cedula"></param>
        /// <returns></returns>
        public bool ValidacionCedula(string cedula)
        {
            try
            {
                int esNumerico = 0;
                var total=0;
                const int tamanoLongitudCedula = 10;
                int[] coeficientes = {2, 1, 2, 1, 2, 1, 2, 1, 2};
                const int numeroProvincias = 24;
                const int tercerDigito = 6;
                if(int.TryParse(cedula,out esNumerico) && cedula.Length==tamanoLongitudCedula)
                {
                    var provincia = Convert.ToInt32(string.Concat(cedula[0], cedula[1], string.Empty));
                    var digitoTres = Convert.ToInt32(cedula[2] + String.Empty);
                    if ((provincia > 0 && provincia <= numeroProvincias) && digitoTres < tercerDigito)
                    {
                        var digitoVerificadorRecibido = Convert.ToInt32(cedula[9]+String.Empty) ;
                        for (var k = 0; k < coeficientes.Length; k++)
                        {
                            var valor = Convert.ToInt32(coeficientes[k] + String.Empty)*
                                        Convert.ToInt32(cedula[k] + String.Empty);
                            total = valor >= 10 ? total + (valor - 9) : total + valor;

                        }
                        var digitoVerificadorObtenido= total>=10 ?(total%10)!=0?10-(total%10):total%10:
                        total;
                        return digitoVerificadorObtenido == digitoVerificadorRecibido;

                    }
                
                }
                return false;

            }
            catch (Exception ex)
            {
                
                throw;
            }

        }

        /// <summary>
        /// Valida si el ruc cumple con los requisitos es persona  natural
        /// </summary>
        /// <param name="ruc"></param>
        /// <returns></returns>
        public bool ValidaPersonaNatural(string ruc)
        {
            try
            {
                long esNUmerico;
                const int tamanoLongitudRuc = 13;
                const string establecimiento = "001";
                if (long.TryParse(ruc, out esNUmerico) && ruc.Length.Equals(tamanoLongitudRuc))
                {
                   
                    var numeroProvincia = Convert.ToInt32(string.Concat(ruc[0] , string.Empty , ruc[1] + string.Empty));
                    var personaNatural = Convert.ToInt32(ruc[2] + string.Empty);
                    if ((numeroProvincia>=1 &&numeroProvincia<=24) &&(personaNatural>=0 && personaNatural<6))
                    {
                        return ruc.Substring(10, 3) == establecimiento && ValidacionCedula(ruc.Substring(0, 10));
                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// CAlcula cuando  es jueves y le suma   dias para  ver cuando retorna las prendas
        /// </summary>
        /// <returns></returns>
        public int CalculoDias()
        {
            try
            {
                int dias = 0;
                int day = ((int)DateTime.Now.DayOfWeek == 0) ? 7 : (int)DateTime.Now.DayOfWeek;
                if (day >= 4)
                {
                    dias =5;
                }
               

                return dias;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Valida  si el correo   es correcto
        /// </summary>
        /// <returns></returns>

        public bool ValidarCorreoElectronico(string direcionCoreo)
        {
            try
            {

                if (
                    Regex.IsMatch(direcionCoreo,
                        @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)) != true)
                    return false;
                else
                    return true;

            }
            catch (Exception)
            {
                
                throw;
            }
        }



    }
}