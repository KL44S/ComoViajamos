﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public ActionResult Get(int? id, int? transportTypeId)
        {
            if (id.HasValue)
            {
                Transport transport = this._transportService.GetTransportById(id.Value);

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