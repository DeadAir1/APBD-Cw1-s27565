using APBD_Cw1_s27565.Enums;
using APBD_Cw1_s27565.Models;

namespace APBD_Cw1_s27565.Services;

public class EquipmentService
{
    public List<Equipment> Equipments { get; } = new List<Equipment>();

    public void AddEquipment(Equipment equipment)
    {
        Equipments.Add(equipment);
    }

    public Equipment GetEquipmentById(int id)
    {
        Equipment? equipment = Equipments.FirstOrDefault(e => e.Id == id);
        if (equipment == null){
            throw new Exception($"Equipment with id : {id} was not found");
        }
        return equipment;
    }

    public List<Equipment> GetEquipmentsWithSpecificStatus(EquipmentStatus requiredStatus)
    {
        return Equipments.Where( e => e.Status == requiredStatus).ToList();
    }
    public List<Equipment> GetAvailableEquipments()
    {
        return Equipments.Where( e => e.Status == EquipmentStatus.AVAILABLE).ToList();
    }
    public void SetUnavailable(int equipmentId)
    {
        var equipment=Equipments.FirstOrDefault(e=>e.Id==equipmentId);
        if (equipment!=null)
        { equipment.Status=EquipmentStatus.UNAVAILABLE; }
    }
}