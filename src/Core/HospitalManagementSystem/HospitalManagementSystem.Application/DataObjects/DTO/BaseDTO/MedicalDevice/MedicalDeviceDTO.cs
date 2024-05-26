namespace HospitalManagementSystem.Application;

public record MedicalDeviceDTO : DTOBase
{
    public string       Name        { get; init; } = string.Empty;      //tên thiết bị
    public string?      Country     { get; init; }                      //nước sản xuất 
    public string?      SmallID     { get; init; }                      //mã con
    public string?      GroupID     { get; init; }                      //mã số nhóm
    public int          Min         { get; init; }                      //MIN
    public int          Max         { get; init; }                      //MAX
}
