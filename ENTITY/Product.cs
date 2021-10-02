using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_COBRA
{
    class Product
    {
        private byte id;
        private byte family_code;
        private string code;
        private string name;
        private short price_buy;
        private short price_sell;



        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public short Price_buy { get => price_buy; set => price_buy = value; }
        public short Price_sell { get => price_sell; set => price_sell = value; }
        public byte Family_code { get => family_code; set => family_code = value; }
        public byte Id { get => id; set => id = value; }


       


    }
}
