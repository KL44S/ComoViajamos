using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TravelReview
    {
        public String UserId { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeUntil { get; set; }
        public ReviewTravelFeeling TravelFeeling { get; set; }
        public ReviewTransport ReviewTransport { get; set; }
        public String Comments { get; set; }
    }
}
