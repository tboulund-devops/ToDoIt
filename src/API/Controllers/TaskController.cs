using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {
        [HttpGet]
        public IEnumerable<Task> Get(string searchTerm)
        {
            throw new NotImplementedException();
        }
        
        [HttpPost]
        public int Post(Task task)
        {
            throw new NotImplementedException();
        }
        
        [HttpPut]
        public void Put(Task task)
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