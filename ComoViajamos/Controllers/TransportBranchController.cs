using System;
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
    public class TransportBranchController : BaseController
    {
        private ITransportService _transportService;

        public TransportBranchController()
        {
            this._transportService = new TransportService();
        }

        [HttpGet]
        public ActionResult Get(int? transportId, int? branchId)
        {
            if (transportId.HasValue)
            {
                if (branchId.HasValue)
                {
                    TransportBranch transportBranch = this._transportService.GetTransportBranchById(transportId.Value, branchId.Value);

                    return Ok(transportBranch);
                }
                else
                {
                    IList<TransportBranch> transportBranches;
                    transportBranches = this._transportService.GetTransportBranchByTransportId(transportId.Value);

                    return Ok(transportBranches);
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}