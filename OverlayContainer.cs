namespace ConsoleUI;
public class OverlayContainer : ColumnContainer
{
    
    public OverlayContainer()
    {

    }
    public override void AddChild(UIElement element)
    {
        if (element is ControlBase)
        {
            ControlBase.AllControls.Add((ControlBase) element);
        }
        _children.Add(element);
    }
} //OverlayContainer.cs