using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using singToSeminar.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace singToSeminar.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        // GET: api/<BookingController>
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            using (var context = new ApplikationDbContext())
            {
                var bookings = context.Bookings.ToArray();
                return bookings;
            }
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public Booking Get(int id)
        {
            using (var context = new ApplikationDbContext())
            {
                var booking = context.Bookings.Find(id);

                return booking;
            }   
        }
        

        // POST api/<BookingController>
        [HttpPost]
        public void Post([FromBody] BookingViewModel bookingVM)
        {
            using( var context = new ApplikationDbContext())
            {
                var booking = new Booking
                {
                    name = bookingVM.name,
                    surname = bookingVM.surname,
                    phone = bookingVM.phone,
                    email = bookingVM.email,
                    seminarId = bookingVM.seminarId,
                    createdAt = DateTime.Now
                };
                context.Bookings.Add(booking);
                context.SaveChanges();
            }
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Booking booking)
        {
            using (var context = new ApplikationDbContext())
            {
                var bookingToUpdate = context.Bookings.Find(id);

                bookingToUpdate.name = booking.name;
                bookingToUpdate.surname = booking.surname;
                bookingToUpdate.phone = booking.phone;
                bookingToUpdate.email = booking.email;

                context.Bookings.Update(bookingToUpdate);
                context.SaveChanges();
            }
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var context = new ApplikationDbContext())
            {
                var bookingToDelete = context.Bookings.Find(id);

                context.Bookings.Remove(bookingToDelete);
                context.SaveChanges();
            }
        }
    }
}
