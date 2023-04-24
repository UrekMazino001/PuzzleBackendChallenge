using ReservationProject.Enums;

namespace ReservationProject.EnumExtensions
{
    public static class ReservationStatusExtension
    {
        public static string ConvertToString(this ReservationStatus clientType)
        {
            string typeReturn = clientType switch
            {
                ReservationStatus.Confirmed => "C",
                ReservationStatus.Canceled => "D",
                _ => throw new ArgumentException("Status is not valid."),
            };
            return typeReturn;
        }
    }
}
