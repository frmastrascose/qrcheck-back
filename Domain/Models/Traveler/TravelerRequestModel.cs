namespace Domain.Models.Traveler;

public class TravelerRequestModel
{
    public string Name { get; set; }

    public string CPF { get; set; }

    public string Email { get; set; }

    public string Telephone { get; set; }

    public string Accessibility { get; set; }

    public string HotelName { get; set; }

    public string CheckIn { get; set; }

    public string CheckOut { get; set; }

    public string ReservationId { get; set; }

    public string RoomType { get; set; }

    public string RoomNumber { get; set; }

    public string CancelData { get; set; }
}

