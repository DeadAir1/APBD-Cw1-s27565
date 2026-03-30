using APBD_Cw1_s27565.Models;

namespace APBD_Cw1_s27565.Services;

public class RaportService(EquipmentService equipmentService,RentalService rentalService,UserService userService)
{
    private EquipmentService EquipmentService { get; set; } = equipmentService;
    private RentalService RentalService { get; set; } = rentalService;
    private UserService UserService { get; set; } = userService;
    
    public String GenerateRaport()
    { 
        String raport = "";
        raport += "\n[Equipment raport in format ID NAME STATUS]\n\n";
        foreach (Equipment equipment in equipmentService.Equipments)
        {
            raport += equipment.Id + "; " + equipment.Name + "; " + equipment.Status + ";\n";
        }
        raport += "\n[Rental raport in format ID USER_ID EQUIPMENT_ID DATE_FROM DATE_TO]\n\n";
        foreach (Rental rental in rentalService.Rentals)
        {
            raport += rental.Id + "; " + rental.User.Id + "; " + 
                      rental.Equipment.Id + "; " + rental.DateFrom + "; " + rental.DateTo + ";\n";
        }
        raport += "\n[User raport in format ID FULL_NAME PENALTY_DATE]\n\n";
        foreach (User user in userService.Users)
        {
            raport += user.Id + "; " + user.FirstName +" "+user.LastName+ "; " + user.PenaltyRentalDate + ";\n";
        }

        return raport;
    }
}