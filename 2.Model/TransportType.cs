using System;
using System.Collections.Generic;

namespace Model
{
    public class TransportType
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public IList<TravelFeelingReason> TravelFeelingReasons { get; set; }
    }
}
