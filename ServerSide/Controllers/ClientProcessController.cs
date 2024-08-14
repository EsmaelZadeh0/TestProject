using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServerSide.Models;
using SystemInfo.Application.Services.ClientSystemInfos.Commands;

namespace ServerSide.Controllers;

public class ClientProcessController(IMediator mediator) : Controller
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] ClientInfoModel model)
    {
        var result = await _mediator.Send(new AddInfo.Command
        {
            Numbers = model.Numbers,
            CpuProcess = model.CpuProccess,
            RamProcess = model.RamProccess
        });

        return Ok(result);
    }
}
