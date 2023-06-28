namespace ModaStore.Domain.Entities.Identity.Authentication;

public class UserAuthentication
{
    public string UserId { get; set; }
    public string ProviderName { get; set; }
    public string ProviderKey { get; set; }
}