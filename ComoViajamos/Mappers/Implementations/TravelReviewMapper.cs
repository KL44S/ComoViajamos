using ComoViajamos.Mappers.Abstractions;
using ComoViajamos.ViewModels;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComoViajamos.Mappers.Implementations
{
    public class TravelReviewMapper : Mapper<TravelReview, TravelReviewViewModel>
    {
        private ReviewTransportBranchOrientation GetReviewTransportBranchOrientation(TravelReviewViewModel viewModel)
        {
            ReviewTransportBranchOrientation orientation = new ReviewTransportBranchOrientation();
            orientation.OrientationId = viewModel.TransportBranchOrientationId;

            return orientation;
        }

        private ReviewTransportBranch GetReviewTransportBranch(TravelReviewViewModel viewModel)
        {
            ReviewTransportBranch transportBranch = new ReviewTransportBranch();
            transportBranch.BranchId = viewModel.TransportBranchId;
            transportBranch.ReviewTransportBranchOrientation = this.GetReviewTransportBranchOrientation(viewModel);

            return transportBranch;
        }

        private ReviewTransport GetReviewTransport(TravelReviewViewModel viewModel)
        {
            ReviewTransport transport = new ReviewTransport();
            transport.TransportId = viewModel.TransportId;
            transport.ReviewTransportBranch = this.GetReviewTransportBranch(viewModel);

            return transport;
        }

        private IList<ReviewTravelFeelingReason> GetReviewTravelFeelingReasons(TravelReviewViewModel viewModel)
        {
            IList<ReviewTravelFeelingReason> reasons = new List<ReviewTravelFeelingReason>();

            foreach (int id in viewModel.TravelFeelingReasonIds)
            {
                ReviewTravelFeelingReason reason = new ReviewTravelFeelingReason();
                reason.ReasonId = id;

                reasons.Add(reason);
            }

            return reasons;
        }

        private ReviewTravelFeeling GetReviewTravelFeeling(TravelReviewViewModel viewModel)
        {
            ReviewTravelFeeling feeling = new ReviewTravelFeeling();
            feeling.FeelingId = viewModel.TravelFeelingId;
            feeling.ReviewTravelFeelingReasons = this.GetReviewTravelFeelingReasons(viewModel);

            return feeling;
        }

        private TravelReview GetTravelReview(TravelReviewViewModel viewModel)
        {
            TravelReview travelReview = new TravelReview();
            travelReview.Comments = viewModel.Comments;
            travelReview.Date = viewModel.Date;
            travelReview.TimeFrom = viewModel.TimeFrom;
            travelReview.TimeUntil = viewModel.TimeUntil;
            travelReview.TravelFeeling = this.GetReviewTravelFeeling(viewModel);
            travelReview.ReviewTransport = this.GetReviewTransport(viewModel);

            return travelReview;
        }

        public override TravelReview MapViewModel(TravelReviewViewModel viewModel)
        {
            return this.GetTravelReview(viewModel);
        }
    }
}
