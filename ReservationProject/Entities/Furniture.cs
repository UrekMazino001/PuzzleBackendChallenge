using ReservationProject.Enums;

namespace ReservationProject.Entities
{
    public class Furniture
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Status { get; set; } = null!;
        public HashSet<FurnitureReservation>? FurnitureList { get; set; } = new HashSet<FurnitureReservation>();

    }
}
