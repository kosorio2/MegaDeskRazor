using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeskRazor.Models
{
    //enums
    // public enum DesktopMaterial
    // {
    // Laminate,
    // Oak,
    //Rosewood,
    //Veneer,
    // Pine

public class Desk
    {
        //Constants 
        public const short MIN_WIDTH = 24;
        public const short MAX_WIDTH = 96;
        public const short MIN_DEPTH = 12;
        public const short MAX_DEPTH = 48;
        public const short MIN_DESK_DRAWERS = 0;
        public const short MAX_DESK_DRAWERS = 7;

        //Properties
        public int DeskId { get; set; } //This is a primary key 
        public decimal Width { get; set; }

        public decimal Depth { get; set; }

        [Display(Name = "Number of Drawers")]
        public  int NumberOfDrawers { get; set; }

        [Display(Name = "Desktop Material")]
        public int DesktopMaterialId { get; set; } //This is replacing the enum, it is now a foreign key pointing to the DesktopMaterial class

        //navigation properties
        [Display(Name = "Desktop Material")] // This is the name that the users will see 
        public DesktopMaterial SurfaceMaterial { get; set; } //This is in the Desktop Material class 
    }
}
