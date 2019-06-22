using myRestAPI.Models;
using myRestAPI.Models.User;
using System.Collections.Generic;

namespace myRestAPI.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User userParam, string password = null);
        void Delete(int id);
        List<TodoGetDTO> GetUserTodos(long id);
    }
}
