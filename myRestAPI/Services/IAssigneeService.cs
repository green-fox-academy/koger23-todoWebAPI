using Microsoft.AspNetCore.Mvc;
using myRestAPI.Models.Assignee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myRestAPI.Services
{
    public interface IAssigneeService
    {
        List<AssigneeGetDTO> GetAssignees(int userId);
        Task<ActionResult> CreateAssignees(AssigneeDTO assigneeDTO, int userId);
    }
}
