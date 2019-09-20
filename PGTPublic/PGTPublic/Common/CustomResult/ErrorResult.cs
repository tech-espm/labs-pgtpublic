using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PGTPublic.Common.WebClient;
using ObjectResult = PGTPublic.Common.WebClient.ObjectResult;

namespace PGTPublic.Common.CustomResult
{
    public class ErrorResult : IActionResult
    {
        private readonly BaseObjectResult _result;

        public ErrorResult(object value, params string[] errors)
        {
            _result = new BaseObjectResult
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Result = value,
                Errors = errors.ToList()
            };
        }

        public ErrorResult(params string[] errors)
        {
            _result = new BaseObjectResult
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Errors = errors.ToList()
            };
        }


        public ErrorResult(Exception ex)
        {

            if (ex is WebClientOfTException)
            {
                ObjectResult obj = ((WebClientOfTException)ex).ErrorResult;

                _result = new BaseObjectResult
                {
                    StatusCode = obj.StatusCode,
                    Message = obj.Message,
                    Errors = obj.Errors
                };

                /* _result = new BaseObjectResult
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Errors = ((WebClientOfTException)ex).ErrorResult.Errors
                };*/
            }
            else
            {
                _result = new BaseObjectResult
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Errors = new List<String>()
                };

                //{ String.Concat(ex.Message, " - ", ex.InnerException) }
                Exception loopException = ex;

                while (loopException != null)
                {
                    _result.Errors.Add(loopException.Message);
                    loopException = loopException.InnerException;
                }
            }


        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new Microsoft.AspNetCore.Mvc.ObjectResult(_result)
            {
                StatusCode = StatusCodes.Status500InternalServerError

            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
