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
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<Response<IEnumerable<Product>>> GetAll([FromQuery] GetAllProductsQuery query)
        {
            var result = await _mediator.Send(query);

            return result;

        }
    }
}