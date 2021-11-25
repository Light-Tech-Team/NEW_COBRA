using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_COBRA.ENTITY
{
    class BonsEntity
    {
        private byte IDBON;
        private byte Ncbons;
        private string BnDate;
        private string DatePaie ;
        private float MONTANTB;
        private float PAIEMENTB;
        private float SOLDB;

        public byte Id { get => IDBON; set => IDBON = value; }
        public byte NcBons { get => Ncbons; set => Ncbons = value; }
        public string Date { get => BnDate; set => BnDate = value; }
        public string DATEPAIEMENT { get => DatePaie; set => DatePaie = value; }
        public float MONTANT{ get => MONTANTB; set => MONTANTB = value; }
        public float PAIEMENT { get => PAIEMENTB; set => PAIEMENTB = value; }
        public float SOLD { get => SOLDB; set => SOLDB = value; }



    }
}
