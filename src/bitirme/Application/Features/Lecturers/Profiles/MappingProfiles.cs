using Application.Features.Lecturers.Commands.Create;
using Application.Features.Lecturers.Commands.Delete;
using Application.Features.Lecturers.Commands.Update;
using Application.Features.Lecturers.Queries.GetById;
using Application.Features.Lecturers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Lecturers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateLecturerCommand, Lecturer>();
        CreateMap<Lecturer, CreatedLecturerResponse>();

        CreateMap<UpdateLecturerCommand, Lecturer>();
        CreateMap<Lecturer, UpdatedLecturerResponse>();

        CreateMap<DeleteLecturerCommand, Lecturer>();
        CreateMap<Lecturer, DeletedLecturerResponse>();

        CreateMap<Lecturer, GetByIdLecturerResponse>();

        CreateMap<Lecturer, GetListLecturerListItemDto>();
        CreateMap<IPaginate<Lecturer>, GetListResponse<GetListLecturerListItemDto>>();
    }
}