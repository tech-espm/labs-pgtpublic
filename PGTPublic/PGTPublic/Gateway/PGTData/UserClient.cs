using PGTPublic.Common.WebClient;
using PGTPublic.Gateway.PGTData.Requests;
using PGTPublic.Gateway.PGTData.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PGTPublic.Gateway.PGTData
{
    public interface IUserClient
    {

    }

    public class UserClient : IUserClient
    {
        public string ApiEndPoint { get; private set; }


        public UserClient(AppSetting configuration)
        {
            ApiEndPoint = configuration.PGTData + "/api/User";
        }

        public async Task<UserResult> Get(string UserID)
        {
            try
            {
                WebClientOfT<UserResult> client = new WebClientOfT<UserResult>();

                var result = await client.GetByIdAsync(ApiEndPoint, UserID);
                return result;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserResult>> GetAll()
        {
            try
            {
                WebClientOfT<List<UserResult>> client = new WebClientOfT<List<UserResult>>();

                var result = await client.GetAsync(ApiEndPoint);
                return result;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserResult> Post(UserRequest request)
        {
            try
            {
                WebClientOfT<UserResult> client = new WebClientOfT<UserResult>();

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
