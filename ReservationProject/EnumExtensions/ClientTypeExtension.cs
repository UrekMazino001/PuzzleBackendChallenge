using ReservationProject.Enums;

namespace ReservationProject.EnumExtensions
{
    public static class ClientTypeExtension
    {
        public static string ConvertToString(this ClientType clientType)
        {
            string typeReturn = clientType switch
            {
                ClientType.Company => "C",
                ClientType.Person => "P",
                _ => throw new ArgumentException("Cliente Tyoe is not valid.")
            };
            return typeReturn;
        }
    }

}
