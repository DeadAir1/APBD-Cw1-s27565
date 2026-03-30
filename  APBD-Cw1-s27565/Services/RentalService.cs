using APBD_Cw1_s27565.Enums;
using APBD_Cw1_s27565.Exceptions;
using APBD_Cw1_s27565.Models;

namespace APBD_Cw1_s27565.Services;

public class RentalService
{
    private List<Rental> _rentals=new List<Rental>();

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

        if (rentTo < rentFrom || rentTo < DateTime.Today || rentFrom < DateTime.Today)
        {
            throw new InvalidDateRangeException(user.Id, rentFrom, rentTo);
        }
        
        if (user.PenaltyRentalDate > DateTime.Today)
        {
            throw new ActivePenaltyException(user.Id);
        }
        
        Rental rental = new Rental(user, equipment, rentFrom, rentTo);
        _rentals.Add(rental);
        user.PenaltyRentalDate = DateTime.Today; 
        Console.WriteLine($"Equipment with id  :{equipment.Id} was rent to user with id  :{user.Id}");
        equipment.Status = EquipmentStatus.UNAVAILABLE;
        return rental;
    }
    public void CloseRental(int rentalId)
    {
        var rental=_rentals.FirstOrDefault(e=> e.Id == rentalId);
        if (rental != null)
        {
            _rentals.Remove(rental);
            rental.Equipment.Status = EquipmentStatus.AVAILABLE;
            if(rental.DateTo<DateTime.Today)
            {
                var overdueDays = (DateTime.Today - rental.DateTo.Date).Days;
                rental.User.PenaltyRentalDate = DateTime.Today.AddDays(overdueDays);
            }
        }
        else
        {
            throw new Exception($"Rental with id :{rentalId} was not found");
        }
    }

    public List<Rental> GetUserRentals(int userId)
    {
        return _rentals.Where(e=>e.User.Id==userId).ToList();
    }

    public List<Rental> OverdueRentals()
    {
        return _rentals.Where(e=>e.DateTo < DateTime.Today).ToList();
    }

}