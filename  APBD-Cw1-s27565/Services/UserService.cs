using APBD_Cw1_s27565.Enums;
using APBD_Cw1_s27565.Models;

namespace APBD_Cw1_s27565.Services;

public abstract class UserService
{
    private  List<User> _usersExtent=new List<User>();
    private  int _usersCount = 1;

    public void CreateUser(User user)
    {
        _usersExtent.Add(user);
    }
    
}