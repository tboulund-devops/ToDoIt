using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssigneeController : Controller
    {
        [HttpGet]
        public IEnumerable<Assignee> Get()
        {
            throw new NotImplementedException();
        }
        
        [HttpPost]
        public int Post(Assignee task)
        {
            throw new NotImplementedException();
        }
        
        [HttpDelete]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}