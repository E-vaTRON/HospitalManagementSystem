namespace IdentitySystem.Domain;

public interface IHasLastUpdatedOn
{
    DateTime? LastUpdatedOn { get; }
}