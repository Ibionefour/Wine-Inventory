using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineInventory
{
    class Wine
    {
        // entry point for the program, the wine logic is moved to a new class so 
         // it can be called here.
        static void Main(string[] args)
        {
            new WineLogic.WineProgram();

        }
    }
}
