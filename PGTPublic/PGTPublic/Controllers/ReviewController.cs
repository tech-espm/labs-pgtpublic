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
    public class ReviewController : ControllerBase
    {

        private readonly ReviewClient _reviewClient;

        public ReviewController(IReviewClient reviewClient)
        {
            _reviewClient = (ReviewClient)reviewClient;

        }

        [HttpGet]
        public async Task<IActionResult> Get(string ReviewID)
        {
            try
            {
                var entity = await _reviewClient.Get(ReviewID);
                return new MyOkResult(entity);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex);
            }
        }

        [HttpGet("Report")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var entity = await _reviewClient.GetAll();
                return new MyOkResult(entity);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex);
            }
        }

        [HttpGet("Historic")]
        public async Task<IActionResult> GetHistoric(string StartDate, string EndDate)
        {
            try
            {
                var entity = await _reviewClient.GetHistoric(StartDate, EndDate);
                return new MyOkResult(entity);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ReviewRequest request)
        {

            try
            {

                var entity = await _reviewClient.Post(request);
                return new MyOkResult(entity);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex);
            }
        }
    }
}