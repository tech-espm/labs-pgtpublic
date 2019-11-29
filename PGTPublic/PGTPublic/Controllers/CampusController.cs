using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PGTPublic.Common.CustomResult;
using PGTPublic.Gateway.PGTData;

namespace PGTPublic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampusController : ControllerBase
    {


        private readonly CampusClient _campusClient;

        public CampusController(ICampusClient campusClient)
        {
            _campusClient = (CampusClient)campusClient;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var entity = await _campusClient.GetAll();
                return new MyOkResult(entity);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex);
            }
        }
    }
}