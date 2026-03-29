namespace APBD_Cw1_s27565.Models;

public class Employee (string firstName,string lastName) : User (firstName,lastName)
{
    public override int GetMaxRentalCount() => 5;

}