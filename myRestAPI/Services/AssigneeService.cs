using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using myRestAPI.Models.Assignee;
using myRestAPI.Models.Role;
using myRestAPI.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myRestAPI.Services
{
    public class AssigneeService : IAssigneeService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public AssigneeService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult> CreateAssignees(AssigneeDTO assigneeDTO, int id)
        {
            Assignee assignee = _mapper.Map<AssigneeDTO, Assignee>(assigneeDTO);
            User user = _context.Users.Find(id);
            assignee.Creator = user;
            assignee.CreatorId = user.Id;
            List<Assignee> assignees = _context.Assignees
                .Where(a => a.CreatorId == user.Id)
                .Where(a => a.Name == assigneeDTO.Name)
                .ToList();
            if (assignees.Count == 0)
            {
                _context.Add(assignee);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return new BadRequestResult();
        }

        public List<AssigneeGetDTO> GetAssignees(int userId)
        {
            var assignees = new List<Assignee>();
            var assigneesDTList = new List<AssigneeGetDTO>();
            User user = _context.Users.Find(userId);
            if (user.Role == Role.Admin)
            {
                assignees = _context.Assignees
                    .OrderBy(a => a.Name)
                    .ToList();
            } else
            {
                assignees = _context.Assignees
                    .Where(a => a.Creator == user)
                    .OrderBy(a => a.Name)
                    .ToList();
            }
            if (assignees.Count > 0)
            {
                foreach (Assignee assignee in assignees)
                {
                    assigneesDTList.Add(_mapper.Map<Assignee, AssigneeGetDTO>(assignee));
                }
            }
            return assigneesDTList;
        }
    }
}
