namespace ConsoleUI;

public abstract class ContainerBase : UIElement
{
    protected List<UIElement> _children = new();
    public ContainerBase()
    {

    }
    public void AddChild(UIElement element)
    {
        if (element is ControlBase)
        {
            ControlBase.AllControls.Add((ControlBase) element);
        }
        _children.Add(element);
    }
} //ContainerBase.cs