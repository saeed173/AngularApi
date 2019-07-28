using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {

        private readonly DataContext context;
        public RoomController(DataContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<bool> Post([FromBody] Models.Room room)
        {       
            if(room.location_id == 0 )
            {
                return false;
            }

            context.rooms.Add(room);
            await context.SaveChangesAsync();
            return true;
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Models.Room>> Get(int id)
        {
            var luser1 = from a in context.rooms
                         where a.location_id == id
                         select a;
            var myuser = luser1.ToList();

            return myuser;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuez([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quez = await context.rooms.FindAsync(id);
            if (quez == null)
            {
                return NotFound();
            }

            context.rooms.Remove(quez);
            await context.SaveChangesAsync();

            return Ok(quez);
        }


    }
}