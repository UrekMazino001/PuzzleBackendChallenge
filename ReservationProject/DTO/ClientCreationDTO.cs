namespace ReservationProject.DTO
{
    public record ClientCreationDTO(
        string Name,
         DateTime? BirthDate,
        string Address,
        string PhoneNumber,
        string ClientType
        );
}
