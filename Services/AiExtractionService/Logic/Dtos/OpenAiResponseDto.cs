using logic.Dtos;

namespace Extraction.Repository;

public class OpenAiResponseDto
{
    public string Object { get; set; }
    public List<OpenAiModelDto> Data { get; set; }
}