using API.CQRS.Commands;
using API.CQRS.Queries;
using API.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Response<Customer>> Create(NewCustomerCommand command)
        {
            var result = await _mediator.Send(command);

            return result;

        }

        [HttpGet]
        public async Task<Response<IEnumerable<Customer>>> GetAll([FromQuery] GetAllCustomersQuery query)
        {
            var result = await _mediator.Send(query);

            return result;

        }
    }
}