using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services.Abstractions;
using Services.Implementations;

namespace ComoViajamos.Controllers
{
    public class TransportTypeController : BaseController
    {
        private ITransportTypeService _transportTypeService;

        public TransportTypeController()
        {
            this._transportTypeService = new TransportTypeService();
        }

        [HttpGet]
        public ActionResult Get()
        {
            IList<TransportType> transportTypes = this._transportTypeService.GetAllTransportTypes();

            return Ok(transportTypes);
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            TransportType transportType = this._transportTypeService.GetTransportTypeById(id);

            return Ok(transportType);
        }
    }
}
