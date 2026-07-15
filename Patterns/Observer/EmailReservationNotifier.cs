namespace HotelReservation.Patterns.Observer;

using HotelReservation.Interfaces;
using HotelReservation.Models;

public class EmailReservationNotifier : IReservationObserver
{
    public void OnStatusChanged(Reservation reservation, ReservationStatus newStatus)
    {
        Console.WriteLine($"[EMAIL] Enviando email a {reservation.GuestName}: " +
         $"Su reserva {reservation.Id} ha cambiado a estado {newStatus}");
    }
}