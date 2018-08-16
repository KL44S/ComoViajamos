using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ReviewTravelFeeling
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public IList<ReviewTravelFeelingReason> ReviewTravelFeelingReasons { get; set; }
    }
}
