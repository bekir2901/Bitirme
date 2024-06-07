using Application.Features.FirstInternships.Commands.Create;
using Application.Features.FirstInternships.Commands.Delete;
using Application.Features.FirstInternships.Commands.Update;
using Application.Features.FirstInternships.Queries.GetById;
using Application.Features.FirstInternships.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.FirstInternships.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateFirstInternshipCommand, FirstInternship>();
        CreateMap<FirstInternship, CreatedFirstInternshipResponse>();

        CreateMap<UpdateFirstInternshipCommand, FirstInternship>();
        CreateMap<FirstInternship, UpdatedFirstInternshipResponse>();

        CreateMap<DeleteFirstInternshipCommand, FirstInternship>();
        CreateMap<FirstInternship, DeletedFirstInternshipResponse>();

        CreateMap<FirstInternship, GetByIdFirstInternshipResponse>();

        CreateMap<FirstInternship, GetListFirstInternshipListItemDto>();
        CreateMap<IPaginate<FirstInternship>, GetListResponse<GetListFirstInternshipListItemDto>>();
    }
}