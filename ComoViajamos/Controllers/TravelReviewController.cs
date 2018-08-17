using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComoViajamos.Mappers.Implementations;
using ComoViajamos.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services.Abstractions;
using Services.Implementations;

namespace ComoViajamos.Controllers
{
    public class TravelReviewController : BaseController
    {
        private TravelReviewMapper _mapper;
        private ITravelReviewService _travelReviewService;

        public TravelReviewController()
        {
            this._mapper = new TravelReviewMapper();
            this._travelReviewService = new TravelReviewService();
        }

        [HttpPost]
        public ActionResult Post(TravelReviewViewModel travelReviewViewModel)
        {
            if (ModelState.IsValid)
            {
                TravelReview travelReview = this._mapper.MapViewModel(travelReviewViewModel);
                String errorMessage = this._travelReviewService.GetValidationError(travelReview);

                if (String.IsNullOrEmpty(errorMessage))
                {
                    this._travelReviewService.CreateTravelReview(travelReview);

                    return Ok();
                }
                else
                {
                    return UnprocessableEntity(errorMessage);
                }
            }
            else
            {
                return UnprocessableEntity(ModelState);
            }
            
        }
    }
}