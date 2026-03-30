

using APBD_Cw1_s27565.Models;
using APBD_Cw1_s27565.Services;
UserService userService = new UserService();
var user1 = userService.CreateUser(new Employee("Jan", "Kowalski"));
var user2 = userService.CreateUser(new Student("Michael", "Doe"));

var equipment1 = new Laptop("Thinkpad", 14, 144);
var equipment2 = new Camera("Canon", 120, "CMOS");
var equipment3 = new Projector("Samsung", 4000, "DLP");

EquipmentService equipmentService = new EquipmentService();

equipmentService.AddEquipment(equipment1);
equipmentService.AddEquipment(equipment2);
equipmentService.AddEquipment(equipment3);

equipmentService.SetUnavailable(equipment2.Id);

RentalService rentalService = new RentalService();
RaportService raportService = new RaportService(equipmentService, rentalService, userService);
// Attempt to rent equipment that is not available
try
{
    Console.WriteLine("\n[Attempt to rent an equipment that is not available]: ");
    rentalService.CreateRental(
        user1,
        equipment2,
        new DateTime(2026, 10, 15, 9, 0, 0),
        new DateTime(2026, 10, 17, 19, 40, 0));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

// Attempt to create conflicting rent
try
{
    Console.WriteLine("\n[Attempt to create conflicting rent]: ");
    rentalService.CreateRental(
        user1,
        equipmentService.GetEquipmentById(1),
        new DateTime(2026, 5, 1, 10, 0, 0),
        new DateTime(2026, 5, 1, 11, 30, 0));
    rentalService.CreateRental(
        user2,
        equipment1,
        new DateTime(2026, 5, 1, 10, 0, 0),
        new DateTime(2026, 5, 1, 11, 30, 0));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

// Attempt to close a non-existent rental
try
{
    Console.WriteLine("\n[Attempt to close a non-existent rental]: ");
    rentalService.CloseRental(10);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

// Attempt to get not existing equipment
try
{
    Console.WriteLine("\n[Attempt to get not existing equipment]: ");
    var equipment = equipmentService.GetEquipmentById(10);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

//Create rental
Console.WriteLine("\n[Attempt to rent  equipment that must end with succed]: ");
Rental rental =rentalService.CreateRental(user2,equipment3,
    new DateTime(2026, 5, 1, 10, 0, 0),
    new DateTime(2026, 5, 1, 11, 30, 0));

//Return equipment at time
Console.WriteLine("\n[Attempt to  close rental on time]: ");
rentalService.CloseRental(rental.Id);

//Return equipment overtime
Console.WriteLine("\n[Attempt to  close rental over time]: ");
Rental rentaTestOverTime=rentalService.CreateRental(user2,equipment3,
    new DateTime(2025, 5, 1, 10, 0, 0),
    DateTime.Now);
rentalService.CloseRental(rentaTestOverTime.Id);

//Raport 
Console.WriteLine("\n[Service raport]: ");
Console.WriteLine(raportService.GenerateRaport());