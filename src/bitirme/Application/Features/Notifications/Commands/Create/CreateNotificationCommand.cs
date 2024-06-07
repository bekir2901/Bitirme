using Application.Features.Notifications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Notifications.Commands.Create;

public class CreateNotificationCommand : IRequest<CreatedNotificationResponse>
{
    public required string Title { get; set; }
    public required string Text { get; set; }
    public required int LecturerId { get; set; }

    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, CreatedNotificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly INotificationRepository _notificationRepository;
        private readonly NotificationBusinessRules _notificationBusinessRules;

        public CreateNotificationCommandHandler(IMapper mapper, INotificationRepository notificationRepository,
                                         NotificationBusinessRules notificationBusinessRules)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
            _notificationBusinessRules = notificationBusinessRules;
        }

        public async Task<CreatedNotificationResponse> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            Notification notification = _mapper.Map<Notification>(request);

            await _notificationRepository.AddAsync(notification);

            CreatedNotificationResponse response = _mapper.Map<CreatedNotificationResponse>(notification);
            return response;
        }
    }
}