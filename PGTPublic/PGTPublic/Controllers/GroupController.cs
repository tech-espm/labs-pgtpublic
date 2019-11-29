using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PGTPublic.Common.CustomResult;
using PGTPublic.Gateway.PGTData;
using PGTPublic.Gateway.PGTData.Requests;

namespace PGTPublic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {


        private readonly GroupClient _groupClient;

        public GroupController(IGroupClient groupClient)
        {
            _groupClient = (GroupClient)groupClient;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string GroupID)
        {
            try
            {
                var entity = await _groupClient.Get(GroupID);
                return new MyOkResult(entity);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var entity = await _groupClient.GetAll();
                return new MyOkResult(entity);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GroupRequest request)
        {

            try
            {

                var entity = await _groupClient.Post(request);
                return new MyOkResult(entity);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex);
            }
        }
    }
}