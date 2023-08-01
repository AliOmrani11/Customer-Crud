using AutoMapper;
using CrudTest.Shared.Dto.Response.Customer;
using Domain.Entities;

namespace Application.Configs.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerResponse>();
    }
}
