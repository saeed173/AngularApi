using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalsetController : ControllerBase
    {
        private readonly DataContext context;
        public FinalsetController(DataContext context)
        {
            this.context = context;
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Models.Set>> Get(int id)
        {
            var luser1 = from a in context.sets
                         where a.set_id == id
                         select a;
            var myuser = luser1.ToList();

            return myuser;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Models.E equ)
        {
            var a = context.equpments.ToList();
            Equpment equpment = new Equpment();
            foreach (var item in a)
            {
                if (item.Equipment_ID == id)
                {
                    equpment = item;
                }
            }

            if (equpment.Usage == 0)
            {
                equpment.Usage = equ.Usage;
                context.Entry(equpment).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(equ);
            }
            equpment.Usage = 0;
            context.Entry(equpment).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(equ);
        }



    }
}