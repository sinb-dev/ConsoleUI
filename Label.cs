using System.Security.AccessControl;

namespace ConsoleUI;

public class Label: UIElement
{
    public string Content = "";
    public Label()
    {
    }
    public Label(string content)
    {
        Content = content;
    }

    public Label(string content, int width)
    {
        Content = content;
        Width = width;
    }
    public override void Render()
    {
        Render(0,0);
    }
    public override void Render(int maxWidth, int maxHeight)
    {
        int offsetX = Console.CursorLeft;
        string[] lines = Content.Split("\n");
        foreach (string line in lines)
        {
            string text = line;
            if (maxWidth > 0 && text.Length > maxWidth) 
            {
                text = text.Substring(0, maxWidth - 3) + "...";
            }
            else if (text.Length < Width)
            {
                text = text.PadRight(Width);
            }
            Console.Write(text);
            Console.CursorLeft = offsetX;
            Console.CursorTop++;
        }
    }
    public override (int Width, int Height) GetSize()
    {
        string[] lines = Content.Split("\n");
        int height = lines.Length;
        int width = Width;
        if (width == 0)
        {
            foreach (string line in lines) 
            {
                if (line.Length > width)
                {
                    width = line.Length;
                }
            }
        }
        return (width, height);
    }    
} //Label.cs