using RainfallApi.Exceptions;
using RainfallApi.Models;
using RainfallApi.Responses;
using System.Net;

namespace RainfallApi.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                ErrorResponse? errorResponse = null;

                switch (ex)
                {
                    case NotAcceptableException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorResponse = new ErrorResponse
                        {
                            Message = "One or more validation errors occurred.",
                            Detail = new List<ErrorDetail>()
                            {
                                new ErrorDetail
                                {
                                    PropertyName = e.PropertyName,
                                    Message = e.Message
                                }
                            }
                        };
                        break;

                    case NotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        errorResponse = new ErrorResponse
                        {
                            Message = e.Message
                        };
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        errorResponse = new ErrorResponse
                        {
                            Message = ex.Message
                        };
                        break;
                }

                await response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
