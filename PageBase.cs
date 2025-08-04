using System.Diagnostics.Contracts;

namespace ConsoleUI;
public abstract class PageBase : UIElement
{
    protected string _title = "";
    public PageBase(string title)
    {
        _title = title;
    }

    public override (int Width, int Height) GetSize()
    {
        return (Console.BufferWidth, Console.BufferHeight);
    }

    public override void Render()
    {
        Render(Console.BufferWidth, Console.BufferHeight);
    }

    public override void Render(int maxWidth, int maxHeight)
    {
        GetMain().Render(maxWidth, maxHeight);
    }

    protected abstract UIElement GetMain();
    public override string ToString()
    {
        return _title;
    }
} //Page.cs