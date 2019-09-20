using PGTPublic.Common.WebClient;
using PGTPublic.Gateway.PGTData.Requests;
using PGTPublic.Gateway.PGTData.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PGTPublic.Gateway.PGTData
{
    public interface IGroupClient
    {

    }

    public class GroupClient : IGroupClient
    {
        public string ApiEndPoint { get; private set; }


        public GroupClient(AppSetting configuration)
        {
            ApiEndPoint = configuration.PGTData + "/api/Group";
        }

        public async Task<GroupResult> Get(string GroupID)
        {
            try
            {
                WebClientOfT<GroupResult> client = new WebClientOfT<GroupResult>();

                var result = await client.GetByIdAsync(ApiEndPoint, GroupID);
                return result;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GroupResult> Post(GroupRequest request)
        {
            try
            {
                WebClientOfT<GroupResult> client = new WebClientOfT<GroupResult>();

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
