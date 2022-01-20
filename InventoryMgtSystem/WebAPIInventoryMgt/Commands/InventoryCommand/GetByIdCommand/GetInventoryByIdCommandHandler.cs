using ApplicationLayer.Interfaces;
using AutoMapper;
using DataAccess.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAPIInventoryMgt.Commands.InventoryCommand.GetByIdCommand;
using WebAPIInventoryMgt.Handler.InventoryCommand;

namespace WebAPIInventoryMgt.Commands.InventoryCommand
{
    public class GetInventoryByIdCommandHandler : IRequestHandler<GetInventoryByIdModel, InventoryModel>
    {
        private readonly InventoryDBContext _context;
        private readonly IInventoryAppService _repository;
        private readonly IMapper _mapper;

        public GetInventoryByIdCommandHandler(InventoryDBContext context,
            IInventoryAppService repository,
            IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<InventoryModel> Handle(GetInventoryByIdModel request, CancellationToken cancellationToken)
        {
            var inventoryObject = await _repository.GetInventoryById(request.Id);
            return _mapper.Map<InventoryModel>(inventoryObject);

        }
    }
}
