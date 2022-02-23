using API.Wrappers;
using AutoMapper;
using Domain;
using Domain.Dtos;
using Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.CQRS.Queries
{
    public class GetAllInvoiceQuery : IRequest<Response<List<InvoiceDto>>>
    {
        public class GetAllInvoiceQueryHandler : IRequestHandler<GetAllInvoiceQuery, Response<List<InvoiceDto>>>
        {
            private readonly IRepository<Invoice> _repository;
            private readonly IMapper _mapper;

            public GetAllInvoiceQueryHandler(IRepository<Invoice> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Response<List<InvoiceDto>>> Handle(GetAllInvoiceQuery request, CancellationToken cancellationToken)
            {
                var invoices = _repository.GetAll();

                var invoicesDto = _mapper.Map<List<InvoiceDto>>(invoices);

                return new Response<List<InvoiceDto>>(invoicesDto);
            }
        }

    }
}
