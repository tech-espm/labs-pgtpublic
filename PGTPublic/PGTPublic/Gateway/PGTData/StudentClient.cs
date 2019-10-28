using PGTPublic.Common.WebClient;
using PGTPublic.Gateway.PGTData.Requests;
using PGTPublic.Gateway.PGTData.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PGTPublic.Gateway.PGTData
{
    public interface IStudentClient
    {

    }

    public class StudentClient : IStudentClient
    {
        public string ApiEndPoint { get; private set; }


        public StudentClient(AppSetting configuration)
        {
            ApiEndPoint = configuration.PGTData + "/api/Student";
        }

        public async Task<StudentResult> Get(string StudentID)
        {
            try
            {
                WebClientOfT<StudentResult> client = new WebClientOfT<StudentResult>();

                var result = await client.GetByIdAsync(ApiEndPoint, StudentID);
                return result;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StudentResult> Post(StudentRequest request)
        {
            try
            {
                WebClientOfT<StudentResult> client = new WebClientOfT<StudentResult>();

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
