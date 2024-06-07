using Application.Features.SecondInternships.Commands.Create;
using Application.Features.SecondInternships.Commands.Delete;
using Application.Features.SecondInternships.Commands.Update;
using Application.Features.SecondInternships.Queries.GetById;
using Application.Features.SecondInternships.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SecondInternshipsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSecondInternshipResponse>> Add([FromBody] CreateSecondInternshipCommand command)
    {
        CreatedSecondInternshipResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSecondInternshipResponse>> Update([FromBody] UpdateSecondInternshipCommand command)
    {
        UpdatedSecondInternshipResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSecondInternshipResponse>> Delete([FromRoute] int id)
    {
        DeleteSecondInternshipCommand command = new() { Id = id };

        DeletedSecondInternshipResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSecondInternshipResponse>> GetById([FromRoute] int id)
    {
        GetByIdSecondInternshipQuery query = new() { Id = id };

        GetByIdSecondInternshipResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListSecondInternshipQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSecondInternshipQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSecondInternshipListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}