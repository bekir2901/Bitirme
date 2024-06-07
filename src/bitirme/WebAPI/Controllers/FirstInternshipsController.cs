using Application.Features.FirstInternships.Commands.Create;
using Application.Features.FirstInternships.Commands.Delete;
using Application.Features.FirstInternships.Commands.Update;
using Application.Features.FirstInternships.Queries.GetById;
using Application.Features.FirstInternships.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FirstInternshipsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedFirstInternshipResponse>> Add([FromBody] CreateFirstInternshipCommand command)
    {
        CreatedFirstInternshipResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedFirstInternshipResponse>> Update([FromBody] UpdateFirstInternshipCommand command)
    {
        UpdatedFirstInternshipResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedFirstInternshipResponse>> Delete([FromRoute] int id)
    {
        DeleteFirstInternshipCommand command = new() { Id = id };

        DeletedFirstInternshipResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdFirstInternshipResponse>> GetById([FromRoute] int id)
    {
        GetByIdFirstInternshipQuery query = new() { Id = id };

        GetByIdFirstInternshipResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListFirstInternshipQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFirstInternshipQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListFirstInternshipListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}