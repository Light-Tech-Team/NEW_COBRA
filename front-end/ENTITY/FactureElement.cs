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

        public byte Id { get => idFactureElement; set => idFactureElement = value; }
        public string Family { get => familyProduct; set => familyProduct = value; } 
        public string CodeProduct { get => codeProduct; set => codeProduct = value; }
        public string NameProduct { get => nameProduct; set => nameProduct = value; }
        public float PRICEUNIT { get => price_buy; set => price_buy = value; }
        public byte QTE { get => quantity; set => quantity = value; }
        public float AMOUNT { get => amount; set => amount = value; }
    }
}
