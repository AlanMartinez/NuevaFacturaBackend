using API.Wrappers;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.CQRS.Queries
{
    public class GetAllProductsQuery : IRequest<Response<IEnumerable<Product>>>
    {
        public class GetAllCustomersQueryHandler : IRequestHandler<GetAllProductsQuery, Response<IEnumerable<Product>>>
        {
            private readonly IRepository<Product> _repository;

            public GetAllCustomersQueryHandler(IRepository<Product> repository)
            {
                _repository = repository;
            }

            public async Task<Response<IEnumerable<Product>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = _repository.GetAll();

                return new Response<IEnumerable<Product>>(products);
            }
        }

    }
}
