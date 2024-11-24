using System.Text.Json.Serialization;

namespace ReservasApi.Dtos;

public class UserDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("document")]
    public string Document { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }
}