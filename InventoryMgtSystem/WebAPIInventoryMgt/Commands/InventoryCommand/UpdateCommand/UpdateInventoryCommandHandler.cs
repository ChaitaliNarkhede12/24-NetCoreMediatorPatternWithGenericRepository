using ApplicationLayer.Interfaces;
using AutoMapper;
using DataAccess.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAPIInventoryMgt.Handler.InventoryCommand;

namespace WebAPIInventoryMgt.Commands.InventoryCommand.UpdateCommand
{
    public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryModel, InventoryModel>
    {
        private readonly InventoryDBContext _context;
        private readonly IInventoryAppService _repository;
        private readonly IMapper _mapper;

        public UpdateInventoryCommandHandler(InventoryDBContext context,
            IInventoryAppService repository,
            IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<InventoryModel> Handle(UpdateInventoryModel request, CancellationToken cancellationToken)
        {
            var inventory = _mapper.Map<Inventory>(request);

            await _repository.UpdateInventory(inventory);

            _context.SaveChanges();

            return _mapper.Map<InventoryModel>(inventory);
        }
    }
}
