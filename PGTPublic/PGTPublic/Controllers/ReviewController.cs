using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PGTPublic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReview()
        {
            var json = new WebClient().DownloadString("https://localhost:44361/api/Review");
            return json;
        }
        [Route("Home/About")]
        public IActionResult About()
        {
            return View();
        }
        [Route("Home/Contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}