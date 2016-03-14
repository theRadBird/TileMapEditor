using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    static class Program
    {
        //Juliann Internicola
        //Map Editor V1.0
        //Professor Moreau
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MapForm());
        }
    }
}
