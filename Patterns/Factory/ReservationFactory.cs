
namespace HotelReservation.Patterns.Factory;

using HotelReservation.Interfaces;
using HotelReservation.Models;
using HotelReservation.Patterns.Strategy;

public static class ReservationFactory
{
    public static (Reservation reservation, IRateStrategy strategy) CreateReservation(
        string id,
        string guestName,
        string roomType,
        int nights,
        string rateType)
    {
        var reservation = new Reservation(id, guestName, roomType, nights, rateType);

        IRateStrategy strategy;

        if (rateType == "temporadaAlta")
        {
            strategy = new RackRateStrategy();
        }
        else if (rateType == "temporadaBaja")
        {
            strategy = new LowSeasonRateStrategy();
        }
        else if (rateType == "corporativa")
        {
            strategy = new CorporateRateStrategy();
        }
        else
        {
            throw new Exception($"RateType '{rateType}' no es valido");
        }
        return (reservation, strategy);
    }
}