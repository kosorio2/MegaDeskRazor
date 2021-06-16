using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskRazor
{
    public class Delivery
    {
        public int DeliveryId { get; set; }

        public string DeliveryType { get; set; }

        public decimal LessThan1000 { get; set; }

        public decimal Between100And2000 { get; set; }

        public decimal GreaterThan2000 { get; set; }
    }
}
