namespace IdentitySystem.DataProvider;

public interface IModel
{
}

public interface IModel<TMId>
{
    TMId Id { get; set; }
}