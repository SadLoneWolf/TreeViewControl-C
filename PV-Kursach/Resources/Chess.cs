using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// TODO
/*
 Edited 05.09.2020
 1. Redefine Chess class to have an ID fields ( this applies to constructor as well )
 2. When done with 1, use ID property to fill new TreeView object on your form
 3. Redesign form
 4. Write the Saving ( remeber, you have to save current state of hirearchy to XML file )
 
 */
namespace PV_Kursach
{
    public class Notifications
    {
        public static void NotifyError()
        {
            MessageBox.Show("An error has occured !");
        }

        public static void NotifySucess()
        {
            MessageBox.Show("Operation completed !");

        }
    }
   

      
        
       

    } 
    
   
    


