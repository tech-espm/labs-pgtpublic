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
    public class UserController : ControllerBase
    {

        private readonly UserClient _userClient;

        public UserController(IUserClient userClient)
        {
            _userClient = (UserClient)userClient;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string UserID)
        {
            try
            {
                var entity = await _userClient.Get(UserID);
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
                var entity = await _userClient.GetAll();
                return new MyOkResult(entity);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserRequest request)
        {

            try
            {

                var entity = await _userClient.Post(request);
                return new MyOkResult(entity);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex);
            }
        }
    }
}