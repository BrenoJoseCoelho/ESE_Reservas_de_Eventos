using System.Text.Json.Serialization;

namespace ReservasApi.Dtos;

public class CouponDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("value")]
    public float Value { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}