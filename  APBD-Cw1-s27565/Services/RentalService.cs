using APBD_Cw1_s27565.Enums;
using APBD_Cw1_s27565.Exceptions;
using APBD_Cw1_s27565.Models;

namespace APBD_Cw1_s27565.Services;

public class RentalService
{
    public  List<Rental> Rentals { get; } = new List<Rental>();

    public Rental CreateRental(User user, Equipment equipment,DateTime rentFrom, DateTime rentTo)
    {
        if (equipment.Status == EquipmentStatus.UNAVAILABLE)
        {
            throw new UnavailableEquipmentException(equipment.Id,user.Id);
        }
        if (GetUserRentals(user.Id).Count >= user.GetMaxRentalCount())
        {
            throw new RentalLimitExceedException(user.Id);
        }

        if (rentTo < rentFrom || rentTo < DateTime.Today)
        {
            throw new InvalidDateRangeException(user.Id, rentFrom, rentTo);
        }
        
        if (user.PenaltyRentalDate > DateTime.Today)
        {
            throw new ActivePenaltyException(user.Id);
        }
        
        Rental rental = new Rental(user, equipment, rentFrom, rentTo);
        Rentals.Add(rental);
        user.PenaltyRentalDate = DateTime.Today; 
        Console.WriteLine($"Equipment with id : {equipment.Id} was rent to user with id : {user.Id}");
        equipment.Status = EquipmentStatus.UNAVAILABLE;
        return rental;
    }
    public void CloseRental(int rentalId)
    {
        var rental=Rentals.FirstOrDefault(e=> e.Id == rentalId);
        if (rental != null)
        {
            Rentals.Remove(rental);
            rental.Equipment.Status = EquipmentStatus.AVAILABLE;
            if(rental.DateTo<DateTime.Now)
            {
                var overdueDays = (DateTime.Today - rental.DateTo.Date).Days;
                DateTime penaltyDueDate = DateTime.Today.AddDays(overdueDays);
                rental.User.PenaltyRentalDate = penaltyDueDate;
                Console.WriteLine($"Rental with id : {rental.Id} was closed with overtime " +
                                  $"user : {rental.User.Id} get a penalty due {penaltyDueDate}");
            }
            else
            {
                Console.WriteLine($"Rental with id : {rental.Id} was closed on time");
            }
        }
        else
        {
            throw new Exception($"Rental with id : {rentalId} was not found");
        }
    }

    public List<Rental> GetUserRentals(int userId)
    {
        return Rentals.Where(e=>e.User.Id==userId).ToList();
    }

    public List<Rental> OverdueRentals()
    {
        return Rentals.Where(e=>e.DateTo < DateTime.Today).ToList();
    }
 
}