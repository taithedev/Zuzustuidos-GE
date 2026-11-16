using Raylib_cs;

namespace ZuzuStudios.Rendering;

public static class ColorPalette
{
    public static readonly Color Background = new(12, 16, 24, 255);
    public static readonly Color Panel = new(19, 26, 38, 255);
    public static readonly Color PanelRaised = new(34, 45, 62, 255);
    public static readonly Color Accent = new(93, 190, 248, 255);
    public static readonly Color Text = new(230, 237, 247, 255);
    public static readonly Color Muted = new(150, 171, 193, 255);

    public static Color Parse(string? hex)
    {
        try
        {
            if (hex is null) return Accent;
            var value = hex.TrimStart('#');
            if (value.Length != 6) return Accent;
            return new Color(Convert.ToByte(value[..2], 16),
                Convert.ToByte(value.Substring(2, 2), 16),
                Convert.ToByte(value.Substring(4, 2), 16), 255);
        }
        catch { return Accent; }
    }
}
