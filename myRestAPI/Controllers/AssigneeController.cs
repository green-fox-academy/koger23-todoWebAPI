using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myRestAPI.Models;
using myRestAPI.Services;
using System.Collections.Generic;

namespace myRestAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AssigneeController : ControllerBase
    {
        private readonly IAssigneeService assigneeService;

        public AssigneeController(IAssigneeService assigneeService)
        {
            this.assigneeService = assigneeService;
        }

        [HttpGet]
        public List<Assignee> GetAssignees()
        {
            return assigneeService.GetAssignees();
        }
    }
}