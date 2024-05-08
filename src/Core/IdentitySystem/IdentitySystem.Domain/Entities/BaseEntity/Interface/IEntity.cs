namespace IdentitySystem.Domain;

public interface IEntity
{
}

public interface IEntity<TEId>
{
    TEId Id { get; set; }
}