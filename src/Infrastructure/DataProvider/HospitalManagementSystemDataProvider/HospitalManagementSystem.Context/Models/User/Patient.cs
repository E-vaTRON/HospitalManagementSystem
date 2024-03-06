using HospitalManagementSystem.Context.Models.Function.Appointment;

namespace HospitalManagementSystem.DataProvider;

public class Patient : User
{
    public virtual ICollection<BookingAppointment>  BookingAppointments { get; set; } = new HashSet<BookingAppointment>();
    public virtual ICollection<RoomAllocation>      RoomAllocations     { get; set; } = new HashSet<RoomAllocation>();
}