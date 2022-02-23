using API.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.CQRS.Commands
{
    public class NewCustomerCommand : IRequest<Response<Customer>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public class GetAllInvoiceQueryHandler : IRequestHandler<NewCustomerCommand, Response<Customer>>
        {
            private readonly IRepository<Customer> _repository;
            private readonly IMapper _mapper;

            public GetAllInvoiceQueryHandler(IRepository<Customer> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Response<Customer>> Handle(NewCustomerCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var customer = _mapper.Map<Customer>(request);

                    var newCustomer = await _repository.Add(customer);
               

                    return new Response<Customer>(newCustomer);

                }
                catch (Exception e)
                {
                    return new Response<Customer>($"Error al crear cliente, msg: {e.Message}");
                }
            }
        }

    }
}
