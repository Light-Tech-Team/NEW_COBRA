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
        private string codeProduct;
        private string nameProduct;
        private float price_buy;
        private byte quantity;
        private float amount;

        public byte IdFactureElement { get => idFactureElement; set => idFactureElement = value; }
        public string FamilyProduct { get => familyProduct; set => familyProduct = value; } 
        public string CodeProduct { get => codeProduct; set => codeProduct = value; }
        public string NameProduct { get => nameProduct; set => nameProduct = value; }
        public float Price_buy { get => price_buy; set => price_buy = value; }
        public byte Quantity { get => quantity; set => quantity = value; }
        public float Amount { get => amount; set => amount = value; }
    }
}
