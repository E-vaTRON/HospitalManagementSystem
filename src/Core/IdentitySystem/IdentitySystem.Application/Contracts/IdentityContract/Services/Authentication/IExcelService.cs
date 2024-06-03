namespace IdentitySystem.Application;

public interface IExcelService
{
    Task<DataTable?> GetDataTableAsync(IFormFile file);
}
