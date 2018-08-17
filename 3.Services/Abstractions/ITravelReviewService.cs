using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstractions
{
    public interface ITravelReviewService
    {
        String GetValidationError(TravelReview travelReview);
        void CreateTravelReview(TravelReview travelReview);
    }
}
