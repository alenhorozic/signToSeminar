
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace singToSeminar.Context
{
    public class Booking
    {
        public int id { get; set; }

        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int seminarId { get; set; }
        public DateTime createdAt { get; set; }
    }
}