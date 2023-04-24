using ReservationProject.Enums;

namespace ReservationProject.EnumExtensions
{
    public static class FurniturStatusExtension
    {
        public static string ConvertToString(this FurnitureStatus clientType)
        {
            string typeReturn = clientType switch
            {
                FurnitureStatus.Available => "A",
                FurnitureStatus.Reserved => "R",
                _ => throw new ArgumentException("Status is not valid."),
            };
            return typeReturn;
        }
    }
}
