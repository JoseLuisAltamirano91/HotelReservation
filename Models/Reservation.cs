namespace HotelReservation.Models;

public enum ReservationStatus
{
    Creada,
    Confirmada,
    EnCurso,
    Finalizada,
    Cancelada
}

public class Reservation
{
    public string Id { get; set; }
    public string GuestName { get; set; }
    public string RoomType { get; set; }
    public int Nights { get; set; }
    public string RateType { get; set; }
    public ReservationStatus Status { get; set; }
    public double TotalCost { get; set; }

    public Reservation(
        string id,
        string guestName,
        string roomType,
        int nights,
        string rateType)
    {
        Id = id;
        GuestName = guestName;
        RoomType = roomType;
        Nights = nights;
        RateType = rateType;
        Status = ReservationStatus.Creada;
        TotalCost = 0;
    }
}