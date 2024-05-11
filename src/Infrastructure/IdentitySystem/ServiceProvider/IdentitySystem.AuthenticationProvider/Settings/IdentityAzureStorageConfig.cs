namespace IdentitySystem.ServiceProvider;

public class IdentityAzureStorageConfig
{
    public string   AccountKey              { get; set; } = string.Empty;
    public string   AccountName             { get; set; } = string.Empty;
    public string   PhotoStorage            { get; set; } = string.Empty;
    public string   AvatarStorage           { get; set; } = string.Empty;
    public string   BlobConnectionString    { get; set; } = string.Empty;
}
