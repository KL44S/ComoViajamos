using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ReviewTransport
    {
        public int TransportId { get; set; }
        public String Description { get; set; }
        public ReviewTransportBranch ReviewTransportBranch { get; set; } 
    }
}
