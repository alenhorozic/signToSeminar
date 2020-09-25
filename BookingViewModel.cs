using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace singToSeminar
{
    public class BookingViewModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int seminarId { get; set; }
    }
}
