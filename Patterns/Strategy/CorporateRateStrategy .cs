namespace HotelReservation.Patterns.Strategy;
using HotelReservation.Interfaces;
using HotelReservation.Models;

public class CorporateRateStrategy : IRateStrategy
{
    public double CalculateCost(Reservation reservation)
    {
        return reservation.Nights * 60;
    }
}