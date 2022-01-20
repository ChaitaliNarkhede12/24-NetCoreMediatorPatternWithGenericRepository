using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
