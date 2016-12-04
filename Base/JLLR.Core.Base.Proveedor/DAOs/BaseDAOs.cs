#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace JLLR.Core.Base.Proveedor.DAOs
{
   public  class BaseDAOs
    {
        /// <summary>
        /// Clase  base  donde  se instancia la  cultura   con  el formato de fecha y monedas
        /// </summary>
       public BaseDAOs()
       {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-EC");
            System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";
        }

    }
}
