using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Creation;
using Entities.DataTransferObjects.Retrieve;
using Entities.DataTransferObjects.Role;
using Entities.DataTransferObjects.Update;
using Entities.DataTransferObjects.User;
using Entities.Models;
using Entities.Models.PurchaseOrders;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region Company
            CreateMap<Company, CompanyDto>()
            .ForMember(c => c.FullAddress,
            opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<Employee, EmployeeDto>();
            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();
            CreateMap<CompanyForUpdateDto, Company>();
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<UserForManipulationDto, User>();
            CreateMap<Role, RoleDto>();
            CreateMap<IdentityRole, RoleDto>();
            CreateMap<Company, CompanyEmployeesDto>().ForMember(c => c.FullAddress,
            opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country))); ;

            #endregion

            #region Demo
            CreateMap<PurchaseOrderCreationDto, PurchaseOrder>();
            CreateMap<PurchaseOrderDetailCreationDto, PurchaseOrderDetail>();
            #endregion


        }
    }

}
