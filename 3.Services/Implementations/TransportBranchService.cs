using DataAccess.Abstractions;
using DataAccess.Factories;
using Exceptions;
using Model;
using Services.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementations
{
    public class TransportBranchService : ITransportBranchService
    {
        private IGetRepository<TransportBranch> _repository;

        public TransportBranchService()
        {
            this._repository = RepositoryFactory.GetRepository<TransportBranch>();
        }

        public TransportBranch GetTransportBranchById(int id)
        {
            IList<TransportBranch> transportBranches = this._repository.GetAllByConditions(x => x.Id == id);

            if (transportBranches.Count.Equals(0))
            {
                throw new ObjectNotFoundException();
            }
            else
            {
                TransportBranch transportBranch = transportBranches.FirstOrDefault();

                return transportBranch;
            }
        }

        public IList<TransportBranch> GetTransportBranchByTransportId(int transportId)
        {
            IList<TransportBranch> transportBranches = this._repository.GetAllByConditions(x => x.TransportId == transportId);

            return transportBranches;
        }
    }
}
