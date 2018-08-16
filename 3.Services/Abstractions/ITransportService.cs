using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstractions
{
    public interface ITransportService
    {
        Transport GetTransportById(int id);
        IList<Transport> GetTransportByTransportTypeId(int transportTypeId);
        IList<Transport> GetAllTransports();
    }
}
