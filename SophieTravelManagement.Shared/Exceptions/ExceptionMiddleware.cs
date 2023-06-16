using System.Text.Json;
using Microsoft.AspNetCore.Http;
using SophieTravelManagement.Shared.Abstractions.Exceptions;

namespace SophieTravelManagement.Shared.Exceptions;

internal sealed class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (TravelerCheckListException e)
        {
            context.Response.StatusCode = 400;
            context.Response.Headers.Add("content-type", "application/json");
            var errorCode = ToUnderscoreCase(e.GetType().Name.Replace("Exception", string.Empty));
            var json = JsonSerializer.Serialize(new
            {
                ErrorCode = errorCode,
                e.Message
            });
            await context.Response.WriteAsync(json);
        }
    }

    private static string ToUnderscoreCase(string value) =>
         string.Concat((value ?? String.Empty).Select((x, i) => i > 0 && char.IsUpper(x) && !char.IsUpper(value[i - 1]) ? $"_{x}" : x.ToString())).ToLower();

}