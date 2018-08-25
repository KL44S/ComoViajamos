using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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

        [EnableCors("EnableAll")]
        [HttpGet]
        public ActionResult Get(int? transportTypeId)
        {
            if (transportTypeId.HasValue)
            {
                TransportType transportType = this._transportTypeService.GetTransportTypeById(transportTypeId.Value);

                return Ok(transportType);
            }
            else
            {
                IList<TransportType> transportTypes = this._transportTypeService.GetAllTransportTypes();

                return Ok(transportTypes);
            }
        }
    }
}
