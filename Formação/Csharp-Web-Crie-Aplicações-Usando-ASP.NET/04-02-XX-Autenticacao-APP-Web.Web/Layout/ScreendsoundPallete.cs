using MudBlazor;
using MudBlazor.Utilities;

namespace _04_02_XX_Autenticacao_APP_Web.Web.Layout;

public sealed class ScreendsoundPallete : PaletteDark
{
    private ScreendsoundPallete()
    {
        Primary = new MudColor("#9966FF");
        Secondary = new MudColor("#F6AD31");
        Tertiary = new MudColor("#8AE491");
    }

    public static ScreendsoundPallete CreatePallete => new();
}