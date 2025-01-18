namespace crypto_app.Helpers.DTOs.Account;

public record LoginDto
{
    public string EmailOrUsername { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}
