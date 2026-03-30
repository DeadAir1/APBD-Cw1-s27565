using APBD_Cw1_s27565.Enums;
using APBD_Cw1_s27565.Models;

namespace APBD_Cw1_s27565.Services;

public class EquipmentService
{
    List<Equipment> _equipments=new List<Equipment>();

    public void AddEquipment(Equipment equipment)
    {
        _equipments.Add(equipment);
    }

    public Equipment GetEquipmentById(int id)
    {
        Equipment? equipment = _equipments.FirstOrDefault(e => e.Id == id);
        if (equipment == null){
            throw new Exception($"Equipment with id :{id} was not found");
        }
        return equipment;
    }

    public List<Equipment> GetEquipmentsWithSpecificStatus(EquipmentStatus requiredStatus)
    {
        return _equipments.Where( e => e.Status == requiredStatus).ToList();
    }
    public List<Equipment> GetAvailableEquipments()
    {
        return _equipments.Where( e => e.Status == EquipmentStatus.AVAILABLE).ToList();
    }
    public void SetUnavailable(int equipmentId)
    {
        var equipment=_equipments.FirstOrDefault(e=>e.Id==equipmentId);
        if (equipment!=null)
        { equipment.Status=EquipmentStatus.UNAVAILABLE; }
    }
}