using DataAccess.Abstractions;
using DataAccess.Factories;
using Model;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
    public class TravelReviewService : ITravelReviewService
    {
        private ISaveRepository<TravelReview> _saveRepository;

        public TravelReviewService()
        {
            this._saveRepository = RepositoryFactory.GetRepository<TravelReview>();
        }

        public void CreateTravelReview(TravelReview travelReview)
        {
            throw new NotImplementedException();
        }

        public string GetValidationError(TravelReview travelReview)
        {
            throw new NotImplementedException();
        }
    }
}
