using ApplicationLayer.Interfaces;
using DataAccess.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAPIInventoryMgt.Handler.InventoryCommand;

namespace WebAPIInventoryMgt.Commands.InventoryCommand.DeleteCommand
{
    public class DeleteInventoryCommandHandler : IRequestHandler<DeleteInventoryModel, DeleteInventoryResponse>
    {
        private readonly InventoryDBContext _context;
        private readonly IInventoryAppService _repository;
        public DeleteInventoryCommandHandler(InventoryDBContext context,
            IInventoryAppService repository)
        {
            _context = context;
            _repository = repository;
        }
        public async Task<DeleteInventoryResponse> Handle(DeleteInventoryModel request, CancellationToken cancellationToken)
        {
            var data = await _repository.DeleteInventory(request.Id);
            _context.SaveChanges();

            return new DeleteInventoryResponse()
            {
                Result = true
            };

        }
    }
}
