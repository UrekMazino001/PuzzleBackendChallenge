using ReservationProject.Enums;

namespace ReservationProject.DTO
{
    public record ClientDTO(
        string Name, 
         DateTime? BirthDate,
        string Address, 
        string PhoneNumber, 
        string ClientType, 
        string Status
        );

}
