﻿
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using RevenueRecognition.Shared.Abstractions.Exceptions;

namespace RevenueRecognition.Shared.Exceptions;

internal sealed class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (RevenueRecognitionException exc)
        {
            context.Response.StatusCode = 400;
            context.Response.Headers.Add("content-type", "application/json");

            var errorCode = ToUnderscoreCase(exc.GetType().Name.Replace("Exception", string.Empty));
            var json = JsonSerializer.Serialize(new {ErrorCode = errorCode, exc.Message});
            await context.Response.WriteAsync(json);
        }
    }
    
    public static string ToUnderscoreCase(string value)
        => string.Concat((value ?? string.Empty).Select((x, i) => i > 0 && char.IsUpper(x) && !char.IsUpper(value[i-1]) ? $"_{x}" : x.ToString())).ToLower();
}