namespace ConsoleUI;
public abstract class UIElement
{
    public abstract void Render();
    public abstract void Render(int maxWidth, int maxHeight);
    
    public abstract (int Width, int Height) GetSize();

} //UIElement.cs