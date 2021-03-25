using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL.Validator
{
    public class Validator : IValidator
    {
        public void DefaultValidation(Assignee assignee)
        {
            if (assignee.Name == null)
            {
                throw new NoNullAllowedException();
            }

            if (assignee.Name.Length >= 75)
            {
                throw new ArgumentException();
            }

            if(assignee.Name.Length<=1)
                throw new ArgumentException();
        }

      

        public void DeleteAssignee(int id)
        {
            if (id == null || id <= 0)
                throw new ArgumentNullException("id cannot be null or negative");
        }

        public void UpdateAssignee(int id )
        {
            if (id == null || id <= 0)
                throw new NoNullAllowedException($"id cannot be null");
           
        }
    }
}
