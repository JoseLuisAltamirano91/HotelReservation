namespace HotelReservation.Patterns.Strategy;
using HotelReservation.Interfaces;
using HotelReservation.Models;

public class LowSeasonRateStrategy : IRateStrategy
{
    public double CalculateCost(Reservation reservation)
    {
        return reservation.Nights * 80 * 0.85;
    }
}