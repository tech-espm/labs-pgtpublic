using PGTPublic.Common.WebClient;
using PGTPublic.Gateway.PGTData.Requests;
using PGTPublic.Gateway.PGTData.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PGTPublic.Gateway.PGTData
{
    public interface IReviewClient
    {

    }

    public class ReviewClient : IReviewClient
    {
        public string ApiEndPoint { get; private set; }


        public ReviewClient(AppSetting configuration)
        {
            ApiEndPoint = configuration.PGTData + "/api/Review";
        }

        public async Task<ReviewResult> Get(string ReviewID)
        {
            try
            {
                WebClientOfT<ReviewResult> client = new WebClientOfT<ReviewResult>();

                var result = await client.GetByIdAsync(ApiEndPoint, ReviewID);
                return result;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ReviewResult> Post(ReviewRequest request)
        {
            try
            {
                WebClientOfT<ReviewResult> client = new WebClientOfT<ReviewResult>();

                var result = await client.PostJsonAsync(ApiEndPoint, request);
                return result;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
