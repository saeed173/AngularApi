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
    public class AkharController : ControllerBase
    {
        private readonly DataContext context;
        public AkharController(DataContext context)
        {
            this.context = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await (from a in context.equpments.Include(a => a.eequpment)
                              where a.Usage == id
                              select new Equpment
                              {
                                  Equipment_ID = a.Equipment_ID,
                                  EquipmentName_ID = a.EquipmentName_ID,
                                  eequpment = a.eequpment,
                                  Brand = a.Brand,
                                  Model = a.Model,
                                  Active = a.Active,
                                  TechSpec = a.TechSpec,
                                  Usage = a.Usage
                              }).ToListAsync();
           

            return Ok(book);
        }

    }
}