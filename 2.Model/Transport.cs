using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Transport
    {
        public int TransportId { get; set; }
        public String Description { get; set; }
        public int TransportTypeId { get; set; }
        public TransportType TransportType { get; set; }
        public IList<TransportBranch> Branches { get; set; }
    }
}
