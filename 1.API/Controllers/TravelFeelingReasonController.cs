using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services.Abstractions;
using Services.Implementations;

namespace ComoViajamos.Controllers
{
    public class TravelFeelingReasonController : BaseController
    {
        private ITravelFeelingReasonService _travelFeelingReasonService;

        public TravelFeelingReasonController()
        {
            this._travelFeelingReasonService = new TravelFeelingReasonService();
        }

        [EnableCors("EnableAll")]
        [HttpGet]
        public ActionResult Get(int travelFeelingId, int transportTypeId)
        {
            IList<TravelFeelingReason> travelFeelingReasons = this._travelFeelingReasonService.GetAllTravelFeelingReasons(
                                                                    travelFeelingId, transportTypeId);

            return Ok(travelFeelingReasons);
        }
    }
}