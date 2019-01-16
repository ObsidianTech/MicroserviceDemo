using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PictureService.Controllers
{
    [Route("api/[controller]")]
    public class PicturesController : Controller
    {
        private readonly ApplicationDbContext _context {get;set;}
        
        public PictureController(ApplicationDBContext context)
        {
            _context = context;
        }
        
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
        
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
