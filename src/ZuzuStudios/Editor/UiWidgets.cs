using Raylib_cs;
using ZuzuStudios.Rendering;

namespace ZuzuStudios.Editor;

public static class UiWidgets
{
    public static void Label(string text, int x, int y, int size = 14, bool muted = false) =>
        Raylib.DrawText(text, x, y, size, muted ? ColorPalette.Muted : ColorPalette.Text);

    public static bool Button(string title, int x, int y, int w, int h, bool active = false)
    {
        var p = Raylib.GetMousePosition();
        bool hover = p.X >= x && p.X <= x + w && p.Y >= y && p.Y <= y + h;
        var background = active ? new Color(39, 84, 120, 255)
            : hover ? new Color(51, 66, 85, 255) : ColorPalette.PanelRaised;
        Raylib.DrawRectangleRounded(new Rectangle(x, y, w, h), .19f, 5, background);
        var label = title.Length > 28 ? title[..25] + "..." : title;
        int font = 13;
        Raylib.DrawText(label, x + Math.Max(4, (w - Raylib.MeasureText(label, font)) / 2),
            y + (h - font) / 2, font, ColorPalette.Text);
        return hover && Raylib.IsMouseButtonPressed(MouseButton.Left);
    }
}
