using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using singToSeminar.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace singToSeminar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarsController : ControllerBase
    {
        // GET: api/<SeminarsController>
        [HttpGet]
        public IEnumerable<Seminar> Get()
        {
            using (var context = new ApplikationDbContext()) 
            {
                var seminars = context.Seminars.Include(c => c.bookings).ToArray();
                return seminars;
            }
        }

        // GET api/<SeminarsController>/5
        [HttpGet("{id}")]
        public Seminar Get(int id)
        {
            using (var context = new ApplikationDbContext())
            {
                var seminar = context.Seminars.Find(id);
                return seminar;
            }      
        }

        // POST api/<SeminarsController>
        [HttpPost]
        public void Post([FromBody] SeminarViewModel seminarVM)
        {
            using (var context = new ApplikationDbContext())
            {
                var seminar = new Seminar
                {
                    name = seminarVM.name,
                    topic = seminarVM.topic,
                    speaker = seminarVM.speaker,
                    dateAndTime = seminarVM.dateAndTime,
                    durationTime = seminarVM.durationTime,
                    address = seminarVM.address,
                    sal = seminarVM.sal,
                    numberOfSeats = seminarVM.numberOfSeats,
                    status = (Status)seminarVM.status
                };
                context.Seminars.Add(seminar);
                context.SaveChanges();
            }
        }

        // PUT api/<SeminarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Seminar  seminar)
        {
            using (var context = new ApplikationDbContext())
            {
                var seminarToUpdate = context.Seminars.Find(id);

                seminarToUpdate.name = seminarToUpdate.name;
                seminarToUpdate.topic = seminar.topic;
                seminarToUpdate.speaker = seminar.speaker;
                seminarToUpdate.dateAndTime = seminar.dateAndTime;
                seminarToUpdate.durationTime = seminar.durationTime;
                seminarToUpdate.address = seminar.address;
                seminarToUpdate.sal = seminar.sal;
                seminarToUpdate.numberOfSeats = seminar.numberOfSeats;
                seminarToUpdate.status = (Status)seminar.status;


                context.Seminars.Update(seminarToUpdate);
                context.SaveChanges();
            }
        }

        // DELETE api/<SeminarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var context = new ApplikationDbContext())
            {
                var seminarToDelete = context.Seminars.Find(id);

                context.Seminars.Remove(seminarToDelete);
                context.SaveChanges();
            }
        }
    }
}
