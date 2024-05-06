namespace HospitalManagementSystem.Application;

public abstract class BaseDTO<T>
{
    public T ID { get; set; } = default!;
}

public abstract class BaseDTO : BaseDTO<int> { }
