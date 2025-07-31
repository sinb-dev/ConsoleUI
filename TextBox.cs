namespace ConsoleUI;
public class TextBox : ControlBase
{
    int defaultWidth = 20;
    public string Content = "";
    public TextBox()
    {

    }
    public TextBox(string content)
    {
        Content = content;
    }
    public override void Render()
    {
        Render(0,0);
    }
    public override void Render(int maxWidth, int maxHeight)
    {
        Console.BackgroundColor = IsActive() ? ConsoleColor.DarkYellow : ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.White;
        string content = Content;
        if (content.Length > defaultWidth)
        {
            content.Substring(0, defaultWidth);
        } 
        else if (content.Length < defaultWidth)
        {
            content = content.PadRight(defaultWidth);
        }
        Console.Write(content);
    }
    public override (int Width, int Height) GetSize()
    {
        string[] lines = Content.Split("\n");
        int height = lines.Length;
        int width = defaultWidth;
        foreach (string line in lines) 
        {
            if (line.Length > width)
            {
                width = line.Length;
            }
        }
        return (width, height);
    }

    public override void HandleKeyInfo(ConsoleKeyInfo keyInfo)
    {
        switch (keyInfo.Key)
        {
            case ConsoleKey.Backspace:
                Content = Content.Substring(0, Content.Length-1);
                break;
            default:
                Content += keyInfo.KeyChar;
                break;
        }
    }
} //TextBox.cs