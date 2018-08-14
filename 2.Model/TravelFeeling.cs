using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TravelFeeling
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public IList<TravelFeelingReason> TravelFeelingReasons { get; set; }
    }
}
