namespace HotelReservation.Interfaces;
using HotelReservation.Models;

public interface IRateStrategy 
{ 
    double CalculateCost(Reservation reservation); 
}