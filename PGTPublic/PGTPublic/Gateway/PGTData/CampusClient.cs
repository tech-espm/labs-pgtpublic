using PGTPublic.Common.WebClient;
using PGTPublic.Gateway.PGTData.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PGTPublic.Gateway.PGTData
{
    public interface ICampusClient
    {

    }

    public class CampusClient : ICampusClient
    {
        public string ApiEndPoint { get; private set; }

        public CampusClient(AppSetting configuration)
        {
            ApiEndPoint = configuration.PGTData + "/api/Campus";
        }

        public async Task<List<CampusResult>> GetAll()
        {
            try
            {
                WebClientOfT<List<CampusResult>> client = new WebClientOfT<List<CampusResult>>();

                var result = await client.GetAsync(ApiEndPoint);
                return result;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
