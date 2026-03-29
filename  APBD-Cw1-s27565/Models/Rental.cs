namespace APBD_Cw1_s27565.Models;

public class Rental(User user,Equipment equipment,DateTime dateFrom,DateTime dateTo)
{
    private static int _id = 1;

    public User User{
        get;
        set;
    } = user;

    public int Id { get; set; } = _id++;
    public Equipment Equipment { get; set; }=equipment;
    public DateTime DateFrom { get; set; }= dateFrom;
    public DateTime DateTo { get; set; }= dateTo;
    
}