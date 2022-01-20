using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIInventoryMgt.Handler.InventoryCommand;

namespace WebAPIInventoryMgt.Commands.InventoryCommand.DeleteCommand
{
    public class DeleteInventoryModel : IRequest<DeleteInventoryResponse>
    {
        public int Id { get; set; }
    }
}
