using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL.Interfaces
{
    public interface IAssigneeService
    {
        Assignee CreateAssignee(string name);
        Assignee ReadById(int id);
        List<Assignee> ReadAll(int id);
        Assignee UpdateAssignee(int id);
        Assignee DeleteAssignee(int id);
    }
}
