using DataAccess.Abstractions;
using DataAccess.Factories;
using Exceptions;
using Model;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace Services.Implementations
{
    public class TravelReviewService : ITravelReviewService
    {
        private static int _firstReviewId = 1;

        private ISaveRepository<TravelReview> _saveRepository;
        private IGetRepository<TravelReview> _getRepository;

        private ITransportService _transportService;
        private ITravelFeelingService _travelFeelingService;

        private void FillTravelReviewWithIdIfItIsNecessary(TravelReview travelReview)
        {
            if (travelReview.ReviewId.Equals(0))
            {
                travelReview.ReviewId = _firstReviewId;

                TravelReview existingReview = this._getRepository.GetFirstByConditionsAndSort(x => true, x => x.ReviewId, Constants.SortTypes.Desc);
                
                if (existingReview != null)
                {
                    travelReview.ReviewId = existingReview.ReviewId + 1;
                }
            }
        }

        private void FillOrientationIfItIsNecessary(ReviewTransport transport)
        {
            ReviewTransportBranch branch = transport.ReviewTransportBranch;
            ReviewTransportBranchOrientation orientation = branch.ReviewTransportBranchOrientation;

            if (String.IsNullOrEmpty(orientation.Description))
            {
                TransportBranchOrientation existingOrientation = this._transportService.GetTransportBranchOrientationById(transport.TransportId, branch.BranchId, orientation.OrientationId);
                orientation.Description = existingOrientation.Description;
            }
        }

        private void FillBranchIfItIsNecessary(ReviewTransport transport)
        {
            ReviewTransportBranch branch = transport.ReviewTransportBranch;

            if (String.IsNullOrEmpty(branch.Description))
            {
                TransportBranch existingBranch = this._transportService.GetTransportBranchById(transport.TransportId, branch.BranchId);
                branch.Description = existingBranch.Description;
            }

            this.FillOrientationIfItIsNecessary(transport);
        }

        private void FillTransportIfItIsNecessary(ReviewTransport transport)
        {
            if (String.IsNullOrEmpty(transport.Description))
            {
                Transport existingTransport = this._transportService.GetTransportById(transport.TransportId);

                transport.Description = existingTransport.Description;
            }

            this.FillBranchIfItIsNecessary(transport);
        }

        private void FillReasonsIfItIsNecessary(ReviewTravelFeeling feeling)
        {
            foreach (ReviewTravelFeelingReason reason in feeling.ReviewTravelFeelingReasons)
            {
                if (String.IsNullOrEmpty(reason.Description))
                {
                    TravelFeelingReason existingReason = this._travelFeelingService.GetTravelFeelingReasonById(feeling.FeelingId, reason.ReasonId);

                    reason.Description = existingReason.Description;
                }
            }
        } 

        private void FillFeelingIfItIsNecessary(ReviewTravelFeeling feeling)
        {
            if (String.IsNullOrEmpty(feeling.Description))
            {
                TravelFeeling existingFeeling = this._travelFeelingService.GetTravelFeelingById(feeling.FeelingId);

                feeling.Description = existingFeeling.Description;
            }

            this.FillReasonsIfItIsNecessary(feeling);
        }

        private void FillTravelReviewIfItIsNecessary(TravelReview travelReview)
        {
            this.FillTravelReviewWithIdIfItIsNecessary(travelReview);
            this.FillTransportIfItIsNecessary(travelReview.ReviewTransport);
            this.FillFeelingIfItIsNecessary(travelReview.TravelFeeling);
        }

        public TravelReviewService()
        {
            IRepository<TravelReview> repository = RepositoryFactory.GetRepository<TravelReview>();

            this._saveRepository = repository;
            this._getRepository = repository;

            this._transportService = new TransportService();
            this._travelFeelingService = new TravelFeelingService();
        }

        public void CreateTravelReview(TravelReview travelReview)
        {
            this.FillTravelReviewIfItIsNecessary(travelReview);

            this._saveRepository.Save(travelReview);
        }

        public string GetValidationError(TravelReview travelReview)
        {
            //TODO: implementar
            return String.Empty;
        }
    }
}
