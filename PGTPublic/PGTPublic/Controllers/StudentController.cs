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
    public class StudentController : ControllerBase
    {

        private readonly StudentClient _studentClient;

        public StudentController(IStudentClient studentClient)
        {
            _studentClient = (StudentClient)studentClient;

        }

        [HttpGet]
        public async Task<IActionResult> Get(string GroupID)
        {
            try
            {
                var entity = await _studentClient.Get(GroupID);
                return new MyOkResult(entity);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]StudentRequest request)
        {

            try
            {

                var entity = await _studentClient.Post(request);
                return new MyOkResult(entity);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex);
            }
        }
    }
}