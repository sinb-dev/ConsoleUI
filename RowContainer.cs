namespace ConsoleUI;
public class RowContainer : ContainerBase
{
    public RowContainer()
    {

    }
    public override void Render()
    {
        Render(0,0);
    }
    public override void Render(int maxWidth, int maxHeight)
    {
        ConsoleColor background = Console.BackgroundColor;
        ConsoleColor foreground = Console.ForegroundColor;
        int offsetX = Console.CursorLeft;
        int offsetY = Console.CursorTop;
        foreach (UIElement child in _children)
        {
            child.Render();
            var size = child.GetSize();
            offsetX += size.Width + 1;
            
            //Prepare cursor for next child
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            Console.CursorLeft = offsetX;
            Console.CursorTop = offsetY;
        }
        Console.CursorTop += GetSize().Height;
    }
    public override (int Width, int Height) GetSize()
    {
        int width = 0;
        int height = 0;
        foreach (UIElement child in _children)
        { 
            var childSize = child.GetSize();
            width += childSize.Width;
            if (childSize.Height > height)
            {
                height = childSize.Height;
            }
        }
        return (width, height);
    }
} //RowContainer.cs