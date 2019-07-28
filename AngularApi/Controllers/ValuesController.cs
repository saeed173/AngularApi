using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext context;
        public ValuesController(DataContext context)
        {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Models.EqupmentName>> Get()
        {
            var luser1 = from a in context.equpmentNames
                         where a.Active == true
                         select a;
            var myuser = luser1.ToList();

            return myuser;


        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Models.Room>> Get(int id)
        {
            var luser1 = from a in context.rooms
                         where a.room_id == id
                         select a;
            var myuser = luser1.ToList();

            return myuser;


        }

        // POST api/values
        [HttpPost]
        public async Task<bool> Post([FromBody] Models.Locatio loc)
        {

            context.locations.Add(loc);
            await context.SaveChangesAsync();
            return true;
        }
       
      

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {


        }
    }
}
