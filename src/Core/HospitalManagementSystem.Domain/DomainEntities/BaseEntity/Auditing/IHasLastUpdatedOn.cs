namespace HospitalManagementSystem.Domain;

public interface IHasLastUpdatedOn
{
    DateTime? LastUpdatedOn { get; }
}