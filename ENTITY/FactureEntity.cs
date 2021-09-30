using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_COBRA.ENTITY
{
    
    class FactureEntity
    {
        byte id;
        public struct FactureElement
        {
            public string familyProduct { get; set; }
            public  Product product { get; set; }

            public Byte Quantity { get; set; }

            public float amount { get; set; }

        }
        public float totalAmount;

    }
}
