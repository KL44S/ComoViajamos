using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstractions
{
    public interface ITransportBranchService
    {
        TransportBranch GetTransportBranchById(int transportId, int branchId);
        IList<TransportBranch> GetTransportBranchByTransportId(int transportId);
        TransportBranchOrientation GetTransportBranchOrientationById(int transportId, int branchId, int orientationId);
    }
}
