using DataAccess.Abstractions;
using DataAccess.Factories;
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

        public TravelFeelingService()
        {
            this._repository = RepositoryFactory.GetRepository<TravelFeeling>();
        }

        public IList<TravelFeeling> GetAllTravelFeelings()
        {
            IList<TravelFeeling> travelFeelings = this._repository.GetAll();

            return travelFeelings;
        }
    }
}
