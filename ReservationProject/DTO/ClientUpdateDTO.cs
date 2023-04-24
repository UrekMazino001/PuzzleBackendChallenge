
namespace ReservationProject.DTO
{
    public class ClientUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string ClientType { get; set; } = null!;
    }
}
