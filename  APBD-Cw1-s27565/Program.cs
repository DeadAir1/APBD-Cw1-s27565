

using APBD_Cw1_s27565.Models;
using APBD_Cw1_s27565.Services;

var user1 = new Employee("Jan", "Kowalski");
var user2 = new Student("Michael", "Doe");

var equipment1 = new Laptop("Thinkpad", 14, 144);
var equipment2 = new Camera("Canon", 120, "CMOS");
var equipment3 = new Projector("Samsung", 4000, "DLP");

EquipmentService equipmentService = new EquipmentService();

equipmentService.AddEquipment(equipment1);
equipmentService.AddEquipment(equipment2);
equipmentService.AddEquipment(equipment3);

equipmentService.SetUnavailable(equipment2.Id);

RentalService rentalService = new RentalService();

// Attempt to rent equipment that is not available
try
{
    Console.WriteLine("\n[Attempt to rent an equipment that is not available]: ");
    rentalService.CreateRental(
        user1,
        equipment2,
        new DateTime(2026, 1, 1, 10, 0, 0),
        new DateTime(2026, 1, 1, 11, 30, 0));
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
Console.WriteLine("\n[Attempt to rent  close rental on time]: ");
rentalService.CloseRental(rental.Id);