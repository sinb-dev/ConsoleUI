namespace ConsoleUI;
public class Button : UIElement
{
    public string Content = "";
    public Button()
    {

    }
    public Button(string content)
    {
        Content = content;
    }
    public override void Render()
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(Content);
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
} //Button.cs