using System;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {
        [HttpGet]
        public Task[] Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void Post(Task task)
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