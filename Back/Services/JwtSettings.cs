namespace Back.Services;
public record JwtSettings
{
    public string SecretKey { get; set; } = null!;
    public int ExpireHours { get; set; }
}