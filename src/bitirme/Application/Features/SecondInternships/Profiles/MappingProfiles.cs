using Application.Features.SecondInternships.Commands.Create;
using Application.Features.SecondInternships.Commands.Delete;
using Application.Features.SecondInternships.Commands.Update;
using Application.Features.SecondInternships.Queries.GetById;
using Application.Features.SecondInternships.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SecondInternships.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSecondInternshipCommand, SecondInternship>();
        CreateMap<SecondInternship, CreatedSecondInternshipResponse>();

        CreateMap<UpdateSecondInternshipCommand, SecondInternship>();
        CreateMap<SecondInternship, UpdatedSecondInternshipResponse>();

        CreateMap<DeleteSecondInternshipCommand, SecondInternship>();
        CreateMap<SecondInternship, DeletedSecondInternshipResponse>();

        CreateMap<SecondInternship, GetByIdSecondInternshipResponse>();

        CreateMap<SecondInternship, GetListSecondInternshipListItemDto>();
        CreateMap<IPaginate<SecondInternship>, GetListResponse<GetListSecondInternshipListItemDto>>();
    }
}