using ApplicationLayer.Interfaces;
using AutoMapper;
using DataAccess.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPIInventoryMgt.Handler.InventoryCommand
{
    public class AddInventoryCommandHandler : IRequestHandler<AddInventoryModel, InventoryModel>
    {

        private readonly InventoryDBContext _context;
        private readonly IInventoryAppService _repository;
        private readonly IMapper _mapper;

        public AddInventoryCommandHandler(InventoryDBContext context, 
            IInventoryAppService repository,
            IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<InventoryModel> Handle(AddInventoryModel request, CancellationToken cancellationToken)
        {
            var inventory = _mapper.Map<Inventory>(request);

            await _repository.AddInventory(inventory);

            _context.SaveChanges();

            return _mapper.Map<InventoryModel>(inventory);
        }
    }
}
