using API.CQRS.Commands;
using API.Wrappers;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EntrevistaTecnicaEXP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Response<bool>> CreateInvoice(NewInvoiceCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
            
        }
    }
}
