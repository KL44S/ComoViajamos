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
        private IAuthService _authService;

        public TravelReviewController()
        {
            this._mapper = new TravelReviewMapper();
            this._travelReviewService = new TravelReviewService();
            this._authService = new RecaptchaService();
        }

        [EnableCors("EnableAll")]
        [HttpPost]
        public ActionResult Post([FromBody] TravelReviewViewModel travelReviewViewModel)
        {
            if (ModelState.IsValid)
            {
                if (this._authService.IsUserAuthorizedAsync(travelReviewViewModel.CaptchaToken))
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
                    return Unauthorized();
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ModelState);
            }
            
        }
    }
}