using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace singToSeminar.Context
{
    public enum Status
    {
        comming,
        canceled,
        finished
    }


    public class Seminar
    {
        public int id { get; set; }

        public string name { get; set; }
        public string topic { get; set; }
        public string speaker { get; set; }
        public DateTime dateAndTime { get; set; }
        public string durationTime { get; set; }
        public string address { get; set; }
        public string sal { get; set; }
        public int numberOfSeats { get; set; }
        public Status status  { get; set; }

        public List<Booking> bookings { set; get; }
    }
}