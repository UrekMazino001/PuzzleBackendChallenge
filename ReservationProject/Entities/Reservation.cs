

namespace ReservationProject.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int EventTypeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = null!;

        public IEnumerable<FurnitureReservation>? FurnitureList { get; set; } = new List<FurnitureReservation>();

        public Client Client { get; set; }
        public EventType EventType { get; set; }

    }
}
