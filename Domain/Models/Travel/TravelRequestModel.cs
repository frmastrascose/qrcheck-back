namespace Domain.Models.Travel
{

    public class TravelRequestModel
    {
        public string HotelName { get; set; }

        public string CheckIn { get; set; }

        public string CheckOut { get; set; }

        public string ReservID { get; set; }

        public string RoomType { get; set; }

        public string CancelData { get; set; }

        public bool IsActive { get; set; }


    }
}

