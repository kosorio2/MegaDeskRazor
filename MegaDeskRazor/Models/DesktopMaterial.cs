using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskRazor.Models

{
    public class DesktopMaterial
    {
        
        public int DesktopMaterialId { get; set; }

        [Display(Name = "Desktop Material")]
        public string DesktopMaterialName { get; set; } // This will hold the data, like laminate, oak, etc. 

        public decimal DesktopMaterialPrice { get; set; }
    }
}
