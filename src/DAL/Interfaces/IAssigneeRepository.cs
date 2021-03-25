﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL.Interfaces
{
    public interface IAssigneeRepository
    {
        Assignee CreateAssignee(Assignee assignee);
        Assignee ReadById(int id);
        IEnumerable<Assignee> ReadAll();
        Assignee UpdateAssignee(int id, Assignee assignee);
        Assignee DeleteAssignee(int id);
    }
}
