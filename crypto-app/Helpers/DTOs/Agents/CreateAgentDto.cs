namespace crypto_app.Helpers.DTOs.Agents;

public record CreateAgentDto
{
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public IFormFile File { get; set; }
    public int? PositionId { get; set; }
}
