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
    public class QuestionController : ControllerBase
    {
        private readonly DataContext context;
        public QuestionController(DataContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Models.TestQuestion>> Get()
        {
            return context.Questions;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Models.Set>> Get(int id)
        {
            var luser1 = from a in context.sets
                         where a.room_id == id
                         select a;
            var myuser = luser1.ToList();

            return myuser;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Models.TestQuestion soal)
        {       

            if(!context.Quezes.Any(q=>q.Id== soal.quezID))
            {
                return StatusCode(404);
            }

            context.Questions.Add(soal);
            await context.SaveChangesAsync();
            return Ok(soal);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] Models.TestQuestion question)
        {
            if(id != question.Id)
            {
                return BadRequest();
            }
            context.Entry(question).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(question);

        }

    }
}