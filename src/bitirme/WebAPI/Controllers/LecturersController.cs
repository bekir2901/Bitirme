using Application.Features.Lecturers.Commands.Create;
using Application.Features.Lecturers.Commands.Delete;
using Application.Features.Lecturers.Commands.Update;
using Application.Features.Lecturers.Queries.GetById;
using Application.Features.Lecturers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LecturersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedLecturerResponse>> Add([FromBody] CreateLecturerCommand command)
    {
        CreatedLecturerResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedLecturerResponse>> Update([FromBody] UpdateLecturerCommand command)
    {
        UpdatedLecturerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedLecturerResponse>> Delete([FromRoute] int id)
    {
        DeleteLecturerCommand command = new() { Id = id };

        DeletedLecturerResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdLecturerResponse>> GetById([FromRoute] int id)
    {
        GetByIdLecturerQuery query = new() { Id = id };

        GetByIdLecturerResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListLecturerQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLecturerQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListLecturerListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}