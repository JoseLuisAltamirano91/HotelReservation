namespace HotelReservation.Patterns.Observer;

using HotelReservation.Interfaces;
using HotelReservation.Models;

public class SmsReservationNotifier : IReservationObserver
{
    public void OnStatusChanged(Reservation reservation, ReservationStatus newStatus)
    {
        Console.WriteLine($"[SMS] Enviando SMS a {reservation.GuestName}: " +
                          $"Su reserva {reservation.Id} ha cambiado a estado {newStatus}");
    }
}