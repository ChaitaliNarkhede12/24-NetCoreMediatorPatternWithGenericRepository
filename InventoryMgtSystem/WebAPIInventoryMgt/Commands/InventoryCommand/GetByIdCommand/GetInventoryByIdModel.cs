using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIInventoryMgt.Handler.InventoryCommand;

namespace WebAPIInventoryMgt.Commands.InventoryCommand.GetByIdCommand
{
    public class GetInventoryByIdModel : IRequest<InventoryModel>
    {
        public int Id { get; set; }
    }
}
