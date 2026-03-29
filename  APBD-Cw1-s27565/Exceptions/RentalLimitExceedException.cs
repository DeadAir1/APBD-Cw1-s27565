namespace APBD_Cw1_s27565.Exceptions;

public class RentalLimitExceedException (int userId ) :
    Exception($"User {userId} tried to rent an equipment but limit exceed ")
{
    
}