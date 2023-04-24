using ReservationProject.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationProject.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string ClientType { get; set; } = null!;
        public string Status { get; set; } = null!;

        public List<Reservation>? Reservations { get; set; } = new List<Reservation>();


        [NotMapped]
        public int? Age
        {
            get {
                if( !BirthDate.HasValue )
                    return null;

                return DateTime.Today.Year - BirthDate?.Year; ;
                    
            }
        }
    }
}
