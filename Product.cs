using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_COBRA
{
    class Product
    {
        string family;
        string code;
        string name;
        short price_buy;
        short price_sell;


        public string Code { get => code; set => code = value; }
        public string Family { get => family; set => family = value; }
        public string Name { get => name; set => name = value; }
        public short Price_buy { get => price_buy; set => price_buy = value; }
        public short Price_sell { get => price_sell; set => price_sell = value; }
    }
}
