using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL.Validator
{
    public interface IValidator
    {
        void DefaultValidation(Assignee assignee);
        void DeleteAssignee(int id);
        void UpdateAssignee(int id);
    }
}
