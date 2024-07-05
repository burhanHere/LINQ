using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Item_mast
    {
        public int ItemId { get; set; }
        public string ItemDes { get; set; }
    }

    // Defining the Purchase class with InvNo, ItemId, and PurQty properties
    internal class Purchase
    {
        public int InvNo { get; set; }
        public int ItemId { get; set; }
        public int PurQty { get; set; }
    }
}
