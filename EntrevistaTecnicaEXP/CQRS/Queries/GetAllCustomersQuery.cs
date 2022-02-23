using API.Wrappers;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.CQRS.Queries
{
    public class GetAllCustomersQuery : IRequest<Response<IEnumerable<Customer>>>
    {
        public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, Response<IEnumerable<Customer>>>
        {
            private readonly IRepository<Customer> _repository;


            public GetAllCustomersQueryHandler(IRepository<Customer> repository)
            {
                _repository = repository;

            }

            public async Task<Response<IEnumerable<Customer>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
            {
                var customers = _repository.GetAll();

                return new Response<IEnumerable<Customer>>(customers);
            }
        }

    }
}
