using APBD_Cw1_s27565.Enums;

namespace APBD_Cw1_s27565.Models;

public abstract class User(string firstName,string lastName)
{
    private static  int _id = 1;
    public int Id { get; set; } = _id++;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    
    public abstract int GetMaxRentalCount();
}