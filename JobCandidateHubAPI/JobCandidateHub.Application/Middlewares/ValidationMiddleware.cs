using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace JobCandidateHub.Application.Middlewares
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var validator = context.RequestServices.GetService(typeof(IValidator<>).MakeGenericType(context.Request.Body.GetType())) as IValidator;

            if (validator != null)
            {
                var validationResult = await validator.ValidateAsync((IValidationContext)context.Request.Body);
                if (!validationResult.IsValid)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/json";
                    var errors = JsonSerializer.Serialize(validationResult.Errors.Select(e => e.ErrorMessage));
                    await context.Response.WriteAsync(errors);
                    return;
                }
            }

            await _next(context);
        }
    }
}
