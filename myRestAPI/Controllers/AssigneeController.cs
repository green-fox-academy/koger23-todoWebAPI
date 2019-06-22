using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myRestAPI.Models.Assignee;
using myRestAPI.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public List<AssigneeGetDTO> GetAssignees()
        {
            return assigneeService.GetAssignees(Convert.ToInt32(User.Identity.Name));
        }

        [HttpPost]
        public async Task<ActionResult<Assignee>> CreateAssignee([FromBody] AssigneeDTO assigneeDTO)
        {
            return await assigneeService.CreateAssignees(assigneeDTO, Convert.ToInt32(User.Identity.Name));
        }
    }
}