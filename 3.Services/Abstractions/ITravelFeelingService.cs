using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstractions
{
    public interface ITravelFeelingService
    {
        IList<TravelFeeling> GetAllTravelFeelings();
        TravelFeelingReason GetTravelFeelingReasonById(int feelingId, int reasonId);      
        TravelFeeling GetTravelFeelingById(int feelingId);
    }
}
