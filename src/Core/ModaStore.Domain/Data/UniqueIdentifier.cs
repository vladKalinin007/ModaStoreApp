namespace ModaStore.Domain.Data;

public static class UniqueIdentifier
{
    public static string New => Guid.NewGuid().ToString();
}