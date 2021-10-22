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

       

        private List<FactureElement> factureElement;

        public DateTime date { get; set; }
        public List<FactureElement> FactureElement { get => factureElement; set => factureElement = value; }
    }
}
