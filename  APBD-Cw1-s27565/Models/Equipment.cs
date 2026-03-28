namespace APBD_Cw1_s27565.Models;

public abstract class Equipment(int id,string name)
{
    private int Id
    {
        get;
        set;
    } = id;

    private bool IsAvailable
    {
        get;
        set;
    } = true;

    private string Name
    {
        get;
        set;
    } = name;

}