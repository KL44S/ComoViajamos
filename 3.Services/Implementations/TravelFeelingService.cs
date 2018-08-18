using DataAccess.Abstractions;
using DataAccess.Factories;
using Exceptions;
using Model;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
    public class TravelFeelingService : ITravelFeelingService
    {
        private IGetRepository<TravelFeeling> _repository;
        private ITravelFeelingReasonService _reasonService;

        public TravelFeelingService()
        {
            this._reasonService = new TravelFeelingReasonService();
            this._repository = RepositoryFactory.GetRepository<TravelFeeling>();
        }

        public IList<TravelFeeling> GetAllTravelFeelings()
        {
            IList<TravelFeeling> travelFeelings = this._repository.GetAll();

            return travelFeelings;
        }

        public TravelFeeling GetTravelFeelingById(int feelingId)
        {
            TravelFeeling feeling = this._repository.GetFirstByConditions(x => x.FeelingId == feelingId);

            if (feeling == null)
            {
                throw new ObjectNotFoundException();
            }

            return feeling;
        }

        public TravelFeelingReason GetTravelFeelingReasonById(int feelingId, int reasonId)
        {
            return this._reasonService.GetTravelFeelingReasonById(feelingId, reasonId);
        }
    }
}
