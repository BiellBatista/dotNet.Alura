﻿using MudBlazor;
using MudBlazor.Utilities;

namespace _03_03_XX_Upload_Imagens.Web.Layout;

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