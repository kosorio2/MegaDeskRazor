using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskRazor
{
    public class DesktopMaterial
    {
        public int DesktopMaterialId { get; set; }

        public string DesktopMaterialName { get; set; } // This will hold the data, like laminate, oak, etc. 

        public decimal DesktopMaterialPrice { get; set; }
    }
}
