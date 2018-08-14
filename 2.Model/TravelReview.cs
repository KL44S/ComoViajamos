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
        public int TravelFeelingId { get; set; }
        public TravelFeeling TravelFeeling { get; set; }
        public IList<TravelFeelingReason> TravelFeelingReasons { get; set; }
        public String Comments { get; set; }
    }
}
