using System;
using System.Collections.Generic;

namespace Model
{
    public class TransportType
    {
        public int TransportTypeId { get; set; }
        public String Description { get; set; }
        public IList<TravelFeelingReason> TravelFeelingReasons { get; set; }
    }
}
