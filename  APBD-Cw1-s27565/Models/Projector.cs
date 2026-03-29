namespace APBD_Cw1_s27565.Models;

public class Projector(string name,int brightness,string projectionTechnology):Equipment(name)
{
    int Brightness { get; set; }= brightness;
    string ProjectionTechnology { get; set; }= projectionTechnology;
}