using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PXLFunds.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PXLFunds.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundInfoController : ControllerBase
    {
        private readonly IFundInfoRepository _fundInfoRepo;

        public FundInfoController(IFundInfoRepository fundinfoRepo) {
            _fundInfoRepo = fundinfoRepo;
        }
    }
}
