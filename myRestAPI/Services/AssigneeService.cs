using myRestAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace myRestAPI.Services
{
    public class AssigneeService : IAssigneeService
    {
        private readonly ApplicationContext _context;

        public AssigneeService(ApplicationContext context)
        {
            _context = context;
        }
       
        public List<Assignee> GetAssignees()
        {
            return _context.Assignees.ToList();
        }
    }
}
