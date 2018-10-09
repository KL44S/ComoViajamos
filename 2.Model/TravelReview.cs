using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TravelReview
    {
        public int ReviewId { get; set; }
        public String UserId { get; set; }
        public DateTime DatetimeFrom { get; set; }
        public DateTime DatetimeUntil { get; set; }
        public ReviewTravelFeeling TravelFeeling { get; set; }
        public ReviewTransport ReviewTransport { get; set; }
        public String Comments { get; set; }
    }
}
