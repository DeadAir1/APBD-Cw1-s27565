namespace APBD_Cw1_s27565.Models;

public class Student(string firstName,string lastName):User (firstName,lastName)
{
    public override int GetMaxRentalCount() => 2;

}