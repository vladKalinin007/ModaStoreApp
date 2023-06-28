namespace ModaStore.Domain.Entities.Identity.Authentication;

public class UserToken
{
    public string UserId { get; set; }
    public string TokenType { get; set; }
    public string TokenValue { get; set; }
    public DateTime ExpirationDate { get; set; }
}