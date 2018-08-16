using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstractions
{
    public interface ITransportTypeService
    {
        TransportType GetTransportTypeById(int id);
        IList<TransportType> GetAllTransportTypes();
    }
}
