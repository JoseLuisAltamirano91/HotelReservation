namespace HotelReservation.Patterns.Repository;

using HotelReservation.Interfaces;
using HotelReservation.Models;

public class ReservationRepository : IReservationRepository
{
    private readonly List<Reservation> _reservations = new();

    public void Save(Reservation reservation)
    {
        _reservations.Add(reservation);
        Console.WriteLine($"[Repositorio] Reserva {reservation.Id} guardada en el repositorio");
    }

    public Reservation? GetById(string id)
    {
        return _reservations.FirstOrDefault(r => r.Id == id);
    }

    public List<Reservation> GetAll()
    {
        return _reservations;
    }

    public void UpdateStatus(string id, ReservationStatus newStatus)
    {
        Reservation? reservation = GetById(id);

        if (reservation != null)
        {
            reservation.Status = newStatus;
            Console.WriteLine($"[Repositorio] Estado de la reserva {id} actualizado a {newStatus}");
        }
        else
        {
            Console.WriteLine($"[Repositorio] No existe la reserva {id}");
        }
    }
}