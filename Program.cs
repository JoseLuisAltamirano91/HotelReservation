using HotelReservation.Interfaces;
using HotelReservation.Models;
using HotelReservation.Patterns;
using HotelReservation.Patterns.Observer;
using HotelReservation.Patterns.Repository;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== SISTEMA DE RESERVAS HOTEL REAL QUITO ===\n");

        //repositorio
        IReservationRepository repository = new ReservationRepository();

        //procesador
        var processor = new ReservationProcessor(repository);

        //observadores
        processor.AddObserver(new EmailReservationNotifier());
        processor.AddObserver(new SmsReservationNotifier());

        Console.WriteLine("--- Procesando Reserva 1 ---");
        processor.ProcessReservation("RES-001","Juan Pérez","Suite",3,"temporadaAlta");

        Console.WriteLine("\n--- Procesando Reserva 2 ---");
        processor.ProcessReservation("RES-002","María García","Doble",5,"temporadaBaja");

        Console.WriteLine("\n--- Procesando Reserva 3 ---");
        processor.ProcessReservation("RES-003","Carlos López","Individual",2,"corporativa");

        Console.WriteLine("\n--- Mostrando todas las reservas ---");
        var reservas = repository.GetAll();
        foreach (var r in reservas)
        {
            Console.WriteLine($"ID: {r.Id}, Huesped: {r.GuestName}, Costo: ${r.TotalCost}, Estado: {r.Status}");
        }
    }
}