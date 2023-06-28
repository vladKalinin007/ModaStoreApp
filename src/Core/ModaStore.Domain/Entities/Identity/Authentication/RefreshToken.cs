namespace ModaStore.Domain.Entities.Identity.Authentication;

public class RefreshToken
{
    public string UserId { get; set; }
    public string TokenValue { get; set; }
    public DateTime ExpirationDate { get; set; }
}