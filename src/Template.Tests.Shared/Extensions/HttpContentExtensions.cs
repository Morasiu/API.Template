using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Template.Api.Configuration.JsonSerilizer;

namespace Template.Tests.Shared.Extensions;

public static class HttpContentExtensions
{
    private static readonly JsonOptions JsonOptions;
    
    static HttpContentExtensions()
    {
        JsonOptions = new JsonOptions();
        JsonOptions.AddDefaultOptions();
    }
    
    public static async ValueTask<T?> DeserializeContentAsync<T>(this HttpContent content)
    {
        return await JsonSerializer.DeserializeAsync<T>(content.ReadAsStream(), JsonOptions.JsonSerializerOptions);
    }
}