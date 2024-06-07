using Application.Features.Messages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Messages.Commands.Update;

public class UpdateMessageCommand : IRequest<UpdatedMessageResponse>
{
    public int Id { get; set; }
    public required int StudentId { get; set; }
    public required int LecturerId { get; set; }
    public required string Text { get; set; }
    public required string Title { get; set; }

    public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommand, UpdatedMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private readonly MessageBusinessRules _messageBusinessRules;

        public UpdateMessageCommandHandler(IMapper mapper, IMessageRepository messageRepository,
                                         MessageBusinessRules messageBusinessRules)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _messageBusinessRules = messageBusinessRules;
        }

        public async Task<UpdatedMessageResponse> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            Message? message = await _messageRepository.GetAsync(predicate: m => m.Id == request.Id, cancellationToken: cancellationToken);
            await _messageBusinessRules.MessageShouldExistWhenSelected(message);
            message = _mapper.Map(request, message);

            await _messageRepository.UpdateAsync(message!);

            UpdatedMessageResponse response = _mapper.Map<UpdatedMessageResponse>(message);
            return response;
        }
    }
}