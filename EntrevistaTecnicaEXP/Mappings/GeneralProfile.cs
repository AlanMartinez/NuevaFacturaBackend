using API.CQRS.Commands;
using API.CQRS.Queries;
using AutoMapper;
using Domain;
using Domain.Dtos;
using Domain.Entities;

namespace API.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<InvoiceDto, Invoice>();
            

            CreateMap<NewCustomerCommand, Customer>();
            CreateMap<NewInvoiceCommand, Invoice>();
            CreateMap<GetAllCustomersQuery, Customer>();
            CreateMap<GetAllInvoiceQuery, Invoice>();
        }
    }
}
