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

        public async Task<List<ReviewResult>> GetAll()
        {
            try
            {
                WebClientOfT<List<ReviewResult>> client = new WebClientOfT<List<ReviewResult>>();

                var result = await client.GetAsync(ApiEndPoint + "/Report");
                return result;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<HistoricResult>> GetHistoric(string StartDate, string EndDate)
        {
            try
            {
                WebClientOfT<List<HistoricResult>> client = new WebClientOfT<List<HistoricResult>>();

                var URLQuery = ApiEndPoint + "/Historic?StartDate=" + StartDate + "&EndDate=" + EndDate;

                var result = await client.GetAsync(URLQuery);

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
