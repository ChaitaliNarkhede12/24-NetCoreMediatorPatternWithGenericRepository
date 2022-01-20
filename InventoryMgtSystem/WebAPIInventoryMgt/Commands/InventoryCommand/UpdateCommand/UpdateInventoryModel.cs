using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIInventoryMgt.Handler.InventoryCommand;

namespace WebAPIInventoryMgt.Commands.InventoryCommand.UpdateCommand
{
    public class UpdateInventoryModel : IRequest<InventoryModel>
    {
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
