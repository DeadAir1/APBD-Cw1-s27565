namespace APBD_Cw1_s27565.Models;

public class Camera(string name,int frameRate,string sensorType) : Equipment(name)
{
    int FrameRate { get; set; } = frameRate;
    private string SensorType { get; set; } = sensorType;

}