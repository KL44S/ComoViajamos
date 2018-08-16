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
        private ITransportBranchService _transportBranchService;

        public TransportBranchController()
        {
            this._transportBranchService = new TransportBranchService();
        }

        [HttpGet]
        public ActionResult Get(int? id, int? transportId)
        {
            if (id.HasValue)
            {
                TransportBranch transportBranch = this._transportBranchService.GetTransportBranchById(id.Value);

                return Ok(transportBranch);
            }
            else
            {
                if (transportId.HasValue)
                {
                    IList<TransportBranch> transportBranches;
                    transportBranches = this._transportBranchService.GetTransportBranchByTransportId(transportId.Value);

                    return Ok(transportBranches);
                }
                else
                {
                    return BadRequest();
                }
            }
        }
    }
}