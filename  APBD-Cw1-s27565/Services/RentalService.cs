using APBD_Cw1_s27565.Enums;
using APBD_Cw1_s27565.Exceptions;
using APBD_Cw1_s27565.Models;

namespace APBD_Cw1_s27565.Services;

public class RentalService
{
    private List<Rental> _rentals=new List<Rental>();

    public void CreateRental(User user, Equipment equipment,DateTime rentFrom, DateTime rentTo)
    {
        if (equipment.Status == EquipmentStatus.UNAVAILABLE)
        {
            throw new UnavailableEquipmentException(equipment.Id,user.Id);
        }
        if (GetUserRentals(user.Id).Count >= user.GetMaxRentalCount())
        {
            throw new RentalLimitExceedException(user.Id);
        }

        if (rentTo < rentFrom || rentTo < DateTime.Now || rentFrom < DateTime.Now)
        {
            throw new InvalidDateRangeException(user.Id, rentFrom, rentTo);
        }

        _rentals.Add(new Rental(user, equipment, rentFrom, rentTo));
        equipment.Status = EquipmentStatus.UNAVAILABLE;
    }
    public void EquipmentReturn(int rentalId)
    {
        //Sprawdzić w tym miejscu czy nie rpzekroczono czasu 
        //i jak cos to raczej przez wyjatek to obsluzyc
        var rental=_rentals.FirstOrDefault(e=> e.Id == rentalId);
        if (rental != null)
        {
            _rentals.Remove(rental);
            rental.Equipment.Status = EquipmentStatus.AVAILABLE;
        }
    }

    public List<Rental> GetUserRentals(int userId)
    {
        return _rentals.Where(e=>e.User.Id==userId).ToList();
    }

    public List<Rental> OverdueRentals()
    {
        return _rentals.Where(e=>e.DateTo < DateTime.Now).ToList();
    }

    public void GenerateReport()
    {
    }


}