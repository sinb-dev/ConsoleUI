namespace ConsoleUI;
public abstract class UIElement
{
    public abstract void Render();
    
    public abstract (int Width, int Height) GetSize();

} //UIElement.cs