using APBD_Cw1_s27565.Models;

namespace APBD_Cw1_s27565.Exceptions;

public class ActivePenaltyException (int userId):
    Exception($"User {userId} tried to rent equipment but has active penalty time")
{
    
}