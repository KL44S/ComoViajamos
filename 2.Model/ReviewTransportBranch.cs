using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ReviewTransportBranch
    {
        public int BranchId { get; set; }
        public String Description { get; set; }
        public ReviewTransportBranchOrientation ReviewTransportBranchOrientation { get; set; }
    }
}
