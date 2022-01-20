using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIInventoryMgt.Handler.InventoryCommand
{
    public class InventoryModel
    {
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
