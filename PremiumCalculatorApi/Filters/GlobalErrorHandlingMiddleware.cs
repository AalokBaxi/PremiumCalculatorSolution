using Microsoft.AspNetCore.Http;
using PremiumCalculator.Service.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace PremiumCalculator.Api.Filters
{
    /// <summary>
    /// Middleware to handle exceptions
    /// </summary>
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next">The next middleware in pipleline</param>
        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Method to handel exception
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (ex)
                {
                    case BusinessException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var errorResponse = new
                {
                    message = ex.Message,
                    statusCode = response.StatusCode
                };

                var errorJson = JsonSerializer.Serialize(errorResponse);

                await response.WriteAsync(errorJson);
            }
        }
    }
}
