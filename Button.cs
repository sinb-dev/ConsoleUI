namespace ConsoleUI;
public class Button : ControlBase
{
    public string Content = "";
    Action? _onClicked;
    int defaultWidth = 20;
    public Button()
    {

    }
    public Button(string content, Action? onClicked = null)
    {
        Content = content;
        _onClicked = onClicked;
    }
    
    public override void Render()
    {
        Render(defaultWidth,0);
    }
    public override void Render(int maxWidth, int maxHeight)
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;
        string content = Content;
        if (content.Length > maxWidth) 
        {
            content = content.Substring(0, maxWidth-3) + "...";
        }
        else if (content.Length < maxWidth)
        {
            //Align the button text in the middle of the button
            int spaceLeft = maxWidth - content.Length;
            int padLeft = (int) Math.Round(spaceLeft*0.5) + content.Length;
            content = content.PadLeft(padLeft).PadRight(maxWidth);
        }

        Console.Write(content);
    }
    public override (int Width, int Height) GetSize()
    {
        string[] lines = Content.Split("\n");
        int height = lines.Length;
        int width = 0;
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
            case ConsoleKey.Enter:
                if (_onClicked != null)
                {
                    _onClicked?.Invoke();
                }
                break;
        }
    }
} //Button.cs