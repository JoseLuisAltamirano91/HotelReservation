namespace HotelReservation.Patterns;
using HotelReservation.Interfaces;
using HotelReservation.Models;
using HotelReservation.Patterns.Factory;

public class ReservationProcessor
{
    private readonly IReservationRepository _repository;
    private readonly List<IReservationObserver> _observers;

    public ReservationProcessor(IReservationRepository repository)
    {
        _repository = repository;
        _observers = new List<IReservationObserver>();
    }

    public void AddObserver(IReservationObserver observer)
    {
        _observers.Add(observer);
         Console.WriteLine($"[SERVICIO] Observador {observer.GetType().Name} suscrito correctamente.");
    }
    
    private void NotifyObservers(Reservation reservation, ReservationStatus newStatus)
    {
        foreach (var observer in _observers)
        {
            observer.OnStatusChanged(reservation, newStatus);
        }
    }

    public void ProcessReservation(string id, string guestName, string roomType, int nights, string rateType)
    {
 
        var (reservation, strategy) = ReservationFactory.CreateReservation(
            id, guestName, roomType, nights, rateType);

        reservation.TotalCost = strategy.CalculateCost(reservation);
        
        Console.WriteLine($"[PROCESSOR] Reserva creada: {reservation.Id} - Costo: ${reservation.TotalCost}");

        _repository.Save(reservation);

        reservation.Status = ReservationStatus.Confirmada;
        _repository.UpdateStatus(reservation.Id, ReservationStatus.Confirmada);

        NotifyObservers(reservation, ReservationStatus.Confirmada);
    }
}