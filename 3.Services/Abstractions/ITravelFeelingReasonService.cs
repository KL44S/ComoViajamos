using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstractions
{
    public interface ITravelFeelingReasonService
    {
        IList<TravelFeelingReason> GetAllTravelFeelingReasons(int travelFeelingId, int transportTypeId);
        TravelFeelingReason GetTravelFeelingReasonById(int travelFeelingId, int reasonId);
    }
}
