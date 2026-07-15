namespace HotelReservation.Interfaces;
using HotelReservation.Models;


public interface IReservationObserver 
{ 
    void OnStatusChanged(Reservation reservation,ReservationStatus newStatus); 
}