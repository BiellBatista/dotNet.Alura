using System.Globalization;

namespace _03_XX_Conhecendo_Structs.UsuarioLib;

public struct Coordenada
{
    public Coordenada()
    {
    }

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