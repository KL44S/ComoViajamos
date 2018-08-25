using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services.Abstractions;
using Services.Implementations;

namespace ComoViajamos.Controllers
{
    public class TravelFeelingController : BaseController
    {
        private ITravelFeelingService _travelFeelingService;

        public TravelFeelingController()
        {
            this._travelFeelingService = new TravelFeelingService();
        }

        [EnableCors("EnableAll")]
        [HttpGet]
        public ActionResult Get()
        {
            IList<TravelFeeling> travelFeelings = this._travelFeelingService.GetAllTravelFeelings();

            return Ok(travelFeelings);
        }
    }
}