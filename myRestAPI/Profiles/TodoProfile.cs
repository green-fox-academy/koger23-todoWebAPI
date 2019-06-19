using AutoMapper;
using myRestAPI.Models;

namespace myRestAPI.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<TodoDTO, Todo>();
            CreateMap<Todo, TodoDTO>();
        }
    }
}
