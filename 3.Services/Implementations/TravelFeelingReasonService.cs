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
    public class TravelFeelingReasonService : ITravelFeelingReasonService
    {
        private IGetRepository<TravelFeelingReason> _reasonRepository;
        private IGetRepository<TravelFeelingReasonsPerFeelingAndTransportType> _relationsRepository;

        public TravelFeelingReasonService()
        {
            this._reasonRepository = RepositoryFactory.GetRepository<TravelFeelingReason>();
            this._relationsRepository = RepositoryFactory.GetRepository<TravelFeelingReasonsPerFeelingAndTransportType>();
        }

        public IList<TravelFeelingReason> GetAllTravelFeelingReasons(int travelFeelingId, int transportTypeId)
        {
            IList<TravelFeelingReason> reasons = new List<TravelFeelingReason>();

            IList<TravelFeelingReasonsPerFeelingAndTransportType> relations = this._relationsRepository.GetAllByConditions(x => 
                                                x.TransportTypeId == transportTypeId && x.TravelFeelingId == travelFeelingId);

            if (relations.Count > 0)
            {
                IList<int> reasonsIds = relations.Select(x => x.TravelFeelingReasonId).ToList();

                reasons = this._reasonRepository.GetAllByConditions(x => reasonsIds.Contains(x.ReasonId));
            }

            return reasons;
        }

        public TravelFeelingReason GetTravelFeelingReasonById(int travelFeelingId, int reasonId)
        {
            TravelFeelingReason reason = null;

            IList<TravelFeelingReasonsPerFeelingAndTransportType> relations = this._relationsRepository.GetAllByConditions(x =>
                                                x.TravelFeelingId == travelFeelingId && x.TravelFeelingReasonId == reasonId);

            if (relations.Count > 0)
            {
                IList<int> reasonsIds = relations.Select(x => x.TravelFeelingReasonId).ToList();

                reason = this._reasonRepository.GetFirstByConditions(x => reasonsIds.Contains(x.ReasonId));
            }

            if (reason == null)
            {
                throw new ObjectNotFoundException();
            }

            return reason;
        }
    }
}
