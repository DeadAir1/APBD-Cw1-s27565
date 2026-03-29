using APBD_Cw1_s27565.Enums;

namespace APBD_Cw1_s27565.Models;

public abstract class Equipment(string name)
{
    private static int _id = 1;
    public int Id
    {
        get;
        set;
    } = _id++;

    public EquipmentStatus Status
    {
        get;
        set;
    } = EquipmentStatus.AVAILABLE;

    public string Name
    {
        get;
        set;
    } = name;

}