using System;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.RequestHelpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateTodoDto, TodoItem>();
        CreateMap<UpdateTodoDto, TodoItem>();
    }
}
