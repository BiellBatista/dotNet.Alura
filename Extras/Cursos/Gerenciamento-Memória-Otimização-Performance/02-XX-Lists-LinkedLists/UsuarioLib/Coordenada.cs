using System.Globalization;

namespace _02_XX_Lists_LinkedLists.UsuarioLib;

public class Coordenada
{
    public Coordenada(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public double Latitude;
    public double Longitude;

    public override string ToString()
    {
        return $"{Latitude.ToString(CultureInfo.InvariantCulture)}, {Longitude.ToString(CultureInfo.InvariantCulture)}";
    }
}