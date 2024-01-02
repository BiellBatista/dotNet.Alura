using System.Globalization;

namespace _01_XX_Entendendo_Referencias.UsuarioLib;

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