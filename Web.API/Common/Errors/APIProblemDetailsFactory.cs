using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;
using Web.API.Common.Http;

namespace Web.API.Common.Errors
{
    public class APIProblemDetailsFactory : ProblemDetailsFactory
    {

        private readonly ApiBehaviorOptions _opcion;

        public APIProblemDetailsFactory(ApiBehaviorOptions opcion)
        {
            _opcion = opcion  ?? throw new ArgumentNullException(nameof(opcion));
        }

        public override ProblemDetails CreateProblemDetails(HttpContext httpContext, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
        {
            statusCode ??= 500;

            var problamDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Type = type,
                Detail = detail,
                Instance = instance

            };

            ApplyProblemDetailsDefault(httpContext, problamDetails,statusCode.Value);


            return problamDetails;

        }

        public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
        {
            if (modelStateDictionary == null)
            {
                throw new ArgumentNullException(nameof(modelStateDictionary));
            }

            statusCode ??= 400;

            var problemDetails = new ValidationProblemDetails(modelStateDictionary)
            {
                Status = statusCode,
                Type = type,
                Detail = detail,
                Instance = instance
            };

            if (title != null)
            {
                problemDetails.Title = title;
            }

            ApplyProblemDetailsDefault(httpContext, problemDetails, statusCode.Value);

            return problemDetails;
        }


        private void ApplyProblemDetailsDefault(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
        {
            problemDetails.Status ??= statusCode;

            if(_opcion.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData)) 
            {
                problemDetails.Title ??= clientErrorData.Title;
                problemDetails.Type ??= clientErrorData.Link;

            }

            var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;

            if (traceId != null) 
            {

                problemDetails.Extensions["traceId"] = traceId;
            }

            var errores = httpContext?.Items[HttpContextItemKeys.Erros] as List<Error>;

            if (errores is not null)
            {
                problemDetails.Extensions.Add("errorCode", errores.Select(e => e.Code));
            }
        }
    }
}
