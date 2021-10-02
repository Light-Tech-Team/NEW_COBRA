using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_COBRA.ENTITY
{
    class FactureElement
    {
        private byte idFactureElement;
        private string familyProduct;
        private Product product;

        private Byte quantity;

        private float amount;

        public byte IdFactureElement { get => idFactureElement; set => idFactureElement = value; }
        public string FamilyProduct { get => familyProduct; set => familyProduct = value; }
        internal Product Product { get => product; set => product = value; } 
        public byte Quantity { get => quantity; set => quantity = value; }
        public float Amount { get => amount; set => amount = value; }
  
    }
}
