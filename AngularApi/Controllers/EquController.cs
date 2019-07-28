using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class EquController : ControllerBase
    {
        private readonly DataContext context;
        public EquController(DataContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] Models.Set se)
        {

            context.sets.Add(se);
            await context.SaveChangesAsync();
            return true;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Models.Locatio>> Get()
        {
            return context.locations;
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Models.Equpment>> Get(int id)
        {
            var luser1 = from a in context.equpments
                         where a.EquipmentName_ID == id && a.Usage ==0
                         select a;
            var myuser = luser1.ToList();

            return myuser;
        }


        [HttpPost("{id}")]
        public async Task<bool> Post(int id, [FromBody] Models.Equpment soal)
        {
            int b = id-1;
            
            for (int i =0; i<=b; i++)
            {
                Equpment a = new Equpment();
                a.EquipmentName_ID = soal.EquipmentName_ID;
                a.Brand = soal.Brand;
                a.Model = soal.Model;
                a.Pyear = soal.Pyear;
                a.PurchaseTime = soal.PurchaseTime;
                a.Active = true;
                a.TechSpec = soal.TechSpec;
                a.Usage = 0;

                context.equpments.Add(a);
                await context.SaveChangesAsync();
            }
            return true;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Models.Locatio equ)
        {
            if (id != equ.Location_id)
            {
                return BadRequest();
            }         
            context.Entry(equ).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(equ);

        }



    }
}