using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TransportBranch
    {
        public int Id { get; set; }
        public int TransportId { get; set; }
        public String Description { get; set; }
        public IList<TransportBranchOrientation> Orientations { get; set; }
    }
}
