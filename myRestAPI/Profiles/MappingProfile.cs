using AutoMapper;
using myRestAPI.Models;
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
        }
    }
}
