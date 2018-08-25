using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services.Abstractions;
using Services.Implementations;

namespace ComoViajamos.Controllers
{
    public class TransportController : BaseController
    {
        private ITransportService _transportService;

        public TransportController()
        {
            this._transportService = new TransportService();
        }

        [EnableCors("EnableAll")]
        [HttpGet]
        public ActionResult Get(int? transportId, int? transportTypeId)
        {
            if (transportId.HasValue)
            {
                Transport transport = this._transportService.GetTransportById(transportId.Value);

                return Ok(transport);
            }
            else
            {
                IList<Transport> transports;

                if (transportTypeId.HasValue)
                {
                    transports = this._transportService.GetTransportByTransportTypeId(transportTypeId.Value);
                }
                else
                {
                    transports = this._transportService.GetAllTransports();
                }

                return Ok(transports);
            }
        }
    }
}