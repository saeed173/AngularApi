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
    public class AddEqupmentNameController : ControllerBase
    {
        private readonly DataContext context;
        public AddEqupmentNameController(DataContext context)
        {
            this.context = context;
        }



        [HttpPost]
        public async Task<bool> Post( [FromBody] Models.EqupmentName soal)
        {
          var b= context.equpmentNames.ToList();
            foreach (var item in b)
            {
                if (soal.Name == item.Name)
                {
                    return false;
                }
            }
            EqupmentName a = new EqupmentName();
            a.Name = soal.Name;
            a.Active = true;
            context.equpmentNames.Add(a);
            await context.SaveChangesAsync();
            return true;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Models.EqupmentName>> Get()
        {          
            return context.equpmentNames;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Models.EqupmentName equ)
        {
            if (id != equ.EquipmentName_ID)
            {
                return BadRequest();
            }
            EqupmentName a = context.equpmentNames.Find(id);
            
            if(equ.Active)
            {
                a.Active = false;
                context.Entry(a).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(equ);
            }
            a.Active = true;
            context.Entry(a).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(equ);

        }



    }
}