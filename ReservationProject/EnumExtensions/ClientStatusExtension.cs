using ReservationProject.Enums;

namespace ReservationProject.EnumExtensions
{
    public static class ClientStatusExtension
    {
        public static string ConvertToString(this ClientStatus clientType)
        {
            string typeReturn = clientType switch
            {
                ClientStatus.Available => "A",
                ClientStatus.Due => "D",
                ClientStatus.Canceled => "C",
                _ => throw new ArgumentException("Status is not valid."),
            };
            return typeReturn;
        }
    }
}
