namespace HotelReservation.Patterns.Strategy;
using HotelReservation.Interfaces;
using HotelReservation.Models;

public class RackRateStrategy : IRateStrategy
{
    public double CalculateCost(Reservation reservation)
    {
        return reservation.Nights * 80 * 1.20;
    }
}