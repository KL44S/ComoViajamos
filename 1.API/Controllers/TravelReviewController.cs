using System;
using ComoViajamos.Mappers.Implementations;
using ComoViajamos.ViewModels;
using Microsoft.AspNetCore.Cors;
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

        [EnableCors("EnableAll")]
        [HttpPost]
        public ActionResult Post([FromBody] TravelReviewViewModel travelReviewViewModel)
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
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, errorMessage);
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ModelState);
            }
            
        }
    }
}