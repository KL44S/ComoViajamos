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
        private ITransportBranchService _branchService;

        public TransportService()
        {
            this._repository = RepositoryFactory.GetRepository<Transport>();
            this._branchService = new TransportBranchService();
        }

        public IList<Transport> GetAllTransports()
        {
            IList<Transport> transports = this._repository.GetAll();

            return transports;
        }

        public TransportBranch GetTransportBranchById(int transportId, int branchId)
        {
            return this._branchService.GetTransportBranchById(transportId, branchId);
        }

        public IList<TransportBranch> GetTransportBranchByTransportId(int transportId)
        {
            return this._branchService.GetTransportBranchByTransportId(transportId);
        }

        public TransportBranchOrientation GetTransportBranchOrientationById(int transportId, int branchId, int orientationId)
        {
            return this._branchService.GetTransportBranchOrientationById(transportId, branchId, orientationId);
        }

        public Transport GetTransportById(int id)
        {
            IList<Transport> transports = this._repository.GetAllByConditions(x => x.TransportId == id);

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
