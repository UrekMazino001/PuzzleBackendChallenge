namespace ReservationProject.Entities
{
    public class FurnitureReservation
    {
        public int FurnitureId { get; set; }
        public Furniture Furniture { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public int Quantity { get; set; }


    }
}
