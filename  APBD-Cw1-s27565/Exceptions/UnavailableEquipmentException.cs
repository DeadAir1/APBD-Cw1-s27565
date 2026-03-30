namespace APBD_Cw1_s27565.Exceptions;

public class UnavailableEquipmentException(int equipmentId,int userId) 
    : Exception($"User with id : {userId} tried rent unavailable equipment with id : {equipmentId} ")
{ }