using APBD_Cw1_s27565.Enums;
using APBD_Cw1_s27565.Models;

namespace APBD_Cw1_s27565.Services;

public  class UserService
{
    public List<User> Users { get; } = new List<User>();
    private  int _usersCount = 1;

    public User CreateUser(User user)
    {
        Users.Add(user);
        return user;
    }
    
}