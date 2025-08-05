
namespace ConsoleUI;
public static class Overlay
{
    static IOverlayControl? _control;
    static int _left;
    static int _top;
    public static void Set(IOverlayControl control, int left, int top)
    {
        _control = control;
        _left = left;
        _top = top;
    }

    public static void Show()
    {
        if (_control != null)
        {
            UIElement element = _control.BuildOverlay();
            element.Render();
        }
    }
    public static void Clear()
    {
        _control = null;
    }
}