using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NEW_COBRA.ENTITY
{
   
    class FactureEntity
    {
        public byte id { get; set; }

        public float totalAmount { get; set; }

        private FactureElement factureElement;

        public DateTime date { get; set; }
        internal FactureElement FactureElement { get => factureElement; set => factureElement = value; }
    }
}
