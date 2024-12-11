using Newtonsoft.Json;

public class Token
{
    [JsonProperty("token")]
    public string token { get; set; }

    [JsonProperty("expiresAt")]
    public DateTimeOffset expiresAt { get; set; }

    [JsonProperty("nUsp")]
    public string nUsp { get; set; }
}
