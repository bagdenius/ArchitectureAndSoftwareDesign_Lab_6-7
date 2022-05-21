using System.ComponentModel;
using ViewModels.enums;

namespace ViewModels.Builders
{
    public static class RoomBuilder
    {
        private static readonly EnumConverter _converter = new(typeof(RoomVM));
        public static void SetRoomCategory(this RoomVM room, RoomCategory roomCategory)
        {
            room.RoomCategory = roomCategory.ToString().Replace('_', ' ').Replace('0', '-');
        }

        public static RoomCategory GetRoomCategory(this RoomVM room)
        {
            return (RoomCategory)_converter.ConvertFromString(room.RoomCategory.Replace(' ', ' ').Replace('-', '0'));
        }

        public static void SetWindowsView(this RoomVM room, WindowsView windowsView)
        {
            room.WindowsView = windowsView.ToString().Replace('_', ' ').Replace('0', '-');
        }

        public static WindowsView GetWindowsView(this RoomVM room)
        {
            return (WindowsView)_converter.ConvertFromString(room.WindowsView.Replace(' ', ' ').Replace('-', '0'));
        }

        public static void SetServicesAndAmenities(this RoomVM room, List<ServicesAndAmenities> services)
        {
            room.ServicesAndAmenities = string.Empty;
            foreach (var service in services)
            {
                if (room.ServicesAndAmenities != string.Empty)
                {
                    room.ServicesAndAmenities += ", ";
                    room.ServicesAndAmenities += service.ToString().Replace('_', ' ').Replace('0', '-').ToLower();
                }
                else room.ServicesAndAmenities += service.ToString().Replace('_', ' ').Replace('0', '-');
            }
        }

        public static List<ServicesAndAmenities> GetServicesAndAmenities(this RoomVM room)
        {
            List<ServicesAndAmenities> result = new();
            foreach (ServicesAndAmenities service in Enum.GetValues(typeof(ServicesAndAmenities)))
            {
                if (room.ServicesAndAmenities.Contains(service.ToString()))
                {
                    result.Add(service);
                }
            }
            return result;
        }

        public static void SetBookingState(this RoomVM room, BookingState bookingState)
        {
            room.BookingState = bookingState.ToString().Replace(' ', ' ').Replace('-', '0');
        }

        public static BookingState GetBookingState(this RoomVM room)
        {
            return (BookingState)_converter.ConvertFromString(room.BookingState.Replace(' ', ' ').Replace('-', '0'));
        }
    }
}
