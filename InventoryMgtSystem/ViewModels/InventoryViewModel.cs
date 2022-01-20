using System;

namespace ViewModels
{
    public class InventoryViewModel
    {
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
