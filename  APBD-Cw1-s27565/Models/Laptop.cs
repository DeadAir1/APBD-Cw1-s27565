namespace APBD_Cw1_s27565.Models;

public class Laptop(string name,int screenSize,int screenRefreshRate) : Equipment(name)
{
   private int ScreenSize { get; set; } = screenSize;
   private int ScreenRefreshRate { get; set; } = screenRefreshRate;
   
} 