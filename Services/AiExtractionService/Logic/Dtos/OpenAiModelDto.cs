using System.Text.Json.Serialization;

namespace logic.Dtos;

public class OpenAiModelDto
{
    public string Id { get; set; }
    public string Object { get; set; }
    public int Created { get; set; }
    [JsonPropertyName("owned_by")]
    public string OwnedBy { get; set; }
}