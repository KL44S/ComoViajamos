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
        private IList<TransportBranch> _branches;
        private TransportBranch _branch;

        public TransportBranchService()
        {
            this._repository = RepositoryFactory.GetRepository<TransportBranch>();
        }

        public TransportBranch GetTransportBranchById(int transportId, int branchId)
        {
            if (this._branch == null)
            {
                this._branch = this._repository.GetFirstByConditions(x => x.TransportId == transportId && x.BranchId == branchId);

                if (this._branch == null)
                {
                    throw new ObjectNotFoundException();
                }
            }

            return this._branch;
        }

        public IList<TransportBranch> GetTransportBranchByTransportId(int transportId)
        {
            if (this._branches == null)
            {
                this._branches = this._repository.GetAllByConditions(x => x.TransportId == transportId);
            }

            return this._branches;
        }

        public TransportBranchOrientation GetTransportBranchOrientationById(int transportId, int branchId, int orientationId)
        {
            TransportBranch branch = this.GetTransportBranchById(transportId, branchId);
            TransportBranchOrientation orientation = branch.Orientations.FirstOrDefault(x => x.OrientationId == orientationId);

            if (orientation == null)
            {
                throw new ObjectNotFoundException();
            }

            return orientation;
        }
    }
}
