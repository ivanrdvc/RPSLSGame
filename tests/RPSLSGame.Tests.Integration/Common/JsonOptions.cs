using System.Text.Json;

namespace RPSLSGame.Tests.Integration.Common;

public static class JsonOptions
{
    public static readonly JsonSerializerOptions Default = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };
}
