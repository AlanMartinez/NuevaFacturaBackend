using API.Wrappers;
using AutoMapper;
using Domain;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.CQRS.Commands
{
    public class NewInvoiceCommand : IRequest<Response<bool>>
    {
        public int CustomerId { get; set; }
        public IEnumerable<int> ProductsList { get; set; }

        public class NewInvoiceCommandHandler : IRequestHandler<NewInvoiceCommand, Response<bool>>
        {
            private readonly IRepository<Invoice> _repositoryInvoice;
            private readonly IRepository<Customer> _repositoryCustomer;
            private readonly IRepository<Product> _repositoryProduct;
            private readonly IMapper _mapper;

            public NewInvoiceCommandHandler(IRepository<Invoice> repositoryInvoice
                , IRepository<Customer> repositoryCustomer
                , IRepository<Product> repositoryProduct
                , IMapper mapper)
            {
                _repositoryInvoice = repositoryInvoice;
                _repositoryCustomer = repositoryCustomer;
                _repositoryProduct = repositoryProduct;
                _mapper = mapper;
            }

            public async Task<Response<bool>> Handle(NewInvoiceCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var invoice = _mapper.Map<Invoice>(request);

                    var customer = await _repositoryCustomer.GetByIdAsync(invoice.CustomerId);
                    if (customer == null)
                        throw new CustomException("cliente no existe.");


                    invoice.Items = await CreateInvoiceDetails(invoice, request.ProductsList);
                    invoice.InvoiceNumber = new Random().Next(int.MinValue, int.MaxValue);
                    invoice.CalculateTotal();

                    var newInvoice = await _repositoryInvoice.Add(invoice);


                    return new Response<bool>(true);

                }
                catch (Exception e)
                {
                    return new Response<bool>($"Error al crear cliente, msg: {e.Message}");
                }
            }

            private async Task<ICollection<InvoiceItem>> CreateInvoiceDetails(Invoice invoice, IEnumerable<int> items)
            {
                var details = new List<InvoiceItem>();

                foreach (var item in items)
                {
                    var product = await _repositoryProduct.GetByIdAsync(item);
                    if (product == null)
                        throw new CustomException($"producto {product} no existe.");

                    details.Add(
                        new InvoiceItem()
                        {
                            Product = product,
                        }
                    );
                }

                return details;
            }
        }

    }
}
