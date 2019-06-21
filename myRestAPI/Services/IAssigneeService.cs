using myRestAPI.Models;
using System.Collections.Generic;

namespace myRestAPI.Services
{
    public interface IAssigneeService
    {
        List<Assignee> GetAssignees();
    }
}
