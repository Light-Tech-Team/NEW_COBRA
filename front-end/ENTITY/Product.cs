using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_COBRA
{
    public class Product
    {
            
        private byte family_code;
        private string code;
        private string name;
        private int price_buy;
        private int price_sell;

        public string CODE { get => code; set => code = value; }
        public string NAME { get => name; set => name = value; }
        public int PRICE_BUY { get => price_buy; set => price_buy = value; }
        public int PRICE_SELL { get => price_sell; set => price_sell = value; }
        public byte ID_FAMILY { get => family_code; set => family_code = value; }
     
    }
}
