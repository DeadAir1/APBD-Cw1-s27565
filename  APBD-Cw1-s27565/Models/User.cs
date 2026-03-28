using APBD_Cw1_s27565.Enums;

namespace APBD_Cw1_s27565.Models;

public class User(int id,string name,string surname,UserType userType)
{
    private int id { get; set; }
    private string name { get; set; }
    private string surname { get; set; }
    private UserType userType { get; set; }
}