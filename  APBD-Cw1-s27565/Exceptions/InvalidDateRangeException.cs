namespace APBD_Cw1_s27565.Exceptions;

public class InvalidDateRangeException(int userId,DateTime rentFrom, DateTime rentTo ) :
    Exception($"User {userId} tried to rent an equipment but invalid date " +
              $"range was given From : {rentFrom} to {rentTo}.");
