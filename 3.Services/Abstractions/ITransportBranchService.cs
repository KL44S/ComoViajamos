using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstractions
{
    public interface ITransportBranchService
    {
        TransportBranch GetTransportBranchById(int id);
        IList<TransportBranch> GetTransportBranchByTransportId(int transportId);
    }
}
