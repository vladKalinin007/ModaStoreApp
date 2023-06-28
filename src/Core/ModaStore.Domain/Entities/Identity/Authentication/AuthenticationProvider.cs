namespace ModaStore.Domain.Entities.Identity.Authentication;

public class AuthenticationProvider
{
    public string ProviderName { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}