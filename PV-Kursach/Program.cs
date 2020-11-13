using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PV_Kursach.Resources;
/* NOTES TO MYSELF
1. Class examples must be saved in a LIST<T>
2. Object manipulation with mouse must be included
3. User can make, delete, change object values (you will not allow change of name, but only values.)
4.Saving/loading the current status of class hirearchy in .xml format!!
5.Error handling and all GUI Application standarts must be sattisfied!!
*/
namespace PV_Kursach
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Glavni());
        }
    }
}
