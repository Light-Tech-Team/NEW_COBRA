using NEW_COBRA.ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace NEW_COBRA.Models
{
    internal class BuyInvoiceModel : BaseModel
    {
        private byte id;
        private float montant;
        private DateTime date;
        public BuyInvoiceModel()
        {
        }

        public byte Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        public float Montant { get { return montant; } set { montant = value; OnPropertyChanged("Montant"); } }
        public DateTime Date { get { return date; } set { date = value; OnPropertyChanged("Date"); } }


    }
}
