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
    public class TransportTypeService : ITransportTypeService
    {
        private IGetRepository<TransportType> _repository;

        public TransportTypeService()
        {
            this._repository = RepositoryFactory.GetRepository<TransportType>();
        }

        public IList<TransportType> GetAllTransportTypes()
        {
            IList<TransportType> transportTypes = this._repository.GetAll();

            return transportTypes;
        }

        public TransportType GetTransportTypeById(int id)
        {
            IList<TransportType> transportTypes = this._repository.GetAllByConditions(x => x.Id == id);

            if (transportTypes.Count.Equals(0))
            {
                throw new ObjectNotFoundException();
            }
            else
            {
                TransportType transportType = transportTypes.FirstOrDefault();

                return transportType;
            }
        }
    }
}
