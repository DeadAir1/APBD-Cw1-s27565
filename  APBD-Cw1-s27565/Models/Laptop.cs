namespace APBD_Cw1_s27565.Models;

public class Laptop(int screenSize,int screenRefreshRate,int id,string name) : Equipment(name)
{
   private int ScreenSize { get; set; } = screenSize;
   private int ScreenRefreshRate { get; set; } = screenRefreshRate;
   
} 