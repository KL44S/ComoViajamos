using DataAccess.Abstractions;
using DataAccess.Factories;
using Exceptions;
using Model;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Implementations
{
    public class TransportService : ITransportService
    {
        private IGetRepository<Transport> _repository;

        public TransportService()
        {
            this._repository = RepositoryFactory.GetRepository<Transport>();
        }

        public IList<Transport> GetAllTransports()
        {
            IList<Transport> transports = this._repository.GetAll();

            return transports;
        }

        public Transport GetTransportById(int id)
        {
            IList<Transport> transports = this._repository.GetAllByConditions(x => x.Id == id);

            if (transports.Count.Equals(0))
            {
                throw new ObjectNotFoundException();
            }
            else
            {
                Transport transport = transports.FirstOrDefault();

                return transport;
            }
        }

        public IList<Transport> GetTransportByTransportTypeId(int transportTypeId)
        {
            IList<Transport> transports = this._repository.GetAllByConditions(x => x.TransportTypeId == transportTypeId);

            return transports;
        }
    }
}
