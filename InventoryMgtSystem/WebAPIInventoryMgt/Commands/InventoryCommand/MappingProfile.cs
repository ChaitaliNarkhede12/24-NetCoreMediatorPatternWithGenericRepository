using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIInventoryMgt.Commands.InventoryCommand.UpdateCommand;
using WebAPIInventoryMgt.Handler.InventoryCommand;

namespace WebAPIInventoryMgt.Commands.InventoryCommand
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Bootstraps the mapping of base Role models
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Inventory, InventoryModel>();
            //.ForMember(dest => dest.IsEnabled, opt => opt.MapFrom(src => src.StatusId == Constants.Entity.ActiveStatus))
            //.ForMember(dest => dest.CreatedByUser, opt => opt.ExplicitExpansion())
            //.ForMember(dest => dest.LastUpdatedByUser, opt => opt.ExplicitExpansion())
            //.ForMember(dest => dest.Sites, opt =>
            //{
            //    opt.MapFrom(src => src.Sites);
            //    opt.ExplicitExpansion();
            //})
            // .ForMember(dest => dest.RegionIds, opt =>
            // {
            //     opt.MapFrom(src => src.CountryRegions.Select(cr => cr.RegionId));
            //     opt.ExplicitExpansion();
            // })
            //.ForMember(dest => dest.Regions, opt =>
            //{
            //    opt.MapFrom(src => src.CountryRegions.Select(cr => cr.Region));
            //    opt.ExplicitExpansion();
            //});

            CreateMap<AddInventoryModel, Inventory>();
            //.ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.IsEnabled ? StatusType.Active : StatusType.Inactive));

            CreateMap<UpdateInventoryModel, Inventory>();
                   //.ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.IsEnabled ? StatusType.Active : StatusType.Inactive));

        }
    }
}
