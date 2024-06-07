using Application.Features.Messages.Commands.Create;
using Application.Features.Messages.Commands.Delete;
using Application.Features.Messages.Commands.Update;
using Application.Features.Messages.Queries.GetById;
using Application.Features.Messages.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedMessageResponse>> Add([FromBody] CreateMessageCommand command)
    {
        CreatedMessageResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedMessageResponse>> Update([FromBody] UpdateMessageCommand command)
    {
        UpdatedMessageResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedMessageResponse>> Delete([FromRoute] int id)
    {
        DeleteMessageCommand command = new() { Id = id };

        DeletedMessageResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdMessageResponse>> GetById([FromRoute] int id)
    {
        GetByIdMessageQuery query = new() { Id = id };

        GetByIdMessageResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListMessageQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMessageQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListMessageListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}