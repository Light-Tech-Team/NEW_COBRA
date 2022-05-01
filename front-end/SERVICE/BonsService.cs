using NEW_COBRA.DATA;
using NEW_COBRA.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_COBRA.SERVICE
{
    class BonsService
    {

        BonsData bn = new BonsData();

        public List<BonsEntity> GetAllBons()
        {

            return bn.GetAllBons();
        }

        public List<BonsElement> GetBons()
        {

            return bn.GetBons();
        }





    }
}
