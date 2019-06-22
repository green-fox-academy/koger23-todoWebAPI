using AutoMapper;
using myRestAPI.Models;
using myRestAPI.Models.Assignee;
using myRestAPI.Models.User;

namespace myRestAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoDTO, Todo>();
            CreateMap<Todo, TodoDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Todo, TodoGetDTO>();
            CreateMap<TodoGetDTO, Todo>();
            CreateMap<Assignee, AssigneeDTO>();
            CreateMap<AssigneeDTO, Assignee>();
            CreateMap<Assignee, AssigneeGetDTO>();
            CreateMap<AssigneeGetDTO, Assignee>();
        }
    }
}
